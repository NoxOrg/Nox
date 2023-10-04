// Generated

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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Factories;

internal abstract class CommissionFactoryBase : IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto>
{

    public CommissionFactoryBase
    (
        )
    {
    }

    public virtual CommissionEntity CreateEntity(CommissionCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CommissionEntity entity, CommissionUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CommissionEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.Commission ToEntity(CommissionCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Commission();
        entity.Rate = Cryptocash.Domain.CommissionMetadata.CreateRate(createDto.Rate);
        entity.EffectiveAt = Cryptocash.Domain.CommissionMetadata.CreateEffectiveAt(createDto.EffectiveAt);
        return entity;
    }

    private void UpdateEntityInternal(CommissionEntity entity, CommissionUpdateDto updateDto)
    {
        entity.Rate = Cryptocash.Domain.CommissionMetadata.CreateRate(updateDto.Rate.NonNullValue<System.Single>());
        entity.EffectiveAt = Cryptocash.Domain.CommissionMetadata.CreateEffectiveAt(updateDto.EffectiveAt.NonNullValue<System.DateTimeOffset>());
    }

    private void PartialUpdateEntityInternal(CommissionEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Rate", out var RateUpdateValue))
        {
            if (RateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Rate' can't be null");
            }
            {
                entity.Rate = Cryptocash.Domain.CommissionMetadata.CreateRate(RateUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("EffectiveAt", out var EffectiveAtUpdateValue))
        {
            if (EffectiveAtUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'EffectiveAt' can't be null");
            }
            {
                entity.EffectiveAt = Cryptocash.Domain.CommissionMetadata.CreateEffectiveAt(EffectiveAtUpdateValue);
            }
        }
    }
}

internal partial class CommissionFactory : CommissionFactoryBase
{
}