using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class TemplateType
{
    public int TetyId { get; set; }

    public string? TetyName { get; set; }

    public string? TetyGroup { get; set; }

    public virtual ICollection<TemplateServiceTask> TemplateServiceTasks { get; set; } = new List<TemplateServiceTask>();
}
