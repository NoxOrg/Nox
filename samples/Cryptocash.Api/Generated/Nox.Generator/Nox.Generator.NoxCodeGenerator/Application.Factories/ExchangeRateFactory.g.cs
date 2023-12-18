

// Generated
//TODO: if CultureCode is not needed, remove it from the factory
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
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(ExchangeRateEntity entity, ExchangeRateUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(ExchangeRateEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    private async Task<Cryptocash.Domain.ExchangeRate> ToEntityAsync(ExchangeRateUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.ExchangeRate();
        exceptionCollector.Collect("EffectiveRate", () => entity.SetIfNotNull(createDto.EffectiveRate, (entity) => entity.EffectiveRate = 
            Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(createDto.EffectiveRate.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("EffectiveAt", () => entity.SetIfNotNull(createDto.EffectiveAt, (entity) => entity.EffectiveAt = 
            Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(createDto.EffectiveAt.NonNullValue<System.DateTimeOffset>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(ExchangeRateEntity entity, ExchangeRateUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("EffectiveRate",() => entity.EffectiveRate = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(updateDto.EffectiveRate.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("EffectiveAt",() => entity.EffectiveAt = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(updateDto.EffectiveAt.NonNullValue<System.DateTimeOffset>()));

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
                exceptionCollector.Collect("EffectiveRate",() =>entity.EffectiveRate = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(EffectiveRateUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EffectiveAt", out var EffectiveAtUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(EffectiveAtUpdateValue, "Attribute 'EffectiveAt' can't be null.");
            {
                exceptionCollector.Collect("EffectiveAt",() =>entity.EffectiveAt = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(EffectiveAtUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}