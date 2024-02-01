using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? CityProvId { get; set; }

    public virtual ICollection<AreaWorkgroup> AreaWorkgroups { get; set; } = new List<AreaWorkgroup>();

    public virtual Provinsi? CityProv { get; set; }

    public virtual ICollection<CustomerInscAsset> CustomerInscAssets { get; set; } = new List<CustomerInscAsset>();

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}
