using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Provinsi
{
    public int ProvId { get; set; }

    public string? ProvName { get; set; }

    public int? ProvZonesId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Zone? ProvZones { get; set; }

    public virtual ICollection<RegionPlat> RegionPlats { get; set; } = new List<RegionPlat>();
}
