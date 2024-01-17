// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class MinimumCashStockExtensions
{
    public static MinimumCashStockDto ToDto(this Cryptocash.Domain.MinimumCashStock entity)
    {
        var dto = new MinimumCashStockDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Amount, (dto) => dto.Amount =entity!.Amount!.ToDto());

        return dto;
    }
}