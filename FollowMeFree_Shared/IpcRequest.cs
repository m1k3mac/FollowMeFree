namespace FollowMeFree_Shared
{
    public class IpcRequest
    {
        public string Command { get; set; }  // "GetJobs", "ReleaseJob", "PrinterStatus"
        public string Username { get; set; }
        public int? JobId { get; set; }
        public string TargetPrinterIp { get; set; }
        public string TargetPrinterName { get; set; }
    }
}
