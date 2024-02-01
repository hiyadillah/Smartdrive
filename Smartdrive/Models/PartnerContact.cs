using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class PartnerContact
{
    public int PacoPatrnEntityid { get; set; }

    public int PacoUserEntityid { get; set; }

    public string? PacoStatus { get; set; }

    public virtual Partner PacoPatrnEntity { get; set; } = null!;

    public virtual User PacoUserEntity { get; set; } = null!;

    public virtual ICollection<PartnerAreaWorkgroup> PartnerAreaWorkgroups { get; set; } = new List<PartnerAreaWorkgroup>();
}
