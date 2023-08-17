// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

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
    public System.String FirstName { get; set; } = default!;
    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;
    /// <summary>
    /// The customer's email (Required).
    /// </summary>
    public System.String Email { get; set; } = default!;
    /// <summary>
    /// The customer's address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// The customer's mobile number (Optional).
    /// </summary>
    public System.String? MobileNumber { get; set; } 
}