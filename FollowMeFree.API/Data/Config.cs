using System;
using System.Collections.Generic;

namespace FollowMeFree.API.Data;

public partial class Config
{
    public int Id { get; set; }

    public string? JobFilePath { get; set; }

    public string FmfprinterName { get; set; } = null!;

    public string? ApiallowedNetwork { get; set; }
}
