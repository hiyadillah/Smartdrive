using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class InsuranceType
{
    public string IntyName { get; set; } = null!;

    public string? IntyDesc { get; set; }

    public virtual ICollection<CustomerInscAsset> CustomerInscAssets { get; set; } = new List<CustomerInscAsset>();

    public virtual ICollection<TemplateInsurancePremi> TemplateInsurancePremis { get; set; } = new List<TemplateInsurancePremi>();
}
