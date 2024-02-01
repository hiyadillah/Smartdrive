using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Employee
{
    public int EmpEntityid { get; set; }

    public string? EmpName { get; set; }

    public DateTime? EmpJoinDate { get; set; }

    public string? EmpType { get; set; }

    public string? EmpStatus { get; set; }

    public string? EmpGraduate { get; set; }

    public decimal? EmpNetSalary { get; set; }

    public string? EmpAccountNumber { get; set; }

    public DateTime? EmpModifiedDate { get; set; }

    public string? EmpJobCode { get; set; }

    public virtual User EmpEntity { get; set; } = null!;

    public virtual JobType? EmpJobCodeNavigation { get; set; }

    public virtual ICollection<EmployeeAreWorkgroup> EmployeeAreWorkgroups { get; set; } = new List<EmployeeAreWorkgroup>();

    public virtual ICollection<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; } = new List<EmployeeSalaryDetail>();
}
