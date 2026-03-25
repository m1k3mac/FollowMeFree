using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

// This class represents the model of a print job.

namespace FollowMeFree.WorkerService
{
    public class PrintJobSnapshot
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string Submitter { get; set; }
        public PrintJobStatus Status { get; set; }
        public DateTime TimeSubmitted { get; set; }
        public int NumberOfPages { get; set; }
        public string Datatype { get; set; }
        public string OutputFilePath { get; set; }

        public override string ToString()
        {
            return $"Job #{JobId} | {Submitter} | {JobName} | {NumberOfPages} page(s) | {Status} | {Datatype} | Submitted: {TimeSubmitted}";
        }
    }
}
