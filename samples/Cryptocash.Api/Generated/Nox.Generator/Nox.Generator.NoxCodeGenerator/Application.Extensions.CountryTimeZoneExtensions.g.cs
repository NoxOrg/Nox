// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CountryTimeZoneExtensions
{
    public static CountryTimeZoneDto ToDto(this CountryTimeZone entity)
    {
        var dto = new CountryTimeZoneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TimeZoneCode, () => dto.TimeZoneCode = entity!.TimeZoneCode!.Value);

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