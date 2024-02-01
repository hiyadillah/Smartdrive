using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class Partner
{
    public int PartEntityid { get; set; }

    public string? PartName { get; set; }

    public string? PartAddress { get; set; }

    public DateTime? PartJoinDate { get; set; }

    public string? PartAccountNo { get; set; }

    public string? PartNpwp { get; set; }

    public string? PartStatus { get; set; }

    public DateTime? PartModifiedDate { get; set; }

    public int PartCityId { get; set; }

    public virtual ICollection<BatchPartnerInvoice> BatchPartnerInvoices { get; set; } = new List<BatchPartnerInvoice>();

    public virtual ICollection<ClaimAssetEvidence> ClaimAssetEvidences { get; set; } = new List<ClaimAssetEvidence>();

    public virtual ICollection<ClaimAssetSparepart> ClaimAssetSpareparts { get; set; } = new List<ClaimAssetSparepart>();

    public virtual City PartCity { get; set; } = null!;

    public virtual BusinessEntity PartEntity { get; set; } = null!;

    public virtual ICollection<PartnerContact> PartnerContacts { get; set; } = new List<PartnerContact>();

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}
