using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class ClaimAssetSparepart
{
    public int CaspId { get; set; }

    public string? CaspItemName { get; set; }

    public int? CaspQuantity { get; set; }

    public decimal? CaspItemPrice { get; set; }

    public decimal? CaspSubtotal { get; set; }

    public int? CaspPartEntityid { get; set; }

    public string? CaspSeroId { get; set; }

    public DateTime? CaspCreatedDate { get; set; }

    public virtual Partner? CaspPartEntity { get; set; }

    public virtual ServiceOrder? CaspSero { get; set; }
}
