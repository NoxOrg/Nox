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
/// Customer definition and related data
/// </summary>
public partial class CustomerUpdateDto : IEntityDto<DomainNamespace.Customer>
{
    /// <summary>
    /// Customer's first name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "FirstName is required")]
    
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// Customer's last name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "LastName is required")]
    
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// Customer's email address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "EmailAddress is required")]
    
    public System.String EmailAddress { get; set; } = default!;
    /// <summary>
    /// Customer's street address 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Customer's mobile number 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? MobileNumber { get; set; }

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    [Required(ErrorMessage = "Country is required")]
    public System.String CountryId { get; set; } = default!;
}