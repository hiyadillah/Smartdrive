using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class RegionPlat
{
    public string RegpName { get; set; } = null!;

    public string? RegpDesc { get; set; }

    public int? RegpProvId { get; set; }

    public virtual Provinsi? RegpProv { get; set; }
}
