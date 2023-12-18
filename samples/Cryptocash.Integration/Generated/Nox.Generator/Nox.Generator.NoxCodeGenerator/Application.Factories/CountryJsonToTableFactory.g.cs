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
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
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
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(CountryJsonToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<CryptocashIntegration.Domain.CountryJsonToTable> ToEntityAsync(CountryJsonToTableCreateDto createDto)
    {
        var entity = new CryptocashIntegration.Domain.CountryJsonToTable();
        entity.Id = CountryJsonToTableMetadata.CreateId(createDto.Id.NonNullValue<System.Int32>());
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>()));
        entity.SetIfNotNull(createDto.CreateDate, (entity) => entity.CreateDate = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateCreateDate(createDto.CreateDate.NonNullValue<System.DateTimeOffset>()));
        entity.SetIfNotNull(createDto.EditDate, (entity) => entity.EditDate = 
            CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateEditDate(createDto.EditDate.NonNullValue<System.DateTimeOffset>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryJsonToTableEntity entity, CountryJsonToTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Population = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>());
        entity.CreateDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateCreateDate(updateDto.CreateDate.NonNullValue<System.DateTimeOffset>());
        if(updateDto.EditDate is null)
        {
             entity.EditDate = null;
        }
        else
        {
            entity.EditDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateEditDate(updateDto.EditDate.ToValueFromNonNull<System.DateTimeOffset>());
        }
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryJsonToTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Population' can't be null");
            }
            {
                entity.Population = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreatePopulation(PopulationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CreateDate", out var CreateDateUpdateValue))
        {
            if (CreateDateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'CreateDate' can't be null");
            }
            {
                entity.CreateDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateCreateDate(CreateDateUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("EditDate", out var EditDateUpdateValue))
        {
            if (EditDateUpdateValue == null) { entity.EditDate = null; }
            else
            {
                entity.EditDate = CryptocashIntegration.Domain.CountryJsonToTableMetadata.CreateEditDate(EditDateUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}