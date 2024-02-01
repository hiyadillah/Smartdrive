using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Fintech
{
    public int FintEntityid { get; set; }

    public string? FintName { get; set; }

    public string? FintDesc { get; set; }

    public virtual BusinessEntity FintEntity { get; set; } = null!;

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
