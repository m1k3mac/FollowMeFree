using System;
using System.Collections.Generic;

namespace FollowMeFree.WorkerService.Data.Scaffolded;

public partial class Department
{
    public int Id { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<PrintJob> PrintJobs { get; set; } = new List<PrintJob>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
