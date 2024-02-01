using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CarSeries
{
    public int CarsId { get; set; }

    public string? CarsName { get; set; }

    public int? CarsPassenger { get; set; }

    public int? CarsCarmId { get; set; }

    public virtual CarModel? CarsCarm { get; set; }

    public virtual ICollection<CustomerInscAsset> CustomerInscAssets { get; set; } = new List<CustomerInscAsset>();
}
