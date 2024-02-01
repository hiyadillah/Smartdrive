using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class CustomerInscAsset
{
    public int CiasCreqEntityid { get; set; }

    public string CiasPoliceNumber { get; set; } = null!;

    public string CiasYear { get; set; } = null!;

    public DateTime? CiasStartdate { get; set; }

    public DateTime? CiasEnddate { get; set; }

    public decimal? CiasCurrentPrice { get; set; }

    public decimal? CiasInsurancePrice { get; set; }

    public decimal? CiasTotalPremi { get; set; }

    public string? CiasPaidType { get; set; }

    public string? CiasIsNewChar { get; set; }

    public int? CiasCarsId { get; set; }

    public string? CiasIntyName { get; set; }

    public int? CiasCityId { get; set; }

    public virtual CarSeries? CiasCars { get; set; }

    public virtual City? CiasCity { get; set; }

    public virtual CustomerRequest CiasCreqEntity { get; set; } = null!;

    public virtual InsuranceType? CiasIntyNameNavigation { get; set; }

    public virtual ICollection<CustomerInscDoc> CustomerInscDocs { get; set; } = new List<CustomerInscDoc>();

    public virtual ICollection<CustomerInscExtend> CustomerInscExtends { get; set; } = new List<CustomerInscExtend>();
}
