using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class BatchEmployeeSalary
{
    public int BesaEmpEntityId { get; set; }

    public DateTime BesaCreatedDate { get; set; }

    public DateTime? EmsTrasferDate { get; set; }

    public decimal? BesaTotalSalary { get; set; }

    public string? BesaAccountNumber { get; set; }

    public string? BesaStatus { get; set; }

    public string? BesaPatrTrxno { get; set; }

    public DateTime? BesaPaidDate { get; set; }

    public DateTime? BesaModifiedDate { get; set; }
}
