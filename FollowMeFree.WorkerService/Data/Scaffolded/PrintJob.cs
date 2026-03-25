using System;
using System.Collections.Generic;

namespace FollowMeFree.WorkerService.Data.Scaffolded;

public partial class PrintJob
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string DocumentName { get; set; } = null!;

    public int JobId { get; set; }

    public int Pages { get; set; }

    public DateTime DateTimePrinted { get; set; }

    public string DataType { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
