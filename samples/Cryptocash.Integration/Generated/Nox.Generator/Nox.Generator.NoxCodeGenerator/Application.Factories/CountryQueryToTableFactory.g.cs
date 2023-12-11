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

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Domain;
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Factories;

internal partial class CountryQueryToTableFactory : CountryQueryToTableFactoryBase
{
    public CountryQueryToTableFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CountryQueryToTableFactoryBase : IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CountryQueryToTableFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CountryQueryToTableEntity> CreateEntityAsync(CountryQueryToTableCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(CountryQueryToTableEntity entity, CountryQueryToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryQueryToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<CryptocashIntegration.Domain.CountryQueryToTable> ToEntityAsync(CountryQueryToTableCreateDto createDto)
    {
        var entity = new CryptocashIntegration.Domain.CountryQueryToTable();
        entity.Id = CountryQueryToTableMetadata.CreateId(createDto.Id);
        entity.Name = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreateName(createDto.Name);
        entity.Population = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreatePopulation(createDto.Population);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryQueryToTableEntity entity, CountryQueryToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Population = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryQueryToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Population' can't be null");
            }
            {
                entity.Population = CryptocashIntegration.Domain.CountryQueryToTableMetadata.CreatePopulation(PopulationUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}