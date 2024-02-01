using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class ServicePremiCredit
{
    public int SecrId { get; set; }

    public int SecrServId { get; set; }

    public string? SecrYear { get; set; }

    public decimal? SecrPremiDebet { get; set; }

    public decimal? SecrPremiCredit { get; set; }

    public DateTime? SecrTrxDate { get; set; }

    public DateTime? SecrDuedate { get; set; }

    public string? SecrPatrTrxno { get; set; }

    public virtual PaymentTransaction? SecrPatrTrxnoNavigation { get; set; }

    public virtual Service SecrServ { get; set; } = null!;
}
