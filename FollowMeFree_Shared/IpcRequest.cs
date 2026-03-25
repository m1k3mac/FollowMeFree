namespace FollowMeFree_Shared
{
    public class IpcRequest
    {
        public string Command { get; set; }  // "GetJobs", "ReleaseJob", "PrinterStatus", "PrintJob", "PrintJobs"
        public string Username { get; set; }
        public int? JobId { get; set; }
        public string TargetPrinterIp { get; set; }
        public string TargetPrinterName { get; set; }
        public string FilePath { get; set; }
        public string Datatype { get; set; }
        public List<PrintJobItem> PrintJobs { get; set; }
    }

    public class PrintJobItem
    {
        public string TargetPrinterName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string Datatype { get; set; }
    }

    public class PrintJobResult
    {
        public string PrinterName { get; set; }
        public string FilePath { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
