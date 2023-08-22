// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
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
    /// The customer's email (Required).
    /// </summary>
    [Required(ErrorMessage = "Email is required")]
    
    public System.String Email { get; set; } = default!;
    /// <summary>
    /// The customer's address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// The customer's mobile number (Optional).
    /// </summary>
    public System.String? MobileNumber { get; set; } 
}