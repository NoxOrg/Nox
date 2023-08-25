// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using IamApi.Application.DataTransferObjects;
using IamApi.Domain;

namespace IamApi.Application.Dto;

public record UserIamKeyDto(System.Guid keyId);

/// <summary>
/// User.
/// </summary>
public partial class UserIamDto
{

    /// <summary>
    /// The Customer unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public System.String UserName { get; set; } = default!;

    /// <summary>
    /// The customer's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Tenant (Required).
    /// </summary>
    public System.Guid TenantId { get; set; } = default!;

    /// <summary>
    /// TenantBrand (Required).
    /// </summary>
    public System.Guid TenantBrandId { get; set; } = default!;

    /// <summary>
    /// PrimaryEmailAddress (Optional).
    /// </summary>
    public System.String? PrimaryEmailAddress { get; set; }

    /// <summary>
    /// ScondaryEmailAddress (Optional).
    /// </summary>
    public System.String? SecondaryEmailAddress { get; set; }

    /// <summary>
    /// Country Code (Optional).
    /// </summary>
    public System.String? CountryIsoCode { get; set; }

    /// <summary>
    /// Preffered Language (Optional).
    /// </summary>
    public System.String? PrefferedLanguage { get; set; }

    /// <summary>
    /// AccepetdTerms (Optional).
    /// </summary>
    public System.Boolean? AccepetdTerms { get; set; }

    /// <summary>
    /// PasswordLess (Optional).
    /// </summary>
    public System.Boolean? EnablePasswordLess { get; set; }

    /// <summary>
    /// The user status (Required).
    /// </summary>
    [NotMapped]public System.String UserStatus { get; set; } = default!;

    /// <summary>
    /// UserIam user has roles ZeroOrMany Roles
    /// </summary>
    public virtual List<RoleDto> Roles { get; set; } = new();

    /// <summary>
    /// UserIam user selected contacts ZeroOrMany UserContactSelections
    /// </summary>
    public virtual List<UserContactSelectionDto> UserContactSelections { get; set; } = new();

    /// <summary>
    /// UserIam Verified emails ZeroOrOne EmailAddresses
    /// </summary>
    public virtual EmailAddressDto ? EmailAddress { get; set; } = null!;

    /// <summary>
    /// UserIam User has a verified phone ZeroOrOne Phones
    /// </summary>
    public virtual PhoneDto ? Phone { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}