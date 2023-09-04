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
/// Time zones related to country.
/// </summary>
public partial class CountryTimeZonesCreateDto : CountryTimeZonesUpdateDto
{

    public CountryTimeZones ToEntity()
    {
        var entity = new CountryTimeZones();
        entity.TimeZoneCode = CountryTimeZones.CreateTimeZoneCode(TimeZoneCode);
        return entity;
    }
}