using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Zone
{
    public int ZonesId { get; set; }

    public string? ZonesName { get; set; }

    public virtual ICollection<Provinsi> Provinsis { get; set; } = new List<Provinsi>();

    public virtual ICollection<TemplateInsurancePremi> TemplateInsurancePremis { get; set; } = new List<TemplateInsurancePremi>();
}
