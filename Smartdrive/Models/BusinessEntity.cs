using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class BusinessEntity
{
    public int Entityid { get; set; }

    public DateTime EntityModifiedDate { get; set; }

    public virtual Bank? Bank { get; set; }

    public virtual CustomerRequest? CustomerRequest { get; set; }

    public virtual Fintech? Fintech { get; set; }

    public virtual Partner? Partner { get; set; }

    public virtual User? User { get; set; }
}
