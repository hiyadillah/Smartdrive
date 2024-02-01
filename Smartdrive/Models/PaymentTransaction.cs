using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class PaymentTransaction
{
    public string PatrTrxno { get; set; } = null!;

    public DateTime? PatrCreatedOn { get; set; }

    public decimal? PatrDebet { get; set; }

    public decimal? PatrCredit { get; set; }

    public string? PatrUsacAccountNoFrom { get; set; }

    public string? PatrUsacAccountNoTo { get; set; }

    public string? PatrType { get; set; }

    public string? PatrInvoiceNo { get; set; }

    public string? PatrNotes { get; set; }

    public string? PatrTrxnoRev { get; set; }

    public virtual ICollection<BatchPartnerInvoice> BatchPartnerInvoices { get; set; } = new List<BatchPartnerInvoice>();

    public virtual ICollection<PaymentTransaction> InversePatrTrxnoRevNavigation { get; set; } = new List<PaymentTransaction>();

    public virtual PaymentTransaction? PatrTrxnoRevNavigation { get; set; }

    public virtual ICollection<ServicePremiCredit> ServicePremiCredits { get; set; } = new List<ServicePremiCredit>();
}
