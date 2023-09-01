// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Holidays related to country.
/// </summary>
public partial class CountryHolidayUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
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

    /// <summary>
    /// CountryHoliday Country's holidays ExactlyOne Countries
    /// </summary>
    [Required(ErrorMessage = "Country is required")]
    public System.String CountryId { get; set; } = default!;
}