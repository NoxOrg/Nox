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

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> countrybarcodefactory,
        IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory,
        IEntityFactory<ClientApi.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> holidayfactory,
        IRepository repository
    ) : base(countrylocalnamefactory,countrybarcodefactory,countrytimezonefactory,holidayfactory, repository)
    {}
}

internal abstract class CountryFactoryBase : IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> CountryLocalNameFactory {get;}
    protected IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> CountryBarCodeFactory {get;}
    protected IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> CountryTimeZoneFactory {get;}
    protected IEntityFactory<ClientApi.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> HolidayFactory {get;}

    public CountryFactoryBase(
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> countrybarcodefactory,
        IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory,
        IEntityFactory<ClientApi.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> holidayfactory,
        IRepository repository
        )
    {
        CountryLocalNameFactory = countrylocalnamefactory;
        CountryBarCodeFactory = countrybarcodefactory;
        CountryTimeZoneFactory = countrytimezonefactory;
        HolidayFactory = holidayfactory;
        _repository = repository;
    }

    public virtual async Task<CountryEntity> CreateEntityAsync(CountryCreateDto createDto)
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

    public virtual async Task UpdateEntityAsync(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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

    public virtual void PartialUpdateEntity(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

    private async Task<ClientApi.Domain.Country> ToEntityAsync(CountryCreateDto createDto)
    {
        var entity = new ClientApi.Domain.Country();
        entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            ClientApi.Domain.CountryMetadata.CreateName(createDto.Name.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            ClientApi.Domain.CountryMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>()));
        entity.SetIfNotNull(createDto.CountryDebt, (entity) => entity.CountryDebt = 
            ClientApi.Domain.CountryMetadata.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>()));
        entity.SetIfNotNull(createDto.CapitalCityLocation, (entity) => entity.CapitalCityLocation = 
            ClientApi.Domain.CountryMetadata.CreateCapitalCityLocation(createDto.CapitalCityLocation.NonNullValue<LatLongDto>()));
        entity.SetIfNotNull(createDto.FirstLanguageCode, (entity) => entity.FirstLanguageCode = 
            ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.CountryIsoNumeric, (entity) => entity.CountryIsoNumeric = 
            ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.CountryIsoAlpha3, (entity) => entity.CountryIsoAlpha3 = 
            ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.GoogleMapsUrl, (entity) => entity.GoogleMapsUrl = 
            ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.StartOfWeek, (entity) => entity.StartOfWeek = 
            ClientApi.Domain.CountryMetadata.CreateStartOfWeek(createDto.StartOfWeek.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.Continent, (entity) => entity.Continent = 
            ClientApi.Domain.CountryMetadata.CreateContinent(createDto.Continent.NonNullValue<System.Int32>()));
        foreach (var dto in createDto.CountryLocalNames)
        {
            var newRelatedEntity = await CountryLocalNameFactory.CreateEntityAsync(dto);
            entity.CreateRefToCountryLocalNames(newRelatedEntity);
        }
        if (createDto.CountryBarCode is not null)
        {
            entity.CreateRefToCountryBarCode(await CountryBarCodeFactory.CreateEntityAsync(createDto.CountryBarCode));
        }
        foreach (var dto in createDto.CountryTimeZones)
        {
            var newRelatedEntity = await CountryTimeZoneFactory.CreateEntityAsync(dto);
            entity.CreateRefToCountryTimeZones(newRelatedEntity);
        }
        foreach (var dto in createDto.Holidays)
        {
            var newRelatedEntity = await HolidayFactory.CreateEntityAsync(dto);
            entity.CreateRefToHolidays(newRelatedEntity);
        }
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = ClientApi.Domain.CountryMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if(updateDto.Population is null)
        {
             entity.Population = null;
        }
        else
        {
            entity.Population = ClientApi.Domain.CountryMetadata.CreatePopulation(updateDto.Population.ToValueFromNonNull<System.Int32>());
        }
        if(updateDto.CountryDebt is null)
        {
             entity.CountryDebt = null;
        }
        else
        {
            entity.CountryDebt = ClientApi.Domain.CountryMetadata.CreateCountryDebt(updateDto.CountryDebt.ToValueFromNonNull<MoneyDto>());
        }
        if(updateDto.CapitalCityLocation is null)
        {
             entity.CapitalCityLocation = null;
        }
        else
        {
            entity.CapitalCityLocation = ClientApi.Domain.CountryMetadata.CreateCapitalCityLocation(updateDto.CapitalCityLocation.ToValueFromNonNull<LatLongDto>());
        }
        if(updateDto.FirstLanguageCode is null)
        {
             entity.FirstLanguageCode = null;
        }
        else
        {
            entity.FirstLanguageCode = ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(updateDto.FirstLanguageCode.ToValueFromNonNull<System.String>());
        }
        if(updateDto.CountryIsoNumeric is null)
        {
             entity.CountryIsoNumeric = null;
        }
        else
        {
            entity.CountryIsoNumeric = ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>());
        }
        if(updateDto.CountryIsoAlpha3 is null)
        {
             entity.CountryIsoAlpha3 = null;
        }
        else
        {
            entity.CountryIsoAlpha3 = ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>());
        }
        if(updateDto.GoogleMapsUrl is null)
        {
             entity.GoogleMapsUrl = null;
        }
        else
        {
            entity.GoogleMapsUrl = ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(updateDto.GoogleMapsUrl.ToValueFromNonNull<System.String>());
        }
        if(updateDto.StartOfWeek is null)
        {
             entity.StartOfWeek = null;
        }
        else
        {
            entity.StartOfWeek = ClientApi.Domain.CountryMetadata.CreateStartOfWeek(updateDto.StartOfWeek.ToValueFromNonNull<System.UInt16>());
        }
        if(updateDto.Continent is null)
        {
             entity.Continent = null;
        }
        else
        {
            entity.Continent = ClientApi.Domain.CountryMetadata.CreateContinent(updateDto.Continent.ToValueFromNonNull<System.Int32>());
        }
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
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
                var entityToUpdate = entity.CountryDebt is null ? new MoneyDto() : entity.CountryDebt.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, CountryDebtUpdateValue);
                entity.CountryDebt = ClientApi.Domain.CountryMetadata.CreateCountryDebt(entityToUpdate);
            }
        }

        if (updatedProperties.TryGetValue("CapitalCityLocation", out var CapitalCityLocationUpdateValue))
        {
            if (CapitalCityLocationUpdateValue == null) { entity.CapitalCityLocation = null; }
            else
            {
                var entityToUpdate = entity.CapitalCityLocation is null ? new LatLongDto() : entity.CapitalCityLocation.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, CapitalCityLocationUpdateValue);
                entity.CapitalCityLocation = ClientApi.Domain.CountryMetadata.CreateCapitalCityLocation(entityToUpdate);
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

	private async Task UpdateOwnedEntitiesAsync(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.CountryLocalNames.Any())
        { 
            _repository.DeleteOwned(entity.CountryLocalNames);
			entity.DeleteAllRefToCountryLocalNames();
        }
		else
		{
			var updatedCountryLocalNames = new List<ClientApi.Domain.CountryLocalName>();
			foreach(var ownedUpsertDto in updateDto.CountryLocalNames)
			{
				if(ownedUpsertDto.Id is null)
					updatedCountryLocalNames.Add(await CountryLocalNameFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = ClientApi.Domain.CountryLocalNameMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.CountryLocalNames.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("CountryLocalNames.Id", key.ToString());
					else
					{
						await CountryLocalNameFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedCountryLocalNames.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<ClientApi.Domain.CountryLocalName>(
                entity.CountryLocalNames.Where(x => !updatedCountryLocalNames.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToCountryLocalNames(updatedCountryLocalNames);
		}
		if(updateDto.CountryBarCode is null)
        {
            if(entity.CountryBarCode is not null) 
                _repository.DeleteOwned(entity.CountryBarCode);
			entity.DeleteAllRefToCountryBarCode();
        }
		else
		{
            if(entity.CountryBarCode is not null)
                await CountryBarCodeFactory.UpdateEntityAsync(entity.CountryBarCode, updateDto.CountryBarCode, cultureCode);
            else
			    entity.CreateRefToCountryBarCode(await CountryBarCodeFactory.CreateEntityAsync(updateDto.CountryBarCode));
		}
        if(!updateDto.CountryTimeZones.Any())
        { 
            _repository.DeleteOwned(entity.CountryTimeZones);
			entity.DeleteAllRefToCountryTimeZones();
        }
		else
		{
			var updatedCountryTimeZones = new List<ClientApi.Domain.CountryTimeZone>();
			foreach(var ownedUpsertDto in updateDto.CountryTimeZones)
			{
				if(ownedUpsertDto.Id is null)
					updatedCountryTimeZones.Add(await CountryTimeZoneFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = ClientApi.Domain.CountryTimeZoneMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.String>());
					var ownedEntity = entity.CountryTimeZones.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedCountryTimeZones.Add(await CountryTimeZoneFactory.CreateEntityAsync(ownedUpsertDto));
					else
					{
						await CountryTimeZoneFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedCountryTimeZones.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<ClientApi.Domain.CountryTimeZone>(
                entity.CountryTimeZones.Where(x => !updatedCountryTimeZones.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToCountryTimeZones(updatedCountryTimeZones);
		}
        if(!updateDto.Holidays.Any())
        { 
            _repository.DeleteOwned(entity.Holidays);
			entity.DeleteAllRefToHolidays();
        }
		else
		{
			var updatedHolidays = new List<ClientApi.Domain.Holiday>();
			foreach(var ownedUpsertDto in updateDto.Holidays)
			{
				if(ownedUpsertDto.Id is null)
					updatedHolidays.Add(await HolidayFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = ClientApi.Domain.HolidayMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Guid>());
					var ownedEntity = entity.Holidays.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedHolidays.Add(await HolidayFactory.CreateEntityAsync(ownedUpsertDto));
					else
					{
						await HolidayFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedHolidays.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<ClientApi.Domain.Holiday>(
                entity.Holidays.Where(x => !updatedHolidays.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToHolidays(updatedHolidays);
		}
	}
}