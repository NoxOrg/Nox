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
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
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
        var entity = new CryptocashIntegration.Domain.CountryQueryToCustomTable();
        entity.Id = CountryQueryToCustomTableMetadata.CreateId(createDto.Id);
        entity.Name = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateName(createDto.Name);
        entity.Population = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreatePopulation(createDto.Population);
        entity.CreateDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateCreateDate(createDto.CreateDate);
        entity.SetIfNotNull(createDto.EditDate, (entity) => entity.EditDate =CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateEditDate(createDto.EditDate.NonNullValue<System.DateTimeOffset>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryQueryToCustomTableEntity entity, CountryQueryToCustomTableUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.Population = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>());
        entity.CreateDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateCreateDate(updateDto.CreateDate.NonNullValue<System.DateTimeOffset>());
        if(updateDto.EditDate is null)
        {
             entity.EditDate = null;
        }
        else
        {
            entity.EditDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateEditDate(updateDto.EditDate.ToValueFromNonNull<System.DateTimeOffset>());
        }
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CountryQueryToCustomTableEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Population' can't be null");
            }
            {
                entity.Population = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreatePopulation(PopulationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CreateDate", out var CreateDateUpdateValue))
        {
            if (CreateDateUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'CreateDate' can't be null");
            }
            {
                entity.CreateDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateCreateDate(CreateDateUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("EditDate", out var EditDateUpdateValue))
        {
            if (EditDateUpdateValue == null) { entity.EditDate = null; }
            else
            {
                entity.EditDate = CryptocashIntegration.Domain.CountryQueryToCustomTableMetadata.CreateEditDate(EditDateUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}