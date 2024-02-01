using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class TemplateSalary
{
    public int TesalId { get; set; }

    public string? TesalName { get; set; }

    public decimal? TesalNominal { get; set; }

    public double? TesalRateMin { get; set; }

    public double? TesalRateMax { get; set; }
}
