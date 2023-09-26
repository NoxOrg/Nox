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

using ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryQualityOfLifeIndex = ClientApi.Domain.CountryQualityOfLifeIndex;

namespace ClientApi.Application.Factories;

internal abstract class CountryQualityOfLifeIndexFactoryBase : IEntityFactory<CountryQualityOfLifeIndex, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto>
{

    public CountryQualityOfLifeIndexFactoryBase
    (
        )
    {
    }

    public virtual CountryQualityOfLifeIndex CreateEntity(CountryQualityOfLifeIndexCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryQualityOfLifeIndex entity, CountryQualityOfLifeIndexUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CountryQualityOfLifeIndex entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private ClientApi.Domain.CountryQualityOfLifeIndex ToEntity(CountryQualityOfLifeIndexCreateDto createDto)
    {
        var entity = new ClientApi.Domain.CountryQualityOfLifeIndex();
        entity.CountryId = CountryQualityOfLifeIndex.CreateCountryId(createDto.CountryId);
        entity.IndexRating = ClientApi.Domain.CountryQualityOfLifeIndex.CreateIndexRating(createDto.IndexRating);
        return entity;
    }

    private void UpdateEntityInternal(CountryQualityOfLifeIndex entity, CountryQualityOfLifeIndexUpdateDto updateDto)
    {
        entity.IndexRating = ClientApi.Domain.CountryQualityOfLifeIndex.CreateIndexRating(updateDto.IndexRating.NonNullValue<System.Int32>());
    }

    private void PartialUpdateEntityInternal(CountryQualityOfLifeIndex entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("IndexRating", out var IndexRatingUpdateValue))
        {
            if (IndexRatingUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'IndexRating' can't be null");
            }
            {
                entity.IndexRating = ClientApi.Domain.CountryQualityOfLifeIndex.CreateIndexRating(IndexRatingUpdateValue);
            }
        }
    }
}

internal partial class CountryQualityOfLifeIndexFactory : CountryQualityOfLifeIndexFactoryBase
{
}