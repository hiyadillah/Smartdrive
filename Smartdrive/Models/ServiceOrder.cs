using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class ServiceOrder
{
    public string SeroId { get; set; } = null!;

    public string? SeroOrdtType { get; set; }

    public string? SeroStatus { get; set; }

    public string? SeroReason { get; set; }

    public string? ServClaimNo { get; set; }

    public DateTime? ServClaimStartdate { get; set; }

    public DateTime? ServClaimEnddate { get; set; }

    public int? SeroServId { get; set; }

    public string? SeroSeroId { get; set; }

    public int? SeroAgentEntityid { get; set; }

    public int? SeroPartId { get; set; }

    public virtual ICollection<BatchPartnerInvoice> BatchPartnerInvoices { get; set; } = new List<BatchPartnerInvoice>();

    public virtual ICollection<ClaimAssetEvidence> ClaimAssetEvidences { get; set; } = new List<ClaimAssetEvidence>();

    public virtual ICollection<ClaimAssetSparepart> ClaimAssetSpareparts { get; set; } = new List<ClaimAssetSparepart>();

    public virtual ICollection<ServiceOrder> InverseSeroSero { get; set; } = new List<ServiceOrder>();

    public virtual EmployeeAreWorkgroup? SeroAgentEntity { get; set; }

    public virtual Partner? SeroPart { get; set; }

    public virtual ServiceOrder? SeroSero { get; set; }

    public virtual Service? SeroServ { get; set; }

    public virtual ICollection<ServiceOrderTask> ServiceOrderTasks { get; set; } = new List<ServiceOrderTask>();
}
