// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace CryptocashIntegration.Application.Dto;

internal static class CountryQueryToCustomTableExtensions
{
    public static CountryQueryToCustomTableDto ToDto(this CryptocashIntegration.Domain.CountryQueryToCustomTable entity)
    {
        var dto = new CountryQueryToCustomTableDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Population, (dto) => dto.Population =entity!.Population!.Value);
        dto.SetIfNotNull(entity?.CreateDate, (dto) => dto.CreateDate =entity!.CreateDate!.Value);
        dto.SetIfNotNull(entity?.EditDate, (dto) => dto.EditDate =entity!.EditDate!.Value);

        return dto;
    }
}