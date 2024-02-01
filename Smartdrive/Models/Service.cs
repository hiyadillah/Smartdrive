using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Service
{
    public int ServId { get; set; }

    public DateTime? ServCreatedOn { get; set; }

    public string? ServType { get; set; }

    public string? ServInsuranceNo { get; set; }

    public string? ServVehicleNo { get; set; }

    public DateTime? ServStartdate { get; set; }

    public DateTime? ServEnddate { get; set; }

    public string? ServStatus { get; set; }

    public int? ServServId { get; set; }

    public int? ServCustEntityid { get; set; }

    public int? ServCreqEntityid { get; set; }

    public virtual ICollection<Service> InverseServServ { get; set; } = new List<Service>();

    public virtual CustomerRequest? ServCreqEntity { get; set; }

    public virtual User? ServCustEntity { get; set; }

    public virtual Service? ServServ { get; set; }

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ServicePremi? ServicePremi { get; set; }

    public virtual ICollection<ServicePremiCredit> ServicePremiCredits { get; set; } = new List<ServicePremiCredit>();
}
