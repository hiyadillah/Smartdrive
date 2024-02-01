using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CustomerInscExtend
{
    public int CuexId { get; set; }

    public int CuexCreqEntityid { get; set; }

    public string? CuexName { get; set; }

    public int? CuexTotalItem { get; set; }

    public decimal? CuexNominal { get; set; }

    public virtual CustomerInscAsset CuexCreqEntity { get; set; } = null!;
}
