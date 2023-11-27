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
/// Patch entity Customer: Customer definition and related data.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class CustomerPatchDto: { { className} }
{

}

/// <summary>
/// Customer definition and related data
/// </summary>
public partial class CustomerUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Customer>
{
    /// <summary>
    /// Customer's first name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "FirstName is required")]
    
    public virtual System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Customer's last name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "LastName is required")]
    
    public virtual System.String LastName { get; set; } = default!;
    /// <summary>
    /// Customer's email address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public virtual System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Customer's street address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Customer's mobile number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? MobileNumber { get; set; }
}