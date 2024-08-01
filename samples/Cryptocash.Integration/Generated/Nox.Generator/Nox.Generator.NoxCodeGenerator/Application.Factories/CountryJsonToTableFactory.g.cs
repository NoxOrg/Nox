
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
using CountryJsonToTableEntity = CryptocashIntegration.Domain.CountryJsonToTable;

namespace CryptocashIntegration.Application.Factories;

internal partial class CountryJsonToTableFactory : CountryJsonToTableFactoryBase
{
    public CountryJsonToTableFactory
    (
    ) : base()
    {}
}

internal abstract class CountryJsonToTableFactoryBase : IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto>
{

    public CountryJsonToTableFactoryBase(
        )
    {
    }

    public virtual async Task<CountryJsonToTableEntity> CreateEntityAsync(CountryJsonToTableCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryJsonToTableEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CountryJsonToTableEntity entity, CountryJsonToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryJsonToTableEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CountryJsonToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryJsonToTableEntity));
        }   
    }

    private async Task<CryptocashIntegration.Domain.CountryJsonToTable> ToEntityAsync(CountryJsonToTableCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new CryptocashIntegration.Domain.CountryJsonToTable();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.CountryJsonToTableMetadata.CreateId(createDto.Id.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.CountryJsonToTableMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Population", () => entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            Dto.CountryJsonToTableMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("CreateDate", () => entity.SetIfNotNull(createDto.CreateDate, (entity) => entity.CreateDate = 
            Dto.CountryJsonToTableMetadata.CreateCreateDate(createDto.CreateDate.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("EditDate", () => entity.SetIfNotNull(createDto.EditDate, (entity) => entity.EditDate = 
            Dto.CountryJsonToTableMetadata.CreateEditDate(createDto.EditDate.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("PopulationMillions", () => entity.SetIfNotNull(createDto.PopulationMillions, (entity) => entity.PopulationMillions = 
            Dto.CountryJsonToTableMetadata.CreatePopulationMillions(createDto.PopulationMillions.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("NameWithConcurrency", () => entity.SetIfNotNull(createDto.NameWithConcurrency, (entity) => entity.NameWithConcurrency = 
            Dto.CountryJsonToTableMetadata.CreateNameWithConcurrency(createDto.NameWithConcurrency.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryJsonToTableEntity entity, CountryJsonToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.CountryJsonToTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Population",() => entity.Population = Dto.CountryJsonToTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("CreateDate",() => entity.CreateDate = Dto.CountryJsonToTableMetadata.CreateCreateDate(updateDto.CreateDate.NonNullValue<System.DateTimeOffset>()));
        if(updateDto.EditDate is null)
        {
             entity.EditDate = null;
        }
        else
        {
            exceptionCollector.Collect("EditDate",() =>entity.EditDate = Dto.CountryJsonToTableMetadata.CreateEditDate(updateDto.EditDate.ToValueFromNonNull<System.DateTimeOffset>()));
        }
        if(updateDto.PopulationMillions is null)
        {
             entity.PopulationMillions = null;
        }
        else
        {
            exceptionCollector.Collect("PopulationMillions",() =>entity.PopulationMillions = Dto.CountryJsonToTableMetadata.CreatePopulationMillions(updateDto.PopulationMillions.ToValueFromNonNull<System.Int32>()));
        }
        if(updateDto.NameWithConcurrency is null)
        {
             entity.NameWithConcurrency = null;
        }
        else
        {
            exceptionCollector.Collect("NameWithConcurrency",() =>entity.NameWithConcurrency = Dto.CountryJsonToTableMetadata.CreateNameWithConcurrency(updateDto.NameWithConcurrency.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryJsonToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.CountryJsonToTableMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PopulationUpdateValue, "Attribute 'Population' can't be null.");
            {
                exceptionCollector.Collect("Population",() =>entity.Population = Dto.CountryJsonToTableMetadata.CreatePopulation(PopulationUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CreateDate", out var CreateDateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(CreateDateUpdateValue, "Attribute 'CreateDate' can't be null.");
            {
                exceptionCollector.Collect("CreateDate",() =>entity.CreateDate = Dto.CountryJsonToTableMetadata.CreateCreateDate(CreateDateUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EditDate", out var EditDateUpdateValue))
        {
            if (EditDateUpdateValue == null) { entity.EditDate = null; }
            else
            {
                exceptionCollector.Collect("EditDate",() =>entity.EditDate = Dto.CountryJsonToTableMetadata.CreateEditDate(EditDateUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PopulationMillions", out var PopulationMillionsUpdateValue))
        {
            if (PopulationMillionsUpdateValue == null) { entity.PopulationMillions = null; }
            else
            {
                exceptionCollector.Collect("PopulationMillions",() =>entity.PopulationMillions = Dto.CountryJsonToTableMetadata.CreatePopulationMillions(PopulationMillionsUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("NameWithConcurrency", out var NameWithConcurrencyUpdateValue))
        {
            if (NameWithConcurrencyUpdateValue == null) { entity.NameWithConcurrency = null; }
            else
            {
                exceptionCollector.Collect("NameWithConcurrency",() =>entity.NameWithConcurrency = Dto.CountryJsonToTableMetadata.CreateNameWithConcurrency(NameWithConcurrencyUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}