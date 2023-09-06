// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Holiday related to country.
/// </summary>
public partial class HolidayUpdateDto
{
    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    [Required(ErrorMessage = "Type is required")]
    
    public System.String Type { get; set; } = default!;
    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    [Required(ErrorMessage = "Date is required")]
    
    public System.DateTime Date { get; set; } = default!;
}