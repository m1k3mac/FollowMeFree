using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Printing;

// This class provides functionality to extract print jobs from a specified printer queue,

namespace FollowMeFree.WorkerService
{
    public class PrintJobExtractor
    {
        private readonly string _printerName;

        #region Win32 Spooler API

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool OpenPrinter(string pPrinterName, out IntPtr phPrinter, IntPtr pDefault);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", SetLastError = true)]
        private static extern bool ReadPrinter(IntPtr hPrinter, byte[] pBuf, int cbBuf, out int pcRead);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool GetJob(IntPtr hPrinter, uint JobId, uint Level, IntPtr pJob, uint cbBuf, out uint pcbNeeded);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct JOB_INFO_1
        {
            public uint JobId;
            public string pPrinterName;
            public string pMachineName;
            public string pUserName;
            public string pDocument;
            public string pDatatype;
            public string pStatus;
            public uint Status;
            public uint Priority;
            public uint Position;
            public uint TotalPages;
            public uint PagesPrinted;
            public SYSTEMTIME Submitted;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        #endregion

        
        public PrintJobExtractor(string printerName)
        {
            _printerName = printerName ?? throw new ArgumentNullException(nameof(printerName));

            using (var printServer = new LocalPrintServer())
            using (var queue = printServer.GetPrintQueue(_printerName))
            {
                queue.Refresh();
                if (!queue.IsPaused)
                {
                    try
                    {
                        queue.Pause();
                        Console.WriteLine($"[PrintJobExtractor] Printer '{_printerName}' was not paused. Pausing now.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[PrintJobExtractor] Failed to pause printer '{_printerName}': {ex.Message}");
                        Console.WriteLine($"[PrintJobExtractor] Please either grant the application appropriate printer management permissions, or manually pause the printer '{_printerName}' before running this service.");
                        throw new InvalidOperationException(
                            $"Unable to pause printer '{_printerName}'. Please grant the appropriate printer permissions or manually pause the printer before starting the service.",
                            ex);
                    }
                }
            }
        }        
        
        public List<PrintJobSnapshot> FindJobsByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));

            var results = new List<PrintJobSnapshot>();

            using (var printServer = new LocalPrintServer())
            using (var queue = printServer.GetPrintQueue(_printerName))
            {
                queue.Refresh();
                var jobs = queue.GetPrintJobInfoCollection();
                if (jobs == null) return results;

                foreach (PrintSystemJobInfo job in jobs)
                {
                    job.Refresh();
                    if (string.Equals(job.Submitter, username, StringComparison.OrdinalIgnoreCase))
                    {
                        var details = GetJobDetails(job.JobIdentifier);
                        results.Add(new PrintJobSnapshot
                        {
                            JobId = job.JobIdentifier,
                            JobName = details.DocumentName ?? job.JobName,
                            Submitter = job.Submitter,
                            Status = MapJobStatus(job.JobStatus),
                            TimeSubmitted = job.TimeJobSubmitted,
                            NumberOfPages = job.NumberOfPages,
                            Datatype = details.Datatype
                        });
                    }
                }
            }

            Console.WriteLine($"[PrintJobExtractor] Found {results.Count} job(s) for user '{username}'");
            return results;
        }
        
        public bool ExtractAndRemoveJob(int jobId, string outputFilePath)
        {
            if (string.IsNullOrEmpty(outputFilePath))
                throw new ArgumentNullException(nameof(outputFilePath));

            // Step 1: Read raw spool data via Win32 API
            byte[] spoolData = ReadSpoolData(jobId);
            if (spoolData == null || spoolData.Length == 0)
            {
                Console.WriteLine($"[PrintJobExtractor] No spool data for job #{jobId}");
                return false;
            }

            // Step 2: Save to file
            try
            {
                string directory = Path.GetDirectoryName(outputFilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllBytes(outputFilePath, spoolData);
                Console.WriteLine($"[PrintJobExtractor] Saved job #{jobId} to {outputFilePath} ({spoolData.Length:N0} bytes)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PrintJobExtractor] Failed to save job #{jobId}: {ex.Message}");
                return false;
            }

            // Step 3: Remove from queue
            return CancelJob(jobId);
        }
        
        public Task<bool> ExtractAndRemoveJobAsync(int jobId, string outputFilePath)
        {
            return Task.Run(() => ExtractAndRemoveJob(jobId, outputFilePath));
        }
        
        public List<PrintJobSnapshot> ExtractJobsByUsername(string username, string outputFolder)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrEmpty(outputFolder))
                throw new ArgumentNullException(nameof(outputFolder));

            var savedJobs = new List<PrintJobSnapshot>();
            var jobs = FindJobsByUsername(username);

            if (jobs.Count == 0)
            {
                Console.WriteLine($"[PrintJobExtractor] No jobs found for user '{username}'");
                return savedJobs;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            foreach (var job in jobs)
            {
                string safeDocName = SanitizeFileName(job.JobName ?? $"unknown");
                string pages = job.NumberOfPages.ToString();
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string safeDatatype = SanitizeFileName(job.Datatype ?? "RAW");
                string fileName = $"{username};{safeDocName};{pages};{timestamp};{job.JobId};{safeDatatype}.prn";
                string outputPath = Path.Combine(outputFolder, fileName);

                if (ExtractAndRemoveJob(job.JobId, outputPath))
                {
                    job.OutputFilePath = outputPath;
                    savedJobs.Add(job);
                }
            }

            Console.WriteLine($"[PrintJobExtractor] Extracted {savedJobs.Count}/{jobs.Count} job(s) for user '{username}'");
            return savedJobs;
        }
        
        public List<PrintJobSnapshot> ExtractAllJobs(string outputFolder)
        {
            if (string.IsNullOrEmpty(outputFolder))
                throw new ArgumentNullException(nameof(outputFolder));

            var savedJobs = new List<PrintJobSnapshot>();
            var allJobs = new List<PrintJobSnapshot>();

            using (var printServer = new LocalPrintServer())
            using (var queue = printServer.GetPrintQueue(_printerName))
            {
                queue.Refresh();
                var jobs = queue.GetPrintJobInfoCollection();
                if (jobs == null) return savedJobs;

                foreach (PrintSystemJobInfo job in jobs)
                {
                    job.Refresh();

                    if ((job.JobStatus & System.Printing.PrintJobStatus.Spooling) == System.Printing.PrintJobStatus.Spooling)
                    {
                        Console.WriteLine($"[PrintJobExtractor] Skipping job #{job.JobIdentifier} (still spooling)");
                        continue;
                    }

                    var details = GetJobDetails(job.JobIdentifier);
                    allJobs.Add(new PrintJobSnapshot
                    {
                        JobId = job.JobIdentifier,
                        JobName = details.DocumentName ?? job.JobName,
                        Submitter = job.Submitter,
                        Status = MapJobStatus(job.JobStatus),
                        TimeSubmitted = job.TimeJobSubmitted,
                        NumberOfPages = job.NumberOfPages,
                        Datatype = details.Datatype
                    });
                }
            }

            if (allJobs.Count == 0)
            {
                Console.WriteLine("[PrintJobExtractor] No extractable jobs in queue");
                return savedJobs;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            foreach (var job in allJobs)
            {
                string safeSubmitter = SanitizeFileName(job.Submitter ?? "unknown");
                string safeDocName = SanitizeFileName(job.JobName ?? "unknown");
                string pages = job.NumberOfPages.ToString();
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string safeDatatype = SanitizeFileName(job.Datatype ?? "RAW");
                string fileName = $"{safeSubmitter};{safeDocName};{pages};{timestamp};{job.JobId};{safeDatatype}.prn";
                string outputPath = Path.Combine(outputFolder, fileName);

                if (ExtractAndRemoveJob(job.JobId, outputPath))
                {
                    job.OutputFilePath = outputPath;
                    savedJobs.Add(job);
                }
            }

            Console.WriteLine($"[PrintJobExtractor] Extracted {savedJobs.Count}/{allJobs.Count} job(s) from queue");
            return savedJobs;
        }

        /// <summary>
        /// Asynchronously extracts all jobs from the printer queue, saves each to the output folder,
        /// and removes them from the queue.
        /// </summary>
        /// <param name="outputFolder">Folder where extracted PRN files will be saved.</param>
        /// <returns>A list of snapshots for successfully extracted jobs, with OutputFilePath set.</returns>
        public Task<List<PrintJobSnapshot>> ExtractAllJobsAsync(string outputFolder)
        {
            return Task.Run(() => ExtractAllJobs(outputFolder));
        }

        #region Private helpers

        /// <summary>
        /// Retrieves the document name and spool datatype for a print job using the Win32 GetJob API.
        /// The document name is the actual name shown in the print queue (e.g. "test.txt - Notepad").
        /// The datatype indicates the spool format (e.g. "RAW", "NT EMF 1.008").
        /// </summary>
        private (string DocumentName, string Datatype) GetJobDetails(int jobId)
        {
            IntPtr hPrinter = IntPtr.Zero;
            try
            {
                if (!OpenPrinter(_printerName, out hPrinter, IntPtr.Zero))
                    return (null, null);

                uint needed;
                GetJob(hPrinter, (uint)jobId, 1, IntPtr.Zero, 0, out needed);
                if (needed == 0)
                    return (null, null);

                IntPtr buffer = Marshal.AllocHGlobal((int)needed);
                try
                {
                    if (GetJob(hPrinter, (uint)jobId, 1, buffer, needed, out needed))
                    {
                        var jobInfo = (JOB_INFO_1)Marshal.PtrToStructure(buffer, typeof(JOB_INFO_1));
                        return (jobInfo.pDocument, jobInfo.pDatatype);
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PrintJobExtractor] GetJobDetails failed for job #{jobId}: {ex.Message}");
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                    ClosePrinter(hPrinter);
            }

            return (null, null);
        }

        /// <summary>
        /// Opens a handle to the specific print job and reads the raw spool data.
        /// </summary>
        private byte[] ReadSpoolData(int jobId)
        {
            // Opening "PrinterName, Job N" gives a handle to the raw job data
            string jobPrinterName = $"{_printerName}, Job {jobId}";
            IntPtr hPrinter = IntPtr.Zero;

            try
            {
                if (!OpenPrinter(jobPrinterName, out hPrinter, IntPtr.Zero))
                {
                    int error = Marshal.GetLastWin32Error();
                    Console.WriteLine($"[PrintJobExtractor] OpenPrinter failed for job #{jobId} (Win32 error {error})");
                    return null;
                }

                const int bufferSize = 65536;
                byte[] buffer = new byte[bufferSize];

                using (var ms = new MemoryStream())
                {
                    int bytesRead;
                    while (ReadPrinter(hPrinter, buffer, bufferSize, out bytesRead) && bytesRead > 0)
                    {
                        ms.Write(buffer, 0, bytesRead);
                    }

                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PrintJobExtractor] Error reading spool data for job #{jobId}: {ex.Message}");
                return null;
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                {
                    ClosePrinter(hPrinter);
                }
            }
        }

        /// <summary>
        /// Cancels and removes a job from the printer queue.
        /// </summary>
        private bool CancelJob(int jobId)
        {
            try
            {
                using (var printServer = new LocalPrintServer())
                using (var queue = printServer.GetPrintQueue(_printerName))
                {
                    queue.Refresh();
                    var jobs = queue.GetPrintJobInfoCollection();
                    if (jobs == null) return false;

                    foreach (PrintSystemJobInfo job in jobs)
                    {
                        if (job.JobIdentifier == jobId)
                        {
                            job.Cancel();
                            Console.WriteLine($"[PrintJobExtractor] Cancelled job #{jobId} from queue");
                            return true;
                        }
                    }
                }

                Console.WriteLine($"[PrintJobExtractor] Job #{jobId} not found in queue");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[PrintJobExtractor] Failed to cancel job #{jobId}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Maps System.Printing.PrintJobStatus flags to the local PrintJobStatus enum.
        /// </summary>
        private static PrintJobStatus MapJobStatus(System.Printing.PrintJobStatus status)
        {
            if ((status & System.Printing.PrintJobStatus.Error) != 0)
                return PrintJobStatus.Error;
            if ((status & System.Printing.PrintJobStatus.Deleting) != 0)
                return PrintJobStatus.Deleted;
            if ((status & System.Printing.PrintJobStatus.Paused) != 0)
                return PrintJobStatus.Paused;
            if ((status & System.Printing.PrintJobStatus.Printing) != 0)
                return PrintJobStatus.Printing;
            if ((status & System.Printing.PrintJobStatus.Completed) != 0)
                return PrintJobStatus.Completed;
            return PrintJobStatus.None;
        }

        /// <summary>
        /// Removes invalid file name characters from a string.
        /// </summary>
        private static string SanitizeFileName(string name)
        {
            char[] invalid = Path.GetInvalidFileNameChars();
            foreach (char c in invalid)
            {
                name = name.Replace(c, '_');
            }
            return name;
        }

        /// <summary>
        /// Parses the datatype from a PRN filename that uses the naming convention:
        /// submitter;docname;pages;timestamp;jobId;datatype.prn
        /// Returns "RAW" if the datatype segment is missing or the filename doesn't match the convention.
        /// </summary>
        public static string ParseDatatypeFromFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "RAW";

            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            string[] parts = nameWithoutExt.Split(';');
            if (parts.Length >= 6 && !string.IsNullOrWhiteSpace(parts[5]))
                return parts[5];

            return "RAW";
        }

        #endregion
    }
}
