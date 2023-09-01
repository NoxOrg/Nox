// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee phone numbers and related data.
/// </summary>
public partial class EmployeePhoneNumberUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    [Required(ErrorMessage = "PhoneNumberType is required")]
    
    public System.String PhoneNumberType { get; set; } = default!;
    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    [Required(ErrorMessage = "PhoneNumber is required")]
    
    public System.String PhoneNumber { get; set; } = default!;
}