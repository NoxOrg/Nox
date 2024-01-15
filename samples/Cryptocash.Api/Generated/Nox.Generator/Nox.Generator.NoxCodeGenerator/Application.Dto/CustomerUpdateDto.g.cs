// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerUpdateDto : CustomerUpdateDtoBase
{

}

/// <summary>
/// Customer definition and related data
/// </summary>
public partial class CustomerUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Customer's first name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String? FirstName { get; set; }
    /// <summary>
    /// Customer's last name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String? LastName { get; set; }
    /// <summary>
    /// Customer's email address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public virtual System.String? EmailAddress { get; set; }
    /// <summary>
    /// Customer's street address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto? Address { get; set; }
    /// <summary>
    /// Customer's mobile number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? MobileNumber { get; set; }
}