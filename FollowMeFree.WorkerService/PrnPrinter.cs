using System;
using System.IO;
using System.Runtime.InteropServices;

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
        
        public static bool SendToPrinterByName(string printerName, string filePath, string datatype = "RAW")
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
                    Console.WriteLine($"[PrnPrinter] OpenPrinter failed for '{printerName}' (Win32 error {error})");
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
                    Console.WriteLine($"[PrnPrinter] StartDocPrinter failed (Win32 error {error})");
                    return false;
                }

                try
                {
                    if (!StartPagePrinter(hPrinter))
                    {
                        int error = Marshal.GetLastWin32Error();
                        Console.WriteLine($"[PrnPrinter] StartPagePrinter failed (Win32 error {error})");
                        return false;
                    }

                    IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem(fileData.Length);
                    try
                    {
                        Marshal.Copy(fileData, 0, pUnmanagedBytes, fileData.Length);
                        if (WritePrinter(hPrinter, pUnmanagedBytes, fileData.Length, out int bytesWritten))
                        {
                            success = bytesWritten == fileData.Length;
                            Console.WriteLine($"[PrnPrinter] Sent {bytesWritten:N0} bytes to '{printerName}'");
                        }
                        else
                        {
                            int error = Marshal.GetLastWin32Error();
                            Console.WriteLine($"[PrnPrinter] WritePrinter failed (Win32 error {error})");
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
                Console.WriteLine($"[PrnPrinter] Error sending to printer '{printerName}': {ex.Message}");
                return false;
            }
            finally
            {
                if (hPrinter != IntPtr.Zero)
                    ClosePrinter(hPrinter);
            }

            return success;
        }
    }
}
