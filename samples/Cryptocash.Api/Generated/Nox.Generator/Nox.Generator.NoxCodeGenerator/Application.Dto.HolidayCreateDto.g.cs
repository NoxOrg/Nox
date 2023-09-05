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
/// Holiday related to country.
/// </summary>
public partial class HolidayCreateDto : HolidayUpdateDto
{

    public Holiday ToEntity()
    {
        var entity = new Holiday();
        entity.Name = Holiday.CreateName(Name);
        entity.Type = Holiday.CreateType(Type);
        entity.Date = Holiday.CreateDate(Date);
        return entity;
    }
}