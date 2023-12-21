
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
using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Factories;

internal partial class MinimumCashStockFactory : MinimumCashStockFactoryBase
{
    public MinimumCashStockFactory
    (
    ) : base()
    {}
}

internal abstract class MinimumCashStockFactoryBase : IEntityFactory<MinimumCashStockEntity, MinimumCashStockCreateDto, MinimumCashStockUpdateDto>
{

    public MinimumCashStockFactoryBase(
        )
    {
    }

    public virtual async Task<MinimumCashStockEntity> CreateEntityAsync(MinimumCashStockCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(MinimumCashStockEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(MinimumCashStockEntity entity, MinimumCashStockUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(MinimumCashStockEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(MinimumCashStockEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(MinimumCashStockEntity));
        }   
    }

    private async Task<Cryptocash.Domain.MinimumCashStock> ToEntityAsync(MinimumCashStockCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.MinimumCashStock();
        exceptionCollector.Collect("Amount", () => entity.SetIfNotNull(createDto.Amount, (entity) => entity.Amount = 
            Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(createDto.Amount.NonNullValue<MoneyDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(MinimumCashStockEntity entity, MinimumCashStockUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Amount",() => entity.Amount = Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(MinimumCashStockEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AmountUpdateValue, "Attribute 'Amount' can't be null.");
            {
                var entityToUpdate = entity.Amount is null ? new MoneyDto() : entity.Amount.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, AmountUpdateValue);
                exceptionCollector.Collect("Amount",() =>entity.Amount = Cryptocash.Domain.MinimumCashStockMetadata.CreateAmount(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}