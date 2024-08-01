// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace CryptocashIntegration.Application.Dto;

internal static class CountryQueryToTableExtensions
{
    public static CountryQueryToTableDto ToDto(this CryptocashIntegration.Domain.CountryQueryToTable entity)
    {
        var dto = new CountryQueryToTableDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Population, (dto) => dto.Population =entity!.Population!.Value);

        return dto;
    }
}