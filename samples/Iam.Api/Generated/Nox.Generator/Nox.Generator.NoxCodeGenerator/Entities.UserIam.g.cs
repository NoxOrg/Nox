// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace IamApi.Domain;

/// <summary>
/// User.
/// </summary>
public partial class UserIam : AuditableEntityBase
{
    /// <summary>
    /// The Customer unique identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public Nox.Types.Text UserName { get; set; } = null!;

    /// <summary>
    /// The customer's first name (Required).
    /// </summary>
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public Nox.Types.Text LastName { get; set; } = null!;

    /// <summary>
    /// Tenant (Required).
    /// </summary>
    public Nox.Types.Guid TenantId { get; set; } = null!;

    /// <summary>
    /// TenantBrand (Required).
    /// </summary>
    public Nox.Types.Guid TenantBrandId { get; set; } = null!;

    /// <summary>
    /// PrimaryEmailAddress (Optional).
    /// </summary>
    public Nox.Types.Email? PrimaryEmailAddress { get; set; } = null!;

    /// <summary>
    /// ScondaryEmailAddress (Optional).
    /// </summary>
    public Nox.Types.Email? SecondaryEmailAddress { get; set; } = null!;

    /// <summary>
    /// Country Code (Optional).
    /// </summary>
    public Nox.Types.CountryCode2? CountryCode { get; set; } = null!;

    /// <summary>
    /// Preffered Language (Optional).
    /// </summary>
    public Nox.Types.LanguageCode? PrefferedLanguage { get; set; } = null!;

    /// <summary>
    /// AccepetdTerms (Optional).
    /// </summary>
    public Nox.Types.Boolean? AccepetdTerms { get; set; } = null!;

    /// <summary>
    /// PasswordLess (Optional).
    /// </summary>
    public Nox.Types.Boolean? EnablePasswordLess { get; set; } = null!;

    /// <summary>
    /// UserIam user has roles ZeroOrMany Roles
    /// </summary>
    public virtual List<Role> Roles { get; set; } = new();

    /// <summary>
    /// UserIam User has a verified email ExactlyOne EmailAddresses
    /// </summary>
    public virtual EmailAddress EmailAddress { get; set; } = null!;

    public EmailAddress VerifiedEmails => EmailAddress;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity EmailAddress
    /// </summary>
    public Nox.Types.Email EmailAddressId { get; set; } = null!;

    /// <summary>
    /// UserIam User has a verified phone ExactlyOne Phones
    /// </summary>
    public virtual Phone Phone { get; set; } = null!;

    public Phone VerifiedPhone => Phone;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Phone
    /// </summary>
    public Nox.Types.PhoneNumber PhoneId { get; set; } = null!;

    /// <summary>
    /// UserIam user selected contacts ZeroOrMany UserContactSelections
    /// </summary>
    public virtual List<UserContactSelection> UserContactSelections { get; set; } = new();

    public List<UserContactSelection> ContactSelection => UserContactSelections;
}