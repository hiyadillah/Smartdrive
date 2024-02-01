using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CustomerClaim
{
    public int CuclCreqEntityid { get; set; }

    public int? CuclEvents { get; set; }

    public DateTime? CuclCreateDate { get; set; }

    public decimal? CuclEventPrice { get; set; }

    public decimal? CuclSubtotal { get; set; }

    public string? CuclReason { get; set; }

    public virtual CustomerRequest CuclCreqEntity { get; set; } = null!;
}
