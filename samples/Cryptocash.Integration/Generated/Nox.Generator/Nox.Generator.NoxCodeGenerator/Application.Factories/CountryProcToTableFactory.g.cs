
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
using CountryProcToTableEntity = CryptocashIntegration.Domain.CountryProcToTable;

namespace CryptocashIntegration.Application.Factories;

internal partial class CountryProcToTableFactory : CountryProcToTableFactoryBase
{
    public CountryProcToTableFactory
    (
    ) : base()
    {}
}

internal abstract class CountryProcToTableFactoryBase : IEntityFactory<CountryProcToTableEntity, CountryProcToTableCreateDto, CountryProcToTableUpdateDto>
{

    public CountryProcToTableFactoryBase(
        )
    {
    }

    public virtual async Task<CountryProcToTableEntity> CreateEntityAsync(CountryProcToTableCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryProcToTableEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CountryProcToTableEntity entity, CountryProcToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryProcToTableEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CountryProcToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryProcToTableEntity));
        }   
    }

    private async Task<CryptocashIntegration.Domain.CountryProcToTable> ToEntityAsync(CountryProcToTableCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new CryptocashIntegration.Domain.CountryProcToTable();
        exceptionCollector.Collect("CountryId",() => entity.CountryId = Dto.CountryProcToTableMetadata.CreateCountryId(createDto.CountryId.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.CountryProcToTableMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Population", () => entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            Dto.CountryProcToTableMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryProcToTableEntity entity, CountryProcToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.CountryProcToTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Population",() => entity.Population = Dto.CountryProcToTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryProcToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.CountryProcToTableMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PopulationUpdateValue, "Attribute 'Population' can't be null.");
            {
                exceptionCollector.Collect("Population",() =>entity.Population = Dto.CountryProcToTableMetadata.CreatePopulation(PopulationUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}