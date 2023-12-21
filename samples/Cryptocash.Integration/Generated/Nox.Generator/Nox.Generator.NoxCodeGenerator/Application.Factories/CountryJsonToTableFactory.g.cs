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
using CountryJsonToTableEntity = CryptocashIntegration.Domain.CountryJsonToTable;

namespace CryptocashIntegration.Application.Factories;

internal partial class CountryJsonToTableFactory : CountryJsonToTableFactoryBase
{
    public CountryJsonToTableFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CountryJsonToTableFactoryBase : IEntityFactory<CountryJsonToTableEntity, CountryJsonToTableCreateDto, CountryJsonToTableUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CountryJsonToTableFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CountryJsonToTableEntity> CreateEntityAsync(CountryJsonToTableCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(CountryJsonToTableEntity entity, CountryJsonToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryJsonToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<CryptocashIntegration.Domain.CountryJsonToTable> ToEntityAsync(CountryJsonToTableCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new CryptocashIntegration.Domain.CountryJsonToTable();
        exceptionCollector.Collect("Id",() => entity.Id = CountryJsonToTableMetadata.CreateId(createDto.Id.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Population", () => entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("CreateDate", () => entity.SetIfNotNull(createDto.CreateDate, (entity) => entity.CreateDate = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateCreateDate(createDto.CreateDate.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("EditDate", () => entity.SetIfNotNull(createDto.EditDate, (entity) => entity.EditDate = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateEditDate(createDto.EditDate.NonNullValue<System.DateTimeOffset>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryJsonToTableEntity entity, CountryJsonToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Population",() => entity.Population = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("CreateDate",() => entity.CreateDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateCreateDate(updateDto.CreateDate.NonNullValue<System.DateTimeOffset>()));
        if(updateDto.EditDate is null)
        {
             entity.EditDate = null;
        }
        else
        {
            exceptionCollector.Collect("EditDate",() =>entity.EditDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateEditDate(updateDto.EditDate.ToValueFromNonNull<System.DateTimeOffset>()));
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
                exceptionCollector.Collect("Name",() =>entity.Name = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PopulationUpdateValue, "Attribute 'Population' can't be null.");
            {
                exceptionCollector.Collect("Population",() =>entity.Population = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreatePopulation(PopulationUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CreateDate", out var CreateDateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(CreateDateUpdateValue, "Attribute 'CreateDate' can't be null.");
            {
                exceptionCollector.Collect("CreateDate",() =>entity.CreateDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateCreateDate(CreateDateUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EditDate", out var EditDateUpdateValue))
        {
            if (EditDateUpdateValue == null) { entity.EditDate = null; }
            else
            {
                exceptionCollector.Collect("EditDate",() =>entity.EditDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateEditDate(EditDateUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}