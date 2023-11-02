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
using ClientApi.Domain;
using CountryQualityOfLifeIndexEntity = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Factories;

internal abstract class CountryQualityOfLifeIndexFactoryBase : IEntityFactory<CountryQualityOfLifeIndexEntity, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto>
{

    public CountryQualityOfLifeIndexFactoryBase
    (
        )
    {
    }

    public virtual CountryQualityOfLifeIndexEntity CreateEntity(CountryQualityOfLifeIndexCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryQualityOfLifeIndexEntity entity, CountryQualityOfLifeIndexUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CountryQualityOfLifeIndexEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.CountryQualityOfLifeIndex ToEntity(CountryQualityOfLifeIndexCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryQualityOfLifeIndex();
        entity.CountryId = CountryQualityOfLifeIndexMetadata.CreateCountryId(createDto.CountryId);
        entity.IndexRating = ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateIndexRating(createDto.IndexRating);
        return entity;
    }

    private void UpdateEntityInternal(CountryQualityOfLifeIndexEntity entity, CountryQualityOfLifeIndexUpdateDto updateDto)
    {
        entity.IndexRating = ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateIndexRating(updateDto.IndexRating.NonNullValue<System.Int32>());
    }

    private void PartialUpdateEntityInternal(CountryQualityOfLifeIndexEntity entity, Dictionary<string, dynamic> updatedProperties)
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
}

internal partial class CountryQualityOfLifeIndexFactory : CountryQualityOfLifeIndexFactoryBase
{
}