using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class TemplateInsurancePremi
{
    public int TemiId { get; set; }

    public string? TemiName { get; set; }

    public double? TemiRateMin { get; set; }

    public double? TemiRateMax { get; set; }

    public double? TemiNominal { get; set; }

    public string? TemiType { get; set; }

    public int? TemiZonesId { get; set; }

    public string? TemiIntyName { get; set; }

    public int? TemiCateId { get; set; }

    public virtual Category? TemiCate { get; set; }

    public virtual InsuranceType? TemiIntyNameNavigation { get; set; }

    public virtual Zone? TemiZones { get; set; }
}
