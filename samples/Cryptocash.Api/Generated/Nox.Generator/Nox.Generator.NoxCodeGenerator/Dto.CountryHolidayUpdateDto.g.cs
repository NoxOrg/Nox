// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Holidays related to country.
/// </summary>
public partial class CountryHolidayUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The country holiday name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// The country holiday type (Required).
    /// </summary>
    [Required(ErrorMessage = "Type is required")]
    
    public System.String Type { get; set; } = default!;
    /// <summary>
    /// The country holiday date (Required).
    /// </summary>
    [Required(ErrorMessage = "Date is required")]
    
    public System.DateTime Date { get; set; } = default!;
}