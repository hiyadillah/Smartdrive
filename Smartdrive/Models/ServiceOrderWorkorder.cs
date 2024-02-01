using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class ServiceOrderWorkorder
{
    public int SowoId { get; set; }

    public string? SowoName { get; set; }

    public DateTime? SowoModifiedDate { get; set; }

    public string? SowoStatus { get; set; }

    public int? SowoSeotId { get; set; }

    public virtual ServiceOrderTask? SowoSeot { get; set; }
}
