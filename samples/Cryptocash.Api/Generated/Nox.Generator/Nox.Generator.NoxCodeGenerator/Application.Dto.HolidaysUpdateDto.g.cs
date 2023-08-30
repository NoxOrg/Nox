// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto; 

/// <summary>
/// Holiday related info for a country.
/// </summary>
public partial class HolidaysUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Holiday's associated year (Required).
    /// </summary>
    [Required(ErrorMessage = "Year is required")]
    
    public System.UInt16 Year { get; set; } = default!;
    /// <summary>
    /// Week day off associated with holiday's country (Required).
    /// </summary>
    [Required(ErrorMessage = "DayOff is required")]
    
    public System.UInt16 DayOff { get; set; } = default!;
}