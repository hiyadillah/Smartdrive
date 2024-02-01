using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class BatchPartnerInvoice
{
    public string BpinInvoiceNo { get; set; } = null!;

    public DateTime? BpinCreatedOn { get; set; }

    public decimal? BpinSubtotal { get; set; }

    public decimal? BpinTax { get; set; }

    public string? BpinAccountNo { get; set; }

    public string? BpinStatus { get; set; }

    public DateTime? BpinPaidDate { get; set; }

    public int? BpinPatrnEntityid { get; set; }

    public string? BpinPatrTrxno { get; set; }

    public string BpinSeroId { get; set; } = null!;

    public virtual PaymentTransaction? BpinPatrTrxnoNavigation { get; set; }

    public virtual Partner? BpinPatrnEntity { get; set; }

    public virtual ServiceOrder BpinSero { get; set; } = null!;
}
