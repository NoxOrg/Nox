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

internal abstract class ExchangeRateFactoryBase : IEntityFactory<ExchangeRateEntity, ExchangeRateCreateDto, ExchangeRateUpdateDto>
{

    public ExchangeRateFactoryBase
    (
        )
    {
    }

    public virtual ExchangeRateEntity CreateEntity(ExchangeRateCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(ExchangeRateEntity entity, ExchangeRateUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(ExchangeRateEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.ExchangeRate ToEntity(ExchangeRateCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.ExchangeRate();
        entity.EffectiveRate = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(createDto.EffectiveRate);
        entity.EffectiveAt = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(createDto.EffectiveAt);
        return entity;
    }

    private void UpdateEntityInternal(ExchangeRateEntity entity, ExchangeRateUpdateDto updateDto)
    {
        entity.EffectiveRate = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(updateDto.EffectiveRate.NonNullValue<System.Int32>());
        entity.EffectiveAt = Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(updateDto.EffectiveAt.NonNullValue<System.DateTimeOffset>());
    }

    private void PartialUpdateEntityInternal(ExchangeRateEntity entity, Dictionary<string, dynamic> updatedProperties)
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
}

internal partial class ExchangeRateFactory : ExchangeRateFactoryBase
{
}