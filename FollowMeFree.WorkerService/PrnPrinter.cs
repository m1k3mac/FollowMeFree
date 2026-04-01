using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using FollowMeFree_Shared;
using FollowMeFree.WorkerService.Data;
using FollowMeFree.WorkerService.Data.Scaffolded;
using Microsoft.Extensions.Logging;

// This class provides functionality to send raw PRN files directly to a specified printer using the Windows Spooler API.

namespace FollowMeFree.WorkerService
{
    public static class PrnPrinter
    {
        #region Win32 Spooler API

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref DOC_INFO_1 pDocInfo);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool EndDocPrinter(IntPtr hPrinter);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DOC_INFO_1
        {
            public string pDocName;
            public string pOutputFile;
            public string pDatatype;
        }

        #endregion
        
        public static bool SendToPrinterByName(string printerName, string filePath, string datatype = "RAW", FollowMeFreeDbContext? db = null, ILogger? logger = null)
        {
            if (string.IsNullOrEmpty(printerName))
                throw new ArgumentNullException(nameof(printerName));
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"PRN file not found: {filePath}", filePath);

            if (string.IsNullOrEmpty(datatype))
                datatype = "RAW";

            byte[] fileData = File.ReadAllBytes(filePath);

            IntPtr hPrinter = IntPtr.Zero;
            bool success = false;

            try
            {
                if (!OpenPrinter(printerName, out hPrinter, IntPtr.Zero))
                {
                    int error = Marshal.GetLastWin32Error();
                    logger?.LogError("[PrnPrinter] OpenPrinter failed for '{PrinterName}' (Win32 error {Error}). Verify the printer name matches exactly as shown in Windows Print Management and that the service account has access.",
                        printerName, error);
                    return false;
                }

                var docInfo = new DOC_INFO_1
                {
                    pDocName = Path.GetFileName(filePath),
                    pOutputFile = null,
                    pDatatype = datatype
                };

                if (!StartDocPrinter(hPrinter, 1, ref docInfo))
                {
                    int error = Marshal.GetLastWin32Error();
                    logger?.LogError("[PrnPrinter] StartDocPrinter failed for '{PrinterName}' (Win32 error {Error})",
                        printerName, error);
                    return false;
                }

                try
                {
                    if (!StartPagePrinter(hPrinter))
                    {
                        int error = Marshal.GetLastWin32Error();
                        logger?.LogError("[PrnPrinter] StartPagePrinter failed for '{PrinterName}' (Win32 error {Error})",
                            printerName, error);
                        return false;
                    }

                    IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem(fileData.Length);
                    try
                    {
                        Marshal.Copy(fileData, 0, pUnmanagedBytes, fileData.Length);
                        if (WritePrinter(hPrinter, pUnmanagedBytes, fileData.Length, out int bytesWritten))
                        {
                            success = bytesWritten == fileData.Length;
                            logger?.LogInformation("[PrnPrinter] Sent {BytesWritten:N0} bytes to '{PrinterName}'",
                                bytesWritten, printerName);

                            // Move the processed file to a "Printed" subdirectory
                            var directoryPath = Path.GetDirectoryName(filePath);
                            if(!Directory.Exists(Path.Combine(directoryPath,"Printed")))
                            {
                                Directory.CreateDirectory(Path.Combine(directoryPath,"Printed"));
                            }

                            File.Move(filePath, Path.Combine(directoryPath, "Printed", Path.GetFileName(filePath)),true);

                            // Get the filename and split by ';'. Then map to PrintJobSnapshot
                            var fileName = Path.GetFileName(filePath);
                            var parts = fileName.Split(';');
                            PrintJobSnapshot snapshot = new PrintJobSnapshot
                            {
                                JobId = int.Parse(parts[4]),
                                JobName = parts[1],
                                Submitter = parts[0],
                                TimeSubmitted = DateTime.UtcNow,
                                NumberOfPages = int.Parse(parts[2]),
                                Datatype = parts[5]
                            };

                            // Write the snapshot to the PrintJob table in the database
                            if (db != null)
                            {
                                var user = db.Users.Where(u => u.UserName == snapshot.Submitter).OrderBy(o => o.UserName).FirstOrDefault();

                                var printJob = new PrintJob
                                {
                                    UserName = snapshot.Submitter,
                                    DepartmentId = user.DepartmentId,
                                    DocumentName = snapshot.JobName,
                                    JobId = snapshot.JobId,
                                    Pages = snapshot.NumberOfPages,
                                    DateTimePrinted = snapshot.TimeSubmitted,
                                    DataType = snapshot.Datatype
                                };
                                db.PrintJobs.Add(printJob);
                                db.SaveChanges();
                            }

                        }
                        else
                        {
                            int error = Marshal.GetLastWin32Error();
                            logger?.LogError("[PrnPrinter] WritePrinter failed for '{PrinterName}' (Win32 error {Error})",
                                printerName, error);
                        }
                    }
                    finally
                    {
                        Marshal.FreeCoTaskMem(pUnmanagedBytes);
                    }

                    EndPagePrinter(hPrinter);
                }
                finally
                {
                    EndDocPrinter(hPrinter);
                }
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "[PrnPrinter] Error sending to printer '{PrinterName}'", printerName);
                return false;
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                    ClosePrinter(hPrinter);
            }

            return success;
        }

        public static List<PrintJobResult> SendBatchToPrinterByName(List<PrintJobItem> jobs, string jobFilePath, ILogger logger, FollowMeFreeDbContext db = null)
        {
            var results = new List<PrintJobResult>();

            foreach (var job in jobs)
            {
                var fullPath = Path.Combine(jobFilePath, job.FilePath);
                string datatype = !string.IsNullOrEmpty(job.Datatype)
                    ? job.Datatype
                    : PrintJobExtractor.ParseDatatypeFromFileName(job.FilePath);

                try
                {
                    logger.LogInformation("[PrnPrinter] Printing '{FilePath}' to '{Printer}'",
                        job.FilePath, job.TargetPrinterName);

                    bool success = SendToPrinterByName(job.TargetPrinterName, fullPath, datatype, db, logger);

                    results.Add(new PrintJobResult
                    {
                        PrinterName = job.TargetPrinterName,
                        FilePath = job.FilePath,
                        Success = success,
                        Message = success
                            ? $"Print job sent to '{job.TargetPrinterName}' successfully"
                            : $"Failed to send print job to '{job.TargetPrinterName}'"
                    });
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "[PrnPrinter] Error printing '{FilePath}' to '{Printer}'",
                        job.FilePath, job.TargetPrinterName);

                    results.Add(new PrintJobResult
                    {
                        PrinterName = job.TargetPrinterName,
                        FilePath = job.FilePath,
                        Success = false,
                        Message = $"Error: {ex.Message}"
                    });
                }
            }

            return results;
        }
    }
}
