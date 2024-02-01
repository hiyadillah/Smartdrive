using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class EmployeeSalaryDetail
{
    public int EmsaId { get; set; }

    public int EmsaEmpEntityid { get; set; }

    public DateTime EmsaCreateDate { get; set; }

    public string? EmsaName { get; set; }

    public decimal? EmsaSubtotal { get; set; }

    public virtual Employee EmsaEmpEntity { get; set; } = null!;
}
