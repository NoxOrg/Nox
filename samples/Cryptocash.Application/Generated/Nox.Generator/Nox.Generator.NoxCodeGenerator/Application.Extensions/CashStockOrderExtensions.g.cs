﻿// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class CashStockOrderExtensions
{
    public static CashStockOrderDto ToDto(this Cryptocash.Domain.CashStockOrder entity)
    {
        var dto = new CashStockOrderDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Amount, (dto) => dto.Amount =entity!.Amount!.ToDto());
        dto.SetIfNotNull(entity?.RequestedDeliveryDate, (dto) => dto.RequestedDeliveryDate =entity!.RequestedDeliveryDate!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        dto.SetIfNotNull(entity?.DeliveryDateTime, (dto) => dto.DeliveryDateTime =entity!.DeliveryDateTime!.Value);
        dto.SetIfNotNull(entity?.Status, (dto) => dto.Status =entity!.Status);

        return dto;
    }
}