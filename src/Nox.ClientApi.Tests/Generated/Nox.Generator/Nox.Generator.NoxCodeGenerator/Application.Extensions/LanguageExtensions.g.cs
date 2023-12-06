// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class LanguageExtensions
{
    public static LanguageDto ToDto(this ClientApi.Domain.Language entity)
    {
        var dto = new LanguageDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.CountryIsoNumeric, (dto) => dto.CountryIsoNumeric =entity!.CountryIsoNumeric!.Value);
        dto.SetIfNotNull(entity?.CountryIsoAlpha3, (dto) => dto.CountryIsoAlpha3 =entity!.CountryIsoAlpha3!.Value);
        dto.SetIfNotNull(entity?.Region, (dto) => dto.Region =entity!.Region!.Value);

        return dto;
    }
}