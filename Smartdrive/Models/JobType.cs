using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class JobType
{
    public string JobCode { get; set; } = null!;

    public DateTime? JobModifiedDate { get; set; }

    public string? JobDesc { get; set; }

    public decimal? JobRateMin { get; set; }

    public decimal? JobRateMax { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
