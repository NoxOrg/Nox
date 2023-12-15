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
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CashStockOrderFactoryBase : IEntityFactory<CashStockOrderEntity, CashStockOrderCreateDto, CashStockOrderUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CashStockOrderFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CashStockOrderEntity> CreateEntityAsync(CashStockOrderCreateDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
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
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(CashStockOrderEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<Cryptocash.Domain.CashStockOrder> ToEntityAsync(CashStockOrderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.CashStockOrder();
        entity.SetIfNotNull(createDto.Amount, (entity) => entity.Amount = 
            Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(createDto.Amount.NonNullValue<MoneyDto>()));
        entity.SetIfNotNull(createDto.RequestedDeliveryDate, (entity) => entity.RequestedDeliveryDate = 
            Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(createDto.RequestedDeliveryDate.NonNullValue<System.DateTime>()));
        entity.SetIfNotNull(createDto.DeliveryDateTime, (entity) => entity.DeliveryDateTime = 
            Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(createDto.DeliveryDateTime.NonNullValue<System.DateTimeOffset>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CashStockOrderEntity entity, CashStockOrderUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Amount = Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(updateDto.RequestedDeliveryDate.NonNullValue<System.DateTime>());
        if(updateDto.DeliveryDateTime is null)
        {
             entity.DeliveryDateTime = null;
        }
        else
        {
            entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(updateDto.DeliveryDateTime.ToValueFromNonNull<System.DateTimeOffset>());
        }
        await Task.CompletedTask;
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
                var entityToUpdate = entity.Amount is null ? new MoneyDto() : entity.Amount.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountUpdateValue);
                entity.Amount = Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(entityToUpdate);
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