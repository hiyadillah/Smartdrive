using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class ClaimAssetEvidence
{
    public int CaevId { get; set; }

    public string? CaevFilename { get; set; }

    public int? CaevFilesize { get; set; }

    public string? CaevFiletype { get; set; }

    public string? CaevUrl { get; set; }

    public string? CaevNote { get; set; }

    public int? CaevPartEntityid { get; set; }

    public string? CaevSeroId { get; set; }

    public decimal? CaevServiceFee { get; set; }

    public DateTime? CaevCreatedDate { get; set; }

    public virtual Partner? CaevPartEntity { get; set; }

    public virtual ServiceOrder? CaevSero { get; set; }
}
