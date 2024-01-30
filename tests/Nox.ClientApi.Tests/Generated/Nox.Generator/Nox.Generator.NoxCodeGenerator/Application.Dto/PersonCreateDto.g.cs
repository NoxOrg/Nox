// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Person.
/// </summary>
public partial class PersonCreateDto : PersonCreateDtoBase
{

}

/// <summary>
/// Person.
/// </summary>
public abstract class PersonCreateDtoBase 
{
    /// <summary>
    /// The person unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// The users's username     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? UserName { get; set; }
    /// <summary>
    /// The user's first name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String? FirstName { get; set; }
    /// <summary>
    /// The customer's last name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String? LastName { get; set; }
    /// <summary>
    /// Tenant user bellongs to     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TenantId is required")]
    
    public virtual System.Int32? TenantId { get; set; }
    /// <summary>
    /// Tenant Brand user bellongs to     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Guid? TenantBrandId { get; set; }
    /// <summary>
    /// The user's primary email for MFA     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "PrimaryEmailAddress is required")]
    
    public virtual System.String? PrimaryEmailAddress { get; set; }
    /// <summary>
    /// The user's secondary email for MFA     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? SecondaryEmailAddress { get; set; }
    /// <summary>
    /// The user's phone number for MFA     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? PhoneNumber { get; set; }
    /// <summary>
    /// The user's preferred language     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? PrefferedLanguage { get; set; }
    /// <summary>
    /// The user status     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Status is required")]
    
    public virtual System.Int32? Status { get; set; }
    /// <summary>
    /// The user type     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Type is required")]
    
    public virtual System.Int32? Type { get; set; }
    /// <summary>
    /// The preferred method of login     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "PreferredLoginMethod is required")]
    
    public virtual System.Int32? PreferredLoginMethod { get; set; }
    /// <summary>
    /// The user's country code     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? HCountryIsoCode { get; set; }
    /// <summary>
    /// The user accepted terms and condition     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Boolean? HAcceptedTerms { get; set; }
    /// <summary>
    /// PasswordLess     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Boolean? HEnablePasswordLess { get; set; }
    /// <summary>
    /// The user verified primary email address     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.Boolean? HPrimaryEmailAddressVerified { get; set; }

    /// <summary>
    /// Person user selected contacts ZeroOrOne UserContactSelections
    /// </summary>
    public virtual UserContactSelectionUpsertDto? UserContactSelection { get; set; } = null!;
}