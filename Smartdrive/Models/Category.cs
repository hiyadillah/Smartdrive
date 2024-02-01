using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Category
{
    public int CateId { get; set; }

    public string? CateName { get; set; }

    public virtual ICollection<TemplateInsurancePremi> TemplateInsurancePremis { get; set; } = new List<TemplateInsurancePremi>();
}
