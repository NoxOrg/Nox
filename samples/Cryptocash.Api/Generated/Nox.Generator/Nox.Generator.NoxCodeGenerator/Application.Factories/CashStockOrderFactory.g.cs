// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Factories;

internal abstract class CashStockOrderFactoryBase : IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public CashStockOrderFactoryBase
    (
        )
    {
    }

    public virtual CashStockOrderEntity CreateEntity(CashStockOrderCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CashStockOrderEntity entity, CashStockOrderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CashStockOrderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.CashStockOrder ToEntity(CashStockOrderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.CashStockOrder();
        entity.Amount = Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(createDto.Amount);
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(createDto.RequestedDeliveryDate);
        entity.SetIfNotNull(createDto.DeliveryDateTime, (entity) => entity.DeliveryDateTime =Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(createDto.DeliveryDateTime.NonNullValue<System.DateTimeOffset>()));
        return entity;
    }

    private void UpdateEntityInternal(CashStockOrderEntity entity, CashStockOrderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Amount = Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(updateDto.RequestedDeliveryDate.NonNullValue<System.DateTime>());
        entity.SetIfNotNull(updateDto.DeliveryDateTime, (entity) => entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(updateDto.DeliveryDateTime.ToValueFromNonNull<System.DateTimeOffset>()));
    }

    private void PartialUpdateEntityInternal(CashStockOrderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            if (AmountUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Amount' can't be null");
            }
            {
                entity.Amount = Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(AmountUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("RequestedDeliveryDate", out var RequestedDeliveryDateUpdateValue))
        {
            if (RequestedDeliveryDateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'RequestedDeliveryDate' can't be null");
            }
            {
                entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(RequestedDeliveryDateUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DeliveryDateTime", out var DeliveryDateTimeUpdateValue))
        {
            if (DeliveryDateTimeUpdateValue == null) { entity.DeliveryDateTime = null; }
            else
            {
                entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(DeliveryDateTimeUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class CashStockOrderFactory : CashStockOrderFactoryBase
{
}