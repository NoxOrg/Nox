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

using ClientApi.Application.Dto;
using ClientApi.Domain;
using LanguageEntity = ClientApi.Domain.Language;

namespace ClientApi.Application.Factories;

internal partial class LanguageFactory : LanguageFactoryBase
{
    public LanguageFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class LanguageFactoryBase : IEntityFactory<LanguageEntity, LanguageCreateDto, LanguageUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public LanguageFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<LanguageEntity> CreateEntityAsync(LanguageCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(LanguageEntity entity, LanguageUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(LanguageEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<ClientApi.Domain.Language> ToEntityAsync(LanguageCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Language();
        entity.Id = LanguageMetadata.CreateId(createDto.Id);
        entity.Name = ClientApi.Domain.LanguageMetadata.CreateName(createDto.Name);
        entity.SetIfNotNull(createDto.CountryIsoNumeric, (entity) => entity.CountryIsoNumeric =ClientApi.Domain.LanguageMetadata.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.CountryIsoAlpha3, (entity) => entity.CountryIsoAlpha3 =ClientApi.Domain.LanguageMetadata.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>()));
        entity.Region = ClientApi.Domain.LanguageMetadata.CreateRegion(createDto.Region);
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(LanguageEntity entity, LanguageUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        if(IsDefaultCultureCode(cultureCode)) entity.Name = ClientApi.Domain.LanguageMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if(updateDto.CountryIsoNumeric is null)
        {
             entity.CountryIsoNumeric = null;
        }
        else
        {
            entity.CountryIsoNumeric = ClientApi.Domain.LanguageMetadata.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>());
        }
        if(updateDto.CountryIsoAlpha3 is null)
        {
             entity.CountryIsoAlpha3 = null;
        }
        else
        {
            entity.CountryIsoAlpha3 = ClientApi.Domain.LanguageMetadata.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>());
        }
        entity.Region = ClientApi.Domain.LanguageMetadata.CreateRegion(updateDto.Region.NonNullValue<System.String>());
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(LanguageEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (IsDefaultCultureCode(cultureCode) && updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.LanguageMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoNumeric", out var CountryIsoNumericUpdateValue))
        {
            if (CountryIsoNumericUpdateValue == null) { entity.CountryIsoNumeric = null; }
            else
            {
                entity.CountryIsoNumeric = ClientApi.Domain.LanguageMetadata.CreateCountryIsoNumeric(CountryIsoNumericUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoAlpha3", out var CountryIsoAlpha3UpdateValue))
        {
            if (CountryIsoAlpha3UpdateValue == null) { entity.CountryIsoAlpha3 = null; }
            else
            {
                entity.CountryIsoAlpha3 = ClientApi.Domain.LanguageMetadata.CreateCountryIsoAlpha3(CountryIsoAlpha3UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Region", out var RegionUpdateValue))
        {
            if (RegionUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Region' can't be null");
            }
            {
                entity.Region = ClientApi.Domain.LanguageMetadata.CreateRegion(RegionUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}