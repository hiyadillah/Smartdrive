using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class UserAddress
{
    public int UsdrId { get; set; }

    public int UsdrEntityid { get; set; }

    public string? UsdrAddress1 { get; set; }

    public string? UsdrAddress2 { get; set; }

    public DateTime? UsdrModifiedDate { get; set; }

    public int? UsdrCityId { get; set; }

    public virtual City? UsdrCity { get; set; }

    public virtual User UsdrEntity { get; set; } = null!;
}
