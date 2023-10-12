// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class HolidayExtensions
{
    public static HolidayDto ToDto(this Holiday entity)
    {
        var dto = new HolidayDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Type, (dto) => dto.Type =entity!.Type!.Value);
        dto.SetIfNotNull(entity?.Date, (dto) => dto.Date =entity!.Date!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));

        return dto;
    }
}