﻿
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

using ClientApi.Application.Dto;
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Factories;

internal partial class CountryQualityOfLifeIndexFactory : CountryQualityOfLifeIndexFactoryBase
{
    public CountryQualityOfLifeIndexFactory
    (
    ) : base()
    {}
}

internal abstract class CountryQualityOfLifeIndexFactoryBase : IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto>
{

    public CountryQualityOfLifeIndexFactoryBase(
        )
    {
    }

    public virtual async Task<CountryQualityOfLifeIndexEntity> CreateEntityAsync(CountryQualityOfLifeIndexCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryQualityOfLifeIndexEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CountryQualityOfLifeIndexEntity entity, CountryQualityOfLifeIndexUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryQualityOfLifeIndexEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CountryQualityOfLifeIndexEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryQualityOfLifeIndexEntity));
        }   
    }

    private async Task<ClientApi.Domain.CountryQualityOfLifeIndex> ToEntityAsync(CountryQualityOfLifeIndexCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.CountryQualityOfLifeIndex();
        exceptionCollector.Collect("CountryId",() => entity.CountryId = Dto.CountryQualityOfLifeIndexMetadata.CreateCountryId(createDto.CountryId.NonNullValue<System.Int64>()));
        exceptionCollector.Collect("IndexRating", () => entity.SetIfNotNull(createDto.IndexRating, (entity) => entity.IndexRating = 
            Dto.CountryQualityOfLifeIndexMetadata.CreateIndexRating(createDto.IndexRating.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryQualityOfLifeIndexEntity entity, CountryQualityOfLifeIndexUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("IndexRating",() => entity.IndexRating = Dto.CountryQualityOfLifeIndexMetadata.CreateIndexRating(updateDto.IndexRating.NonNullValue<System.Int32>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryQualityOfLifeIndexEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("IndexRating", out var IndexRatingUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(IndexRatingUpdateValue, "Attribute 'IndexRating' can't be null.");
            {
                exceptionCollector.Collect("IndexRating",() =>entity.IndexRating = Dto.CountryQualityOfLifeIndexMetadata.CreateIndexRating(IndexRatingUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}