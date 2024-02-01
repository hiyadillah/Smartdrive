using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class UserRole
{
    public int UsroEntityid { get; set; }

    public string UsroRoleName { get; set; } = null!;

    public string? UsroStatus { get; set; }

    public DateTime? UsroModifiedDate { get; set; }

    public virtual User UsroEntity { get; set; } = null!;

    public virtual Role UsroRoleNameNavigation { get; set; } = null!;
}
