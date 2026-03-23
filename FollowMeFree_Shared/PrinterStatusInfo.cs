namespace FollowMeFree_Shared
{
    public class PrinterStatusInfo
    {
        public string PrinterName { get; set; }
        public bool IsPaused { get; set; }
        public int QueuedJobCount { get; set; }
        public int ExtractedJobCount { get; set; }
    }
}
