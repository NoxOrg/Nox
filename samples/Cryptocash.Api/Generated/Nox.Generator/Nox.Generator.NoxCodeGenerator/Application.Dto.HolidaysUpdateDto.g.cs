// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Holiday related info for a country.
/// </summary>
public partial class HolidaysUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The holiday's related year (Required).
    /// </summary>
    [Required(ErrorMessage = "Year is required")]
    
    public System.UInt16 Year { get; set; } = default!;
    /// <summary>
    /// The holiday's country related week day off (Required).
    /// </summary>
    [Required(ErrorMessage = "DayOff is required")]
    
    public System.UInt16 DayOff { get; set; } = default!;
}