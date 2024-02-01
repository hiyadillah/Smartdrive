using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class EmployeeAreWorkgroup
{
    public int EawgId { get; set; }

    public int EawgEntityid { get; set; }

    public string? EawgStatus { get; set; }

    public string? EawgArwgCode { get; set; }

    public DateTime? EawgModifiedDate { get; set; }

    public virtual ICollection<CustomerRequest> CustomerRequests { get; set; } = new List<CustomerRequest>();

    public virtual AreaWorkgroup? EawgArwgCodeNavigation { get; set; }

    public virtual Employee EawgEntity { get; set; } = null!;

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}
