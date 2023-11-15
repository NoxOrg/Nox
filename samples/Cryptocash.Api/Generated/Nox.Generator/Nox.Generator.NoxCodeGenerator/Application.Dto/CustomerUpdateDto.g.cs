// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

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
public partial class CustomerUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Customer>
{
    /// <summary>
    /// Customer's first name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Customer's last name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Customer's email address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public virtual System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Customer's street address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Customer's mobile number 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.String? MobileNumber { get; set; }
}