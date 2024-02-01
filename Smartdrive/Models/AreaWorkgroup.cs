using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class AreaWorkgroup
{
    public string ArwgCode { get; set; } = null!;

    public string? ArwgDesc { get; set; }

    public int? ArwgCityId { get; set; }

    public virtual City? ArwgCity { get; set; }

    public virtual ICollection<EmployeeAreWorkgroup> EmployeeAreWorkgroups { get; set; } = new List<EmployeeAreWorkgroup>();

    public virtual ICollection<PartnerAreaWorkgroup> PartnerAreaWorkgroups { get; set; } = new List<PartnerAreaWorkgroup>();

    public virtual ICollection<ServiceOrderTask> ServiceOrderTasks { get; set; } = new List<ServiceOrderTask>();
}
