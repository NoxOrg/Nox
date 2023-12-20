﻿// Generated

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
using ClientApi.Domain;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Factories;

internal partial class CountryQualityOfLifeIndexFactory : CountryQualityOfLifeIndexFactoryBase
{
    public CountryQualityOfLifeIndexFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CountryQualityOfLifeIndexFactoryBase : IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CountryQualityOfLifeIndexFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CountryQualityOfLifeIndexEntity> CreateEntityAsync(CountryQualityOfLifeIndexCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(CountryQualityOfLifeIndexEntity entity, CountryQualityOfLifeIndexUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(CountryQualityOfLifeIndexEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<ClientApi.Domain.CountryQualityOfLifeIndex> ToEntityAsync(CountryQualityOfLifeIndexCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryQualityOfLifeIndex();
        entity.CountryId = CountryQualityOfLifeIndexMetadata.CreateCountryId(createDto.CountryId.NonNullValue<System.Int64>());
        entity.SetIfNotNull(createDto.IndexRating, (entity) => entity.IndexRating = 
            ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateIndexRating(createDto.IndexRating.NonNullValue<System.Int32>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryQualityOfLifeIndexEntity entity, CountryQualityOfLifeIndexUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.IndexRating = ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateIndexRating(updateDto.IndexRating.NonNullValue<System.Int32>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryQualityOfLifeIndexEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("IndexRating", out var IndexRatingUpdateValue))
        {
            if (IndexRatingUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'IndexRating' can't be null");
            }
            {
                entity.IndexRating = ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateIndexRating(IndexRatingUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}