using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class UserAccount
{
    public int UsacId { get; set; }

    public string? UsacAccountno { get; set; }

    public decimal? UsacDebet { get; set; }

    public decimal? UsacCredit { get; set; }

    public string? UsacType { get; set; }

    public int? UsacBankEntityid { get; set; }

    public int? UsacFintEntityid { get; set; }

    public int? UsacUserEntityid { get; set; }

    public virtual Bank? UsacBankEntity { get; set; }

    public virtual Fintech? UsacFintEntity { get; set; }

    public virtual User? UsacUserEntity { get; set; }
}
