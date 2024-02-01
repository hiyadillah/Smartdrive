using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CarBrand
{
    public int CabrId { get; set; }

    public string? CabrName { get; set; }

    public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
}
