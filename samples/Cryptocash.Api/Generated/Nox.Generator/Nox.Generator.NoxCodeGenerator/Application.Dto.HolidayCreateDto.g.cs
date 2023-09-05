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

    public Cryptocash.Domain.Holiday ToEntity()
    {
        var entity = new Cryptocash.Domain.Holiday();
        entity.Name = Cryptocash.Domain.Holiday.CreateName(Name);
        entity.Type = Cryptocash.Domain.Holiday.CreateType(Type);
        entity.Date = Cryptocash.Domain.Holiday.CreateDate(Date);
        return entity;
    }
}