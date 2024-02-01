using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class UserPhone
{
    public int UsphEntityid { get; set; }

    public string UsphPhoneNumber { get; set; } = null!;

    public string? UsphPhoneType { get; set; }

    public string? UsphMime { get; set; }

    public string? UsphStatus { get; set; }

    public DateTime? UsphModifiedDate { get; set; }

    public virtual User UsphEntity { get; set; } = null!;
}
