using System;
using System.Collections.Generic;

namespace FollowMeFree.WorkerService.Data.Scaffolded;

public partial class Log
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; }

    public string LogLevel { get; set; } = null!;

    public string Source { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? Exception { get; set; }
}
