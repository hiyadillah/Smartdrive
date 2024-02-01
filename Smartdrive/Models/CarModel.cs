using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CarModel
{
    public int CarmId { get; set; }

    public string? CarmName { get; set; }

    public int? CarmCabrId { get; set; }

    public virtual ICollection<CarSeries> CarSeries { get; set; } = new List<CarSeries>();

    public virtual CarBrand? CarmCabr { get; set; }
}
