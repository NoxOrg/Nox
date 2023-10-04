// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class HolidayExtensions
{
    public static HolidayDto ToDto(this Holiday entity)
    {
        var dto = new HolidayDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name =entity!.Name!.Value);
        SetIfNotNull(entity?.Type, () => dto.Type =entity!.Type!.Value);
        SetIfNotNull(entity?.Date, () => dto.Date =entity!.Date!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}