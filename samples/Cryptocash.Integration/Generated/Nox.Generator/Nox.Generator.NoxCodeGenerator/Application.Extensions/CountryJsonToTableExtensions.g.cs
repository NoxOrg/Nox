// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace CryptocashIntegration.Application.Dto;

internal static class CountryJsonToTableExtensions
{
    public static CountryJsonToTableDto ToDto(this CryptocashIntegration.Domain.CountryJsonToTable entity)
    {
        var dto = new CountryJsonToTableDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Population, (dto) => dto.Population =entity!.Population!.Value);
        dto.SetIfNotNull(entity?.CreateDate, (dto) => dto.CreateDate =entity!.CreateDate!.Value);
        dto.SetIfNotNull(entity?.EditDate, (dto) => dto.EditDate =entity!.EditDate!.Value);
        dto.SetIfNotNull(entity?.PopulationMillions, (dto) => dto.PopulationMillions =entity!.PopulationMillions!.Value);
        dto.SetIfNotNull(entity?.NameWithConcurrency, (dto) => dto.NameWithConcurrency =entity!.NameWithConcurrency!.Value);

        return dto;
    }
}