
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
using Dto = CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Domain;
using CountryQueryToTableEntity = CryptocashIntegration.Domain.CountryQueryToTable;

namespace CryptocashIntegration.Application.Factories;

internal partial class CountryQueryToTableFactory : CountryQueryToTableFactoryBase
{
    public CountryQueryToTableFactory
    (
    ) : base()
    {}
}

internal abstract class CountryQueryToTableFactoryBase : IEntityFactory<CountryQueryToTableEntity, CountryQueryToTableCreateDto, CountryQueryToTableUpdateDto>
{

    public CountryQueryToTableFactoryBase(
        )
    {
    }

    public virtual async Task<CountryQueryToTableEntity> CreateEntityAsync(CountryQueryToTableCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryQueryToTableEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CountryQueryToTableEntity entity, CountryQueryToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryQueryToTableEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CountryQueryToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryQueryToTableEntity));
        }   
    }

    private async Task<CryptocashIntegration.Domain.CountryQueryToTable> ToEntityAsync(CountryQueryToTableCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new CryptocashIntegration.Domain.CountryQueryToTable();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.CountryQueryToTableMetadata.CreateId(createDto.Id.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.CountryQueryToTableMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Population", () => entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            Dto.CountryQueryToTableMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryQueryToTableEntity entity, CountryQueryToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.CountryQueryToTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Population",() => entity.Population = Dto.CountryQueryToTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryQueryToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.CountryQueryToTableMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PopulationUpdateValue, "Attribute 'Population' can't be null.");
            {
                exceptionCollector.Collect("Population",() =>entity.Population = Dto.CountryQueryToTableMetadata.CreatePopulation(PopulationUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}