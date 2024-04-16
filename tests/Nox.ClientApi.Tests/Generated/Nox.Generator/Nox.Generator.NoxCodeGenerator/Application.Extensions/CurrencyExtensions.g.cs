// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace ClientApi.Application.Dto;

internal static class CurrencyExtensions
{
    public static CurrencyDto ToDto(this ClientApi.Domain.Currency entity)
    {
        var dto = new CurrencyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.Symbol, (dto) => dto.Symbol =entity!.Symbol!.Value);

        return dto;
    }
}