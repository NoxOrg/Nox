// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class MinimumCashStockExtensions
{
    public static MinimumCashStockDto ToDto(this MinimumCashStock entity)
    {
        var dto = new MinimumCashStockDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Amount, (dto) => dto.Amount =entity!.Amount!.ToDto());
        dto.SetIfNotNull(entity?.MinimumCashStocksRequiredByVendingMachines, (dto) => dto.MinimumCashStocksRequiredByVendingMachines = entity!.MinimumCashStocksRequiredByVendingMachines.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.MinimumCashStockRelatedCurrencyId, (dto) => dto.MinimumCashStockRelatedCurrencyId = entity!.MinimumCashStockRelatedCurrencyId!.Value);

        return dto;
    }
}