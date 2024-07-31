// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace CryptocashIntegration.Application.Dto;

internal static class CountryProcToTableExtensions
{
    public static CountryProcToTableDto ToDto(this CryptocashIntegration.Domain.CountryProcToTable entity)
    {
        var dto = new CountryProcToTableDto();
        dto.SetIfNotNull(entity?.CountryId, (dto) => dto.CountryId = entity!.CountryId.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Population, (dto) => dto.Population =entity!.Population!.Value);

        return dto;
    }
}