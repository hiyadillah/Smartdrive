using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Bank
{
    public int BankEntityid { get; set; }

    public string? BankName { get; set; }

    public string? BankDesc { get; set; }

    public virtual BusinessEntity BankEntity { get; set; } = null!;

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
