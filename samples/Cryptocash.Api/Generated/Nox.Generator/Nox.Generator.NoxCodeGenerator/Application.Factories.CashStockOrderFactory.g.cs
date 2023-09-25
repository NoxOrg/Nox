﻿// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Factories;

internal abstract class CashStockOrderFactoryBase : IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto>
{

    public CashStockOrderFactoryBase
    (
        )
    {
    }

    public virtual CashStockOrder CreateEntity(CashStockOrderCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CashStockOrder entity, CashStockOrderUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CashStockOrder entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.CashStockOrder ToEntity(CashStockOrderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.CashStockOrder();
        entity.Amount = Cryptocash.Domain.CashStockOrder.CreateAmount(createDto.Amount);
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrder.CreateRequestedDeliveryDate(createDto.RequestedDeliveryDate);
        if (createDto.DeliveryDateTime is not null)entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrder.CreateDeliveryDateTime(createDto.DeliveryDateTime.NonNullValue<System.DateTimeOffset>());
        return entity;
    }

    private void UpdateEntityInternal(CashStockOrder entity, CashStockOrderUpdateDto updateDto)
    {
        entity.Amount = Cryptocash.Domain.CashStockOrder.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrder.CreateRequestedDeliveryDate(updateDto.RequestedDeliveryDate.NonNullValue<System.DateTime>());
        if (updateDto.DeliveryDateTime == null) { entity.DeliveryDateTime = null; } else {
            entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrder.CreateDeliveryDateTime(updateDto.DeliveryDateTime.ToValueFromNonNull<System.DateTimeOffset>());
        }
    }

    private void PartialUpdateEntityInternal(CashStockOrder entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            if (AmountUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Amount' can't be null");
            }
            {
                entity.Amount = Cryptocash.Domain.CashStockOrder.CreateAmount(AmountUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("RequestedDeliveryDate", out var RequestedDeliveryDateUpdateValue))
        {
            if (RequestedDeliveryDateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'RequestedDeliveryDate' can't be null");
            }
            {
                entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrder.CreateRequestedDeliveryDate(RequestedDeliveryDateUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DeliveryDateTime", out var DeliveryDateTimeUpdateValue))
        {
            if (DeliveryDateTimeUpdateValue == null) { entity.DeliveryDateTime = null; }
            else
            {
                entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrder.CreateDeliveryDateTime(DeliveryDateTimeUpdateValue);
            }
        }
    }
}

internal partial class CashStockOrderFactory : CashStockOrderFactoryBase
{
}