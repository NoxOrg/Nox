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
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Factories;

internal partial class ExchangeRateFactory : ExchangeRateFactoryBase
{
    public ExchangeRateFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class ExchangeRateFactoryBase : IEntityFactory<ExchangeRateEntity, ExchangeRateUpsertDto, ExchangeRateUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public ExchangeRateFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<ExchangeRateEntity> CreateEntityAsync(ExchangeRateUpsertDto createDto)
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

    public virtual async Task UpdateEntityAsync(ExchangeRateEntity entity, ExchangeRateUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(ExchangeRateEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<Cryptocash.Domain.ExchangeRate> ToEntityAsync(ExchangeRateUpsertDto createDto)
    {
        var entity = new Cryptocash.Domain.ExchangeRate();
        entity.SetIfNotNull(createDto.EffectiveRate, (entity) => entity.EffectiveRate = 
            Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(createDto.EffectiveRate.NonNullValue<System.Int32>()));
        entity.SetIfNotNull(createDto.EffectiveAt, (entity) => entity.EffectiveAt = 
            Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(createDto.EffectiveAt.NonNullValue<System.DateTimeOffset>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(ExchangeRateEntity entity, ExchangeRateUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.EffectiveRate = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(updateDto.EffectiveRate.NonNullValue<System.Int32>());
        entity.EffectiveAt = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(updateDto.EffectiveAt.NonNullValue<System.DateTimeOffset>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(ExchangeRateEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("EffectiveRate", out var EffectiveRateUpdateValue))
        {
            if (EffectiveRateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'EffectiveRate' can't be null");
            }
            {
                entity.EffectiveRate = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(EffectiveRateUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("EffectiveAt", out var EffectiveAtUpdateValue))
        {
            if (EffectiveAtUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'EffectiveAt' can't be null");
            }
            {
                entity.EffectiveAt = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(EffectiveAtUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}