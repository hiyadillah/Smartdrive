using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CustomerRequest
{
    public int CreqEntityid { get; set; }

    public DateTime? CreqCreateDate { get; set; }

    public string? CreqStatus { get; set; }

    public string? CreqType { get; set; }

    public DateTime? CreqModifiedDate { get; set; }

    public int? CreqCustEntityid { get; set; }

    public int? CreqAgenEntityid { get; set; }

    public virtual EmployeeAreWorkgroup? CreqAgenEntity { get; set; }

    public virtual User? CreqCustEntity { get; set; }

    public virtual BusinessEntity CreqEntity { get; set; } = null!;

    public virtual CustomerClaim? CustomerClaim { get; set; }

    public virtual CustomerInscAsset? CustomerInscAsset { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
