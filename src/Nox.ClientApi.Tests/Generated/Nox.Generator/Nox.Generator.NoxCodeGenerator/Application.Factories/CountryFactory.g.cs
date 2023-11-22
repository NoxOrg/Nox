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
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Factories;

internal abstract class CountryFactoryBase : IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    protected IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> CountryLocalNameFactory {get;}
    protected IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> CountryBarCodeFactory {get;}
    protected IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> CountryTimeZoneFactory {get;}

    public CountryFactoryBase
    (
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> countrybarcodefactory,
        IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory
        )
    {
        CountryLocalNameFactory = countrylocalnamefactory;
        CountryBarCodeFactory = countrybarcodefactory;
        CountryTimeZoneFactory = countrytimezonefactory;
    }

    public virtual CountryEntity CreateEntity(CountryCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private ClientApi.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Country();
        entity.Name = ClientApi.Domain.CountryMetadata.CreateName(createDto.Name);
        entity.SetIfNotNull(createDto.Population, (entity) => entity.Population =ClientApi.Domain.CountryMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>()));
        entity.SetIfNotNull(createDto.CountryDebt, (entity) => entity.CountryDebt =ClientApi.Domain.CountryMetadata.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>()));
        entity.SetIfNotNull(createDto.FirstLanguageCode, (entity) => entity.FirstLanguageCode =ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.CountryIsoNumeric, (entity) => entity.CountryIsoNumeric =ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.CountryIsoAlpha3, (entity) => entity.CountryIsoAlpha3 =ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.GoogleMapsUrl, (entity) => entity.GoogleMapsUrl =ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.StartOfWeek, (entity) => entity.StartOfWeek =ClientApi.Domain.CountryMetadata.CreateStartOfWeek(createDto.StartOfWeek.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.Continent, (entity) => entity.Continent =ClientApi.Domain.CountryMetadata.CreateContinent(createDto.Continent.NonNullValue<System.Int32>()));
        createDto.CountryLocalNames.ForEach(dto => entity.CreateRefToCountryLocalNames(CountryLocalNameFactory.CreateEntity(dto)));
        if (createDto.CountryBarCode is not null)
        {
            entity.CreateRefToCountryBarCode(CountryBarCodeFactory.CreateEntity(createDto.CountryBarCode));
        }
        createDto.CountryTimeZones.ForEach(dto => entity.CreateRefToCountryTimeZones(CountryTimeZoneFactory.CreateEntity(dto)));
        return entity;
    }

    private void UpdateEntityInternal(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.CountryMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.SetIfNotNull(updateDto.Population, (entity) => entity.Population = ClientApi.Domain.CountryMetadata.CreatePopulation(updateDto.Population.ToValueFromNonNull<System.Int32>()));
        entity.SetIfNotNull(updateDto.CountryDebt, (entity) => entity.CountryDebt = ClientApi.Domain.CountryMetadata.CreateCountryDebt(updateDto.CountryDebt.ToValueFromNonNull<MoneyDto>()));
        entity.SetIfNotNull(updateDto.FirstLanguageCode, (entity) => entity.FirstLanguageCode = ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(updateDto.FirstLanguageCode.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.CountryIsoNumeric, (entity) => entity.CountryIsoNumeric = ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>()));
        entity.SetIfNotNull(updateDto.CountryIsoAlpha3, (entity) => entity.CountryIsoAlpha3 = ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.GoogleMapsUrl, (entity) => entity.GoogleMapsUrl = ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(updateDto.GoogleMapsUrl.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.StartOfWeek, (entity) => entity.StartOfWeek = ClientApi.Domain.CountryMetadata.CreateStartOfWeek(updateDto.StartOfWeek.ToValueFromNonNull<System.UInt16>()));
        entity.SetIfNotNull(updateDto.Continent, (entity) => entity.Continent = ClientApi.Domain.CountryMetadata.CreateContinent(updateDto.Continent.ToValueFromNonNull<System.Int32>()));
    }

    private void PartialUpdateEntityInternal(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = ClientApi.Domain.CountryMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null) { entity.Population = null; }
            else
            {
                entity.Population = ClientApi.Domain.CountryMetadata.CreatePopulation(PopulationUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryDebt", out var CountryDebtUpdateValue))
        {
            if (CountryDebtUpdateValue == null) { entity.CountryDebt = null; }
            else
            {
                entity.CountryDebt = ClientApi.Domain.CountryMetadata.CreateCountryDebt(CountryDebtUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FirstLanguageCode", out var FirstLanguageCodeUpdateValue))
        {
            if (FirstLanguageCodeUpdateValue == null) { entity.FirstLanguageCode = null; }
            else
            {
                entity.FirstLanguageCode = ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(FirstLanguageCodeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoNumeric", out var CountryIsoNumericUpdateValue))
        {
            if (CountryIsoNumericUpdateValue == null) { entity.CountryIsoNumeric = null; }
            else
            {
                entity.CountryIsoNumeric = ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(CountryIsoNumericUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoAlpha3", out var CountryIsoAlpha3UpdateValue))
        {
            if (CountryIsoAlpha3UpdateValue == null) { entity.CountryIsoAlpha3 = null; }
            else
            {
                entity.CountryIsoAlpha3 = ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(CountryIsoAlpha3UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GoogleMapsUrl", out var GoogleMapsUrlUpdateValue))
        {
            if (GoogleMapsUrlUpdateValue == null) { entity.GoogleMapsUrl = null; }
            else
            {
                entity.GoogleMapsUrl = ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(GoogleMapsUrlUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("StartOfWeek", out var StartOfWeekUpdateValue))
        {
            if (StartOfWeekUpdateValue == null) { entity.StartOfWeek = null; }
            else
            {
                entity.StartOfWeek = ClientApi.Domain.CountryMetadata.CreateStartOfWeek(StartOfWeekUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Continent", out var ContinentUpdateValue))
        {
            if (ContinentUpdateValue == null) { entity.Continent = null; }
            else
            {
                entity.Continent = ClientApi.Domain.CountryMetadata.CreateContinent(ContinentUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> countrybarcodefactory,
        IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory
    ) : base(countrylocalnamefactory,countrybarcodefactory,countrytimezonefactory)
    {}
}