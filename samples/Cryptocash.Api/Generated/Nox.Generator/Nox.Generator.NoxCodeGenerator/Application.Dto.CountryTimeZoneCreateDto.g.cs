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
public partial class CountryTimeZoneCreateDto : CountryTimeZoneUpdateDto
{

    public CountryTimeZone ToEntity()
    {
        var entity = new CountryTimeZone();
        entity.TimeZoneCode = CountryTimeZone.CreateTimeZoneCode(TimeZoneCode);
        return entity;
    }
}