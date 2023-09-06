// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Time zone related to country.
/// </summary>
public partial class CountryTimeZoneCreateDto 
{    
    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    [Required(ErrorMessage = "TimeZoneCode is required")]
    
    public System.String TimeZoneCode { get; set; } = default!;

    public Cryptocash.Domain.CountryTimeZone ToEntity()
    {
        var entity = new Cryptocash.Domain.CountryTimeZone();
        entity.TimeZoneCode = Cryptocash.Domain.CountryTimeZone.CreateTimeZoneCode(TimeZoneCode);
        return entity;
    }
}