
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

internal partial class CashStockOrderFactory : CashStockOrderFactoryBase
{
    public CashStockOrderFactory
    (
    ) : base()
    {}
}

internal abstract class CashStockOrderFactoryBase : IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto>
{

    public CashStockOrderFactoryBase(
        )
    {
    }

    public virtual async Task<CashStockOrderEntity> CreateEntityAsync(CashStockOrderCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CashStockOrderEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CashStockOrderEntity entity, CashStockOrderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CashStockOrderEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CashStockOrderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CashStockOrderEntity));
        }   
    }

    private async Task<Cryptocash.Domain.CashStockOrder> ToEntityAsync(CashStockOrderCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.CashStockOrder();
        exceptionCollector.Collect("Amount", () => entity.SetIfNotNull(createDto.Amount, (entity) => entity.Amount = 
            Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(createDto.Amount.NonNullValue<MoneyDto>())));
        exceptionCollector.Collect("RequestedDeliveryDate", () => entity.SetIfNotNull(createDto.RequestedDeliveryDate, (entity) => entity.RequestedDeliveryDate = 
            Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(createDto.RequestedDeliveryDate.NonNullValue<System.DateTime>())));
        exceptionCollector.Collect("DeliveryDateTime", () => entity.SetIfNotNull(createDto.DeliveryDateTime, (entity) => entity.DeliveryDateTime = 
            Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(createDto.DeliveryDateTime.NonNullValue<System.DateTimeOffset>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CashStockOrderEntity entity, CashStockOrderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Amount",() => entity.Amount = Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>()));
        exceptionCollector.Collect("RequestedDeliveryDate",() => entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(updateDto.RequestedDeliveryDate.NonNullValue<System.DateTime>()));
        if(updateDto.DeliveryDateTime is null)
        {
             entity.DeliveryDateTime = null;
        }
        else
        {
            exceptionCollector.Collect("DeliveryDateTime",() =>entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(updateDto.DeliveryDateTime.ToValueFromNonNull<System.DateTimeOffset>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CashStockOrderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AmountUpdateValue, "Attribute 'Amount' can't be null.");
            {
                var entityToUpdate = entity.Amount is null ? new MoneyDto() : entity.Amount.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountUpdateValue);
                exceptionCollector.Collect("Amount",() =>entity.Amount = Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("RequestedDeliveryDate", out var RequestedDeliveryDateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(RequestedDeliveryDateUpdateValue, "Attribute 'RequestedDeliveryDate' can't be null.");
            {
                exceptionCollector.Collect("RequestedDeliveryDate",() =>entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(RequestedDeliveryDateUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DeliveryDateTime", out var DeliveryDateTimeUpdateValue))
        {
            if (DeliveryDateTimeUpdateValue == null) { entity.DeliveryDateTime = null; }
            else
            {
                exceptionCollector.Collect("DeliveryDateTime",() =>entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(DeliveryDateTimeUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}