using System;
using System.Collections.Generic;

namespace Smartdrive.Models;

public partial class User
{
    public int UserEntityid { get; set; }

    public string? UserName { get; set; }

    public string? UserPassword { get; set; }

    public string? UserFullName { get; set; }

    public string UserEmail { get; set; } = null!;

    public string? UserBirthPlace { get; set; }

    public DateTime? UserBirthDate { get; set; }

    public string UserNationalId { get; set; } = null!;

    public string? UserNpwp { get; set; }

    public string? UserPhoto { get; set; }

    public DateTime? UserModifiedDate { get; set; }

    public virtual ICollection<CustomerRequest> CustomerRequests { get; set; } = new List<CustomerRequest>();

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<PartnerContact> PartnerContacts { get; set; } = new List<PartnerContact>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

    public virtual BusinessEntity UserEntity { get; set; } = null!;

    public virtual ICollection<UserPhone> UserPhones { get; set; } = new List<UserPhone>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
