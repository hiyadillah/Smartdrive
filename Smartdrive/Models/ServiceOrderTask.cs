using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class ServiceOrderTask
{
    public int SeotId { get; set; }

    public string? SeotName { get; set; }

    public DateTime? SeotStartdate { get; set; }

    public DateTime? SeotEnddate { get; set; }

    public DateTime? SeotActualStartdate { get; set; }

    public DateTime? SeotActualEnddate { get; set; }

    public string? SeotStatus { get; set; }

    public string? SeotArwgCode { get; set; }

    public string? SeotSeroId { get; set; }

    public virtual AreaWorkgroup? SeotArwgCodeNavigation { get; set; }

    public virtual ServiceOrder? SeotSero { get; set; }

    public virtual ICollection<ServiceOrderWorkorder> ServiceOrderWorkorders { get; set; } = new List<ServiceOrderWorkorder>();
}
