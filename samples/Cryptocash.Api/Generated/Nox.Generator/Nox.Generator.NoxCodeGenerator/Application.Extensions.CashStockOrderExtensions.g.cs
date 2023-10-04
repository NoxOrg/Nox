// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CashStockOrderExtensions
{
    public static CashStockOrderDto ToDto(this CashStockOrder entity)
    {
        var dto = new CashStockOrderDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Amount, () => dto.Amount =entity!.Amount!.ToDto());
        SetIfNotNull(entity?.RequestedDeliveryDate, () => dto.RequestedDeliveryDate =entity!.RequestedDeliveryDate!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        SetIfNotNull(entity?.DeliveryDateTime, () => dto.DeliveryDateTime =entity!.DeliveryDateTime!.Value);
        SetIfNotNull(entity?.Status, () => dto.Status =entity!.Status!.ToString());
        SetIfNotNull(entity?.CashStockOrderForVendingMachineId, () => dto.CashStockOrderForVendingMachineId = entity!.CashStockOrderForVendingMachineId!.Value);
        SetIfNotNull(entity?.CashStockOrderForVendingMachine, () => dto.CashStockOrderForVendingMachine = entity!.CashStockOrderForVendingMachine!.ToDto());
        SetIfNotNull(entity?.CashStockOrderReviewedByEmployee, () => dto.CashStockOrderReviewedByEmployee = entity!.CashStockOrderReviewedByEmployee!.ToDto());

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