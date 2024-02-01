using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class TemplateServiceTask
{
    public int TestaId { get; set; }

    public string? TestaName { get; set; }

    public int? TestaTetyId { get; set; }

    public string? TestaGroup { get; set; }

    public string? TestaCallmethod { get; set; }

    public int? TestaSeqorder { get; set; }

    public virtual ICollection<TemplateTaskWorkorder> TemplateTaskWorkorders { get; set; } = new List<TemplateTaskWorkorder>();

    public virtual TemplateType? TestaTety { get; set; }
}
