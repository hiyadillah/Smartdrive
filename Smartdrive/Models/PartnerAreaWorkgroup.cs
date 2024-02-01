using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class PartnerAreaWorkgroup
{
    public int PawoPatrEntityid { get; set; }

    public string PawoArwgCode { get; set; } = null!;

    public int PawoUserEntityid { get; set; }

    public string? PawoStatus { get; set; }

    public DateTime? PawoModifiedDate { get; set; }

    public virtual PartnerContact Pawo { get; set; } = null!;

    public virtual AreaWorkgroup PawoArwgCodeNavigation { get; set; } = null!;
}
