using System;
using System.Collections.Generic;

namespace FollowMeFree.WorkerService.Data.Scaffolded;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int Pin { get; set; }

    public string? AllowedPrinterIds { get; set; }

    public virtual Department Department { get; set; } = null!;
}
