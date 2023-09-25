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

public abstract class CountryQualityOfLifeIndexFactoryBase : IEntityFactory<CountryQualityOfLifeIndex, CountryQualityOfLifeIndexCreateDto, CountryQualityOfLifeIndexUpdateDto>
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
}

public partial class CountryQualityOfLifeIndexFactory : CountryQualityOfLifeIndexFactoryBase
{
}