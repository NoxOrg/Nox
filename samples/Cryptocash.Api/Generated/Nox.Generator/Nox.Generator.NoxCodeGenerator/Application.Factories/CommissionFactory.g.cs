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
using CommissionEntity = Cryptocash.Domain.Commission;

namespace Cryptocash.Application.Factories;

internal partial class CommissionFactory : CommissionFactoryBase
{
    public CommissionFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CommissionFactoryBase : IEntityFactory<CommissionEntity, CommissionCreateDto, CommissionUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CommissionFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CommissionEntity> CreateEntityAsync(CommissionCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(CommissionEntity entity, CommissionUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CommissionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<Cryptocash.Domain.Commission> ToEntityAsync(CommissionCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Commission();
        entity.Rate = Cryptocash.Domain.CommissionMetadata.CreateRate(createDto.Rate);
        entity.EffectiveAt = Cryptocash.Domain.CommissionMetadata.CreateEffectiveAt(createDto.EffectiveAt);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CommissionEntity entity, CommissionUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Rate = Cryptocash.Domain.CommissionMetadata.CreateRate(updateDto.Rate.NonNullValue<System.Single>());
        entity.EffectiveAt = Cryptocash.Domain.CommissionMetadata.CreateEffectiveAt(updateDto.EffectiveAt.NonNullValue<System.DateTimeOffset>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CommissionEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}