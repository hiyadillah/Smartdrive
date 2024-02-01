using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class RefreshToken
{
    public int RetoId { get; set; }

    public int? RetoUserId { get; set; }

    public string? RetoToken { get; set; }

    public DateTime? RetoExpireDate { get; set; }

    public virtual User? RetoUser { get; set; }
}
