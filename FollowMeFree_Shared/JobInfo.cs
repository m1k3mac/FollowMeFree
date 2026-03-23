using System;

namespace FollowMeFree_Shared
{
    public class JobInfo
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string Submitter { get; set; }
        public string Status { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public int NumberOfPages { get; set; }
        public string Datatype { get; set; }
        public string FilePath { get; set; }
    }
}
