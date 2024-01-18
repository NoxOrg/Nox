
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
using Dto = Cryptocash.Application.Dto;
using Cryptocash.Domain;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Factories;

internal partial class ExchangeRateFactory : ExchangeRateFactoryBase
{
    public ExchangeRateFactory
    (
    ) : base()
    {}
}

internal abstract class ExchangeRateFactoryBase : IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto>
{

    public ExchangeRateFactoryBase(
        )
    {
    }

    public virtual async Task<ExchangeRateEntity> CreateEntityAsync(ExchangeRateUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(ExchangeRateEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(ExchangeRateEntity entity, ExchangeRateUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(ExchangeRateEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(ExchangeRateEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(ExchangeRateEntity));
        }   
    }

    private async Task<Cryptocash.Domain.ExchangeRate> ToEntityAsync(ExchangeRateUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.ExchangeRate();
        exceptionCollector.Collect("EffectiveRate", () => entity.SetIfNotNull(createDto.EffectiveRate, (entity) => entity.EffectiveRate = 
            Dto.ExchangeRateMetadata.CreateEffectiveRate(createDto.EffectiveRate.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("EffectiveAt", () => entity.SetIfNotNull(createDto.EffectiveAt, (entity) => entity.EffectiveAt = 
            Dto.ExchangeRateMetadata.CreateEffectiveAt(createDto.EffectiveAt.NonNullValue<System.DateTimeOffset>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(ExchangeRateEntity entity, ExchangeRateUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("EffectiveRate",() => entity.EffectiveRate = Dto.ExchangeRateMetadata.CreateEffectiveRate(updateDto.EffectiveRate.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("EffectiveAt",() => entity.EffectiveAt = Dto.ExchangeRateMetadata.CreateEffectiveAt(updateDto.EffectiveAt.NonNullValue<System.DateTimeOffset>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(ExchangeRateEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("EffectiveRate", out var EffectiveRateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(EffectiveRateUpdateValue, "Attribute 'EffectiveRate' can't be null.");
            {
                exceptionCollector.Collect("EffectiveRate",() =>entity.EffectiveRate = Dto.ExchangeRateMetadata.CreateEffectiveRate(EffectiveRateUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EffectiveAt", out var EffectiveAtUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(EffectiveAtUpdateValue, "Attribute 'EffectiveAt' can't be null.");
            {
                exceptionCollector.Collect("EffectiveAt",() =>entity.EffectiveAt = Dto.ExchangeRateMetadata.CreateEffectiveAt(EffectiveAtUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}