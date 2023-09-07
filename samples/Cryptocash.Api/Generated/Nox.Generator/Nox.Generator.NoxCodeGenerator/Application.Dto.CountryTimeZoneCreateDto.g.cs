// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Time zone related to country.
/// </summary>
public partial class CountryTimeZoneCreateDto : IEntityCreateDto <CountryTimeZone>
{    
    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    [Required(ErrorMessage = "TimeZoneCode is required")]
    
    public System.String TimeZoneCode { get; set; } = default!;   
}