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
public partial class TimeZoneCreateDto : TimeZoneUpdateDto
{

    public Cryptocash.Domain.TimeZone ToEntity()
    {
        var entity = new Cryptocash.Domain.TimeZone();
        entity.TimeZoneCode = Cryptocash.Domain.TimeZone.CreateTimeZoneCode(TimeZoneCode);
        return entity;
    }
}