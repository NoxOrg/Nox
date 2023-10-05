// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class MinimumCashStockExtensions
{
    public static MinimumCashStockDto ToDto(this MinimumCashStock entity)
    {
        var dto = new MinimumCashStockDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Amount, () => dto.Amount =entity!.Amount!.ToDto());
        SetIfNotNull(entity?.MinimumCashStocksRequiredByVendingMachines, () => dto.MinimumCashStocksRequiredByVendingMachines = entity!.MinimumCashStocksRequiredByVendingMachines.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.MinimumCashStockRelatedCurrencyId, () => dto.MinimumCashStockRelatedCurrencyId = entity!.MinimumCashStockRelatedCurrencyId!.Value);

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}