// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Time zones related to country.
/// </summary>
public partial class CountryTimeZonesUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The country's related timezone code (Required).
    /// </summary>
    [Required(ErrorMessage = "TimeZoneCode is required")]
    
    public System.String TimeZoneCode { get; set; } = default!;
}