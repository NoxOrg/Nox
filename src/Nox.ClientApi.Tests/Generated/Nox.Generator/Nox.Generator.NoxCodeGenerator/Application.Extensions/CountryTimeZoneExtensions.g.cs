// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class CountryTimeZoneExtensions
{
    public static CountryTimeZoneDto ToDto(this ClientApi.Domain.CountryTimeZone entity)
    {
        var dto = new CountryTimeZoneDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);

        return dto;
    }
}