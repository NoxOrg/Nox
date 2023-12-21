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

using CryptocashIntegration.Application.Dto;
using CryptocashIntegration.Domain;
using CountryQueryToCustomTableEntity = CryptocashIntegration.Domain.CountryQueryToCustomTable;

namespace CryptocashIntegration.Application.Factories;

internal partial class CountryQueryToCustomTableFactory : CountryQueryToCustomTableFactoryBase
{
    public CountryQueryToCustomTableFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CountryQueryToCustomTableFactoryBase : IEntityFactory<CountryQueryToCustomTableEntity, CountryQueryToCustomTableCreateDto, CountryQueryToCustomTableUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CountryQueryToCustomTableFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CountryQueryToCustomTableEntity> CreateEntityAsync(CountryQueryToCustomTableCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(CountryQueryToCustomTableEntity entity, CountryQueryToCustomTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryQueryToCustomTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<CryptocashIntegration.Domain.CountryQueryToCustomTable> ToEntityAsync(CountryQueryToCustomTableCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new CryptocashIntegration.Domain.CountryQueryToCustomTable();
        exceptionCollector.Collect("Id",() => entity.Id = CountryQueryToCustomTableMetadata.CreateId(createDto.Id.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Population", () => entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("CreateDate", () => entity.SetIfNotNull(createDto.CreateDate, (entity) => entity.CreateDate = 
            CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateCreateDate(createDto.CreateDate.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("EditDate", () => entity.SetIfNotNull(createDto.EditDate, (entity) => entity.EditDate = 
            CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateEditDate(createDto.EditDate.NonNullValue<System.DateTimeOffset>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryQueryToCustomTableEntity entity, CountryQueryToCustomTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("Population",() => entity.Population = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("CreateDate",() => entity.CreateDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateCreateDate(updateDto.CreateDate.NonNullValue<System.DateTimeOffset>()));
        if(updateDto.EditDate is null)
        {
             entity.EditDate = null;
        }
        else
        {
            exceptionCollector.Collect("EditDate",() =>entity.EditDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateEditDate(updateDto.EditDate.ToValueFromNonNull<System.DateTimeOffset>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryQueryToCustomTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PopulationUpdateValue, "Attribute 'Population' can't be null.");
            {
                exceptionCollector.Collect("Population",() =>entity.Population = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreatePopulation(PopulationUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CreateDate", out var CreateDateUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(CreateDateUpdateValue, "Attribute 'CreateDate' can't be null.");
            {
                exceptionCollector.Collect("CreateDate",() =>entity.CreateDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateCreateDate(CreateDateUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EditDate", out var EditDateUpdateValue))
        {
            if (EditDateUpdateValue == null) { entity.EditDate = null; }
            else
            {
                exceptionCollector.Collect("EditDate",() =>entity.EditDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateEditDate(EditDateUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}