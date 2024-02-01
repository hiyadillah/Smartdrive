using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class TemplateTaskWorkorder
{
    public int TewoId { get; set; }

    public string? TewoName { get; set; }

    public string? TewoValue { get; set; }

    public int? TewoTestaId { get; set; }

    public virtual TemplateServiceTask? TewoTesta { get; set; }
}
