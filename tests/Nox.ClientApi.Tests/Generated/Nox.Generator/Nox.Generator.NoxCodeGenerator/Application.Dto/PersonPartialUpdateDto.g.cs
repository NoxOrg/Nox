// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;



/// <summary>
/// Person.
/// </summary>
public partial class PersonPartialUpdateDto : PersonPartialUpdateDtoBase
{

}

/// <summary>
/// Person
/// </summary>
public partial class PersonPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// The users's username
    /// </summary>
    public virtual System.String? UserName { get; set; }
    /// <summary>
    /// The user's first name
    /// </summary>
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The customer's last name
    /// </summary>
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Tenant user bellongs to
    /// </summary>
    public virtual System.Int32 TenantId { get; set; } = default!;
    /// <summary>
    /// Tenant Brand user bellongs to
    /// </summary>
    public virtual System.Guid? TenantBrandId { get; set; }
    /// <summary>
    /// The user's primary email for MFA
    /// </summary>
    public virtual System.String PrimaryEmailAddress { get; set; } = default!;
    /// <summary>
    /// The user's secondary email for MFA
    /// </summary>
    public virtual System.String? SecondaryEmailAddress { get; set; }
    /// <summary>
    /// The user's phone number for MFA
    /// </summary>
    public virtual System.String? PhoneNumber { get; set; }
    /// <summary>
    /// The user's preferred language
    /// </summary>
    public virtual System.String? PrefferedLanguage { get; set; }
    /// <summary>
    /// The user status
    /// </summary>
    public virtual System.Int32 Status { get; set; } = default!;
    /// <summary>
    /// The user type
    /// </summary>
    public virtual System.Int32 Type { get; set; } = default!;
    /// <summary>
    /// The preferred method of login
    /// </summary>
    public virtual System.Int32 PreferredLoginMethod { get; set; } = default!;
    /// <summary>
    /// The user's country code
    /// </summary>
    public virtual System.String? HCountryIsoCode { get; set; }
    /// <summary>
    /// The user accepted terms and condition
    /// </summary>
    public virtual System.Boolean? HAcceptedTerms { get; set; }
    /// <summary>
    /// PasswordLess
    /// </summary>
    public virtual System.Boolean? HEnablePasswordLess { get; set; }
    /// <summary>
    /// The user verified primary email address
    /// </summary>
    public virtual System.Boolean? HPrimaryEmailAddressVerified { get; set; }
}