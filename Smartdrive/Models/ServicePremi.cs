using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class ServicePremi
{
    public int SemiServId { get; set; }

    public decimal? SemiPremiDebet { get; set; }

    public decimal? SemiPremiCredit { get; set; }

    public string? SemiPaidType { get; set; }

    public string? SemiStatus { get; set; }

    public DateTime? SemiModifiedDate { get; set; }

    public virtual Service SemiServ { get; set; } = null!;
}
