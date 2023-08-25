// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IamApi.Application.Dto; 

/// <summary>
/// User.
/// </summary>
public partial class UserIamUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "UserName is required")]
    
    public System.String UserName { get; set; } = default!;
    /// <summary>
    /// The customer's first name (Required).
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// Tenant (Required).
    /// </summary>
    [Required(ErrorMessage = "TenantId is required")]
    
    public System.Guid TenantId { get; set; } = default!;
    /// <summary>
    /// TenantBrand (Required).
    /// </summary>
    [Required(ErrorMessage = "TenantBrandId is required")]
    
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
    /// UserIam user selected contacts ZeroOrMany UserContactSelections
    /// </summary>
    public virtual List<UserContactSelectionUpdateDto> UserContactSelections { get; set; } = new();

    /// <summary>
    /// UserIam Verified emails ZeroOrOne EmailAddresses
    /// </summary>
     public virtual EmailAddressUpdateDto? EmailAddress { get; set; } = null!;

    /// <summary>
    /// UserIam User has a verified phone ZeroOrOne Phones
    /// </summary>
     public virtual PhoneUpdateDto? Phone { get; set; } = null!;
}