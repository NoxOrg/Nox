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
public partial class PersonUpdateDto : PersonUpdateDtoBase
{

}

/// <summary>
/// Person
/// </summary>
public partial class PersonUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// The user's first name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String? FirstName { get; set; }
    /// <summary>
    /// The customer's last name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String? LastName { get; set; }
    /// <summary>
    /// Tenant user bellongs to     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TenantId is required")]
    
    public virtual System.Guid? TenantId { get; set; }
    /// <summary>
    /// The user's primary email for MFA     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PrimaryEmailAddress is required")]
    
    public virtual System.String? PrimaryEmailAddress { get; set; }
    /// <summary>
    /// Person user selected contacts ZeroOrOne UserContactSelections
    /// </summary>
    public virtual UserContactSelectionUpsertDto? UserContactSelection { get; set; } = null!;
}