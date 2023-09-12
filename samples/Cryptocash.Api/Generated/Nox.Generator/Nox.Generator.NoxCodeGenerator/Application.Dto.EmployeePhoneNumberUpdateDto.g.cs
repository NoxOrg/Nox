// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee phone number and related data.
/// </summary>
public partial class EmployeePhoneNumberUpdateDto
{
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