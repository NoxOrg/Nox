// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CountryTimeZoneExtensions
{
    public static CountryTimeZoneDto ToDto(this CountryTimeZone entity)
    {
        var dto = new CountryTimeZoneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TimeZoneCode, (dto) => dto.TimeZoneCode =entity!.TimeZoneCode!.Value);

        return dto;
    }
}