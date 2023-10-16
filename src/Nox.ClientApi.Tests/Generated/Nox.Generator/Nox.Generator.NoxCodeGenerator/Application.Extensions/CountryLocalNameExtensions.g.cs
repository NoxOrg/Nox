// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

internal static class CountryLocalNameExtensions
{
    public static CountryLocalNameDto ToDto(this CountryLocalName entity)
    {
        var dto = new CountryLocalNameDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.NativeName, (dto) => dto.NativeName =entity!.NativeName!.Value);

        return dto;
    }
}