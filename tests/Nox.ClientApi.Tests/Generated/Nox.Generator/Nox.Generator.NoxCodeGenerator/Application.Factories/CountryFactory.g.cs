
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
using Dto = ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryEntity = ClientApi.Domain.Country;

namespace ClientApi.Application.Factories;

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IRepository repository,
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> countrybarcodefactory,
        IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory,
        IEntityFactory<ClientApi.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> holidayfactory
    ) : base(repository, countrylocalnamefactory, countrybarcodefactory, countrytimezonefactory, holidayfactory)
    {}
}

internal abstract class CountryFactoryBase : IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> CountryLocalNameFactory {get;}
    protected IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> CountryBarCodeFactory {get;}
    protected IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> CountryTimeZoneFactory {get;}
    protected IEntityFactory<ClientApi.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> HolidayFactory {get;}

    public CountryFactoryBase(
        IRepository repository,
        IEntityFactory<ClientApi.Domain.CountryLocalName, CountryLocalNameUpsertDto, CountryLocalNameUpsertDto> countrylocalnamefactory,
        IEntityFactory<ClientApi.Domain.CountryBarCode, CountryBarCodeUpsertDto, CountryBarCodeUpsertDto> countrybarcodefactory,
        IEntityFactory<ClientApi.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory,
        IEntityFactory<ClientApi.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> holidayfactory
        )
    {
        _repository = repository;
        CountryLocalNameFactory = countrylocalnamefactory;
        CountryBarCodeFactory = countrybarcodefactory;
        CountryTimeZoneFactory = countrytimezonefactory;
        HolidayFactory = holidayfactory;
    }

    public virtual async Task<CountryEntity> CreateEntityAsync(CountryCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryEntity));
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
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CountryEntity));
        }   
    }

    private async Task<ClientApi.Domain.Country> ToEntityAsync(CountryCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new ClientApi.Domain.Country();
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.CountryMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("Population", () => entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            Dto.CountryMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("CountryDebt", () => entity.SetIfNotNull(createDto.CountryDebt, (entity) => entity.CountryDebt = 
            Dto.CountryMetadata.CreateCountryDebt(createDto.CountryDebt.NonNullValue<MoneyDto>())));
        exceptionCollector.Collect("CapitalCityLocation", () => entity.SetIfNotNull(createDto.CapitalCityLocation, (entity) => entity.CapitalCityLocation = 
            Dto.CountryMetadata.CreateCapitalCityLocation(createDto.CapitalCityLocation.NonNullValue<LatLongDto>())));
        exceptionCollector.Collect("FirstLanguageCode", () => entity.SetIfNotNull(createDto.FirstLanguageCode, (entity) => entity.FirstLanguageCode = 
            Dto.CountryMetadata.CreateFirstLanguageCode(createDto.FirstLanguageCode.NonNullValue<System.String>())));
        exceptionCollector.Collect("CountryIsoNumeric", () => entity.SetIfNotNull(createDto.CountryIsoNumeric, (entity) => entity.CountryIsoNumeric = 
            Dto.CountryMetadata.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>())));
        exceptionCollector.Collect("CountryIsoAlpha3", () => entity.SetIfNotNull(createDto.CountryIsoAlpha3, (entity) => entity.CountryIsoAlpha3 = 
            Dto.CountryMetadata.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>())));
        exceptionCollector.Collect("GoogleMapsUrl", () => entity.SetIfNotNull(createDto.GoogleMapsUrl, (entity) => entity.GoogleMapsUrl = 
            Dto.CountryMetadata.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>())));
        exceptionCollector.Collect("StartOfWeek", () => entity.SetIfNotNull(createDto.StartOfWeek, (entity) => entity.StartOfWeek = 
            Dto.CountryMetadata.CreateStartOfWeek(createDto.StartOfWeek.NonNullValue<System.UInt16>())));
        exceptionCollector.Collect("Continent", () => entity.SetIfNotNull(createDto.Continent, (entity) => entity.Continent = 
            Dto.CountryMetadata.CreateContinent(createDto.Continent.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        //createDto.CountryLocalNames?.ForEach(async dto =>
        //{
        //    var countryLocalName = await CountryLocalNameFactory.CreateEntityAsync(dto, cultureCode);
        //    entity.CreateRefToCountryLocalNames(countryLocalName);
        //});
        if(createDto.CountryLocalNames is not null)
        {
            foreach (var dto in createDto.CountryLocalNames)
            {
                var countryLocalName = CountryLocalNameFactory.CreateEntityAsync(dto, cultureCode).Result;
                entity.CreateRefToCountryLocalNames(countryLocalName);
            }
        }
        if (createDto.CountryBarCode is not null)
        {
            var countryBarCode = await CountryBarCodeFactory.CreateEntityAsync(createDto.CountryBarCode, cultureCode);
            entity.CreateRefToCountryBarCode(countryBarCode);
        }
        //createDto.CountryTimeZones?.ForEach(async dto =>
        //{
        //    var countryTimeZone = await CountryTimeZoneFactory.CreateEntityAsync(dto, cultureCode);
        //    entity.CreateRefToCountryTimeZones(countryTimeZone);
        //});
        if(createDto.CountryTimeZones is not null)
        {
            foreach (var dto in createDto.CountryTimeZones)
            {
                var countryTimeZone = CountryTimeZoneFactory.CreateEntityAsync(dto, cultureCode).Result;
                entity.CreateRefToCountryTimeZones(countryTimeZone);
            }
        }
        //createDto.Holidays?.ForEach(async dto =>
        //{
        //    var holiday = await HolidayFactory.CreateEntityAsync(dto, cultureCode);
        //    entity.CreateRefToHolidays(holiday);
        //});
        if(createDto.Holidays is not null)
        {
            foreach (var dto in createDto.Holidays)
            {
                var holiday = HolidayFactory.CreateEntityAsync(dto, cultureCode).Result;
                entity.CreateRefToHolidays(holiday);
            }
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.CountryMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(updateDto.Population is null)
        {
             entity.Population = null;
        }
        else
        {
            exceptionCollector.Collect("Population",() =>entity.Population = Dto.CountryMetadata.CreatePopulation(updateDto.Population.ToValueFromNonNull<System.Int32>()));
        }
        if(updateDto.CountryDebt is null)
        {
             entity.CountryDebt = null;
        }
        else
        {
            exceptionCollector.Collect("CountryDebt",() =>entity.CountryDebt = Dto.CountryMetadata.CreateCountryDebt(updateDto.CountryDebt.ToValueFromNonNull<MoneyDto>()));
        }
        if(updateDto.CapitalCityLocation is null)
        {
             entity.CapitalCityLocation = null;
        }
        else
        {
            exceptionCollector.Collect("CapitalCityLocation",() =>entity.CapitalCityLocation = Dto.CountryMetadata.CreateCapitalCityLocation(updateDto.CapitalCityLocation.ToValueFromNonNull<LatLongDto>()));
        }
        if(updateDto.FirstLanguageCode is null)
        {
             entity.FirstLanguageCode = null;
        }
        else
        {
            exceptionCollector.Collect("FirstLanguageCode",() =>entity.FirstLanguageCode = Dto.CountryMetadata.CreateFirstLanguageCode(updateDto.FirstLanguageCode.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.CountryIsoNumeric is null)
        {
             entity.CountryIsoNumeric = null;
        }
        else
        {
            exceptionCollector.Collect("CountryIsoNumeric",() =>entity.CountryIsoNumeric = Dto.CountryMetadata.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>()));
        }
        if(updateDto.CountryIsoAlpha3 is null)
        {
             entity.CountryIsoAlpha3 = null;
        }
        else
        {
            exceptionCollector.Collect("CountryIsoAlpha3",() =>entity.CountryIsoAlpha3 = Dto.CountryMetadata.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.GoogleMapsUrl is null)
        {
             entity.GoogleMapsUrl = null;
        }
        else
        {
            exceptionCollector.Collect("GoogleMapsUrl",() =>entity.GoogleMapsUrl = Dto.CountryMetadata.CreateGoogleMapsUrl(updateDto.GoogleMapsUrl.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.StartOfWeek is null)
        {
             entity.StartOfWeek = null;
        }
        else
        {
            exceptionCollector.Collect("StartOfWeek",() =>entity.StartOfWeek = Dto.CountryMetadata.CreateStartOfWeek(updateDto.StartOfWeek.ToValueFromNonNull<System.UInt16>()));
        }
        if(updateDto.Continent is null)
        {
             entity.Continent = null;
        }
        else
        {
            exceptionCollector.Collect("Continent",() =>entity.Continent = Dto.CountryMetadata.CreateContinent(updateDto.Continent.ToValueFromNonNull<System.Int32>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(CountryEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.CountryMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            if (PopulationUpdateValue == null) { entity.Population = null; }
            else
            {
                exceptionCollector.Collect("Population",() =>entity.Population = Dto.CountryMetadata.CreatePopulation(PopulationUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CountryDebt", out var CountryDebtUpdateValue))
        {
            if (CountryDebtUpdateValue == null) { entity.CountryDebt = null; }
            else
            {
                var entityToUpdate = entity.CountryDebt is null ? new MoneyDto() : entity.CountryDebt.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, CountryDebtUpdateValue);
                exceptionCollector.Collect("CountryDebt",() =>entity.CountryDebt = Dto.CountryMetadata.CreateCountryDebt(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("CapitalCityLocation", out var CapitalCityLocationUpdateValue))
        {
            if (CapitalCityLocationUpdateValue == null) { entity.CapitalCityLocation = null; }
            else
            {
                var entityToUpdate = entity.CapitalCityLocation is null ? new LatLongDto() : entity.CapitalCityLocation.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, CapitalCityLocationUpdateValue);
                exceptionCollector.Collect("CapitalCityLocation",() =>entity.CapitalCityLocation = Dto.CountryMetadata.CreateCapitalCityLocation(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("FirstLanguageCode", out var FirstLanguageCodeUpdateValue))
        {
            if (FirstLanguageCodeUpdateValue == null) { entity.FirstLanguageCode = null; }
            else
            {
                exceptionCollector.Collect("FirstLanguageCode",() =>entity.FirstLanguageCode = Dto.CountryMetadata.CreateFirstLanguageCode(FirstLanguageCodeUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoNumeric", out var CountryIsoNumericUpdateValue))
        {
            if (CountryIsoNumericUpdateValue == null) { entity.CountryIsoNumeric = null; }
            else
            {
                exceptionCollector.Collect("CountryIsoNumeric",() =>entity.CountryIsoNumeric = Dto.CountryMetadata.CreateCountryIsoNumeric(CountryIsoNumericUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoAlpha3", out var CountryIsoAlpha3UpdateValue))
        {
            if (CountryIsoAlpha3UpdateValue == null) { entity.CountryIsoAlpha3 = null; }
            else
            {
                exceptionCollector.Collect("CountryIsoAlpha3",() =>entity.CountryIsoAlpha3 = Dto.CountryMetadata.CreateCountryIsoAlpha3(CountryIsoAlpha3UpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("GoogleMapsUrl", out var GoogleMapsUrlUpdateValue))
        {
            if (GoogleMapsUrlUpdateValue == null) { entity.GoogleMapsUrl = null; }
            else
            {
                exceptionCollector.Collect("GoogleMapsUrl",() =>entity.GoogleMapsUrl = Dto.CountryMetadata.CreateGoogleMapsUrl(GoogleMapsUrlUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("StartOfWeek", out var StartOfWeekUpdateValue))
        {
            if (StartOfWeekUpdateValue == null) { entity.StartOfWeek = null; }
            else
            {
                exceptionCollector.Collect("StartOfWeek",() =>entity.StartOfWeek = Dto.CountryMetadata.CreateStartOfWeek(StartOfWeekUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Continent", out var ContinentUpdateValue))
        {
            if (ContinentUpdateValue == null) { entity.Continent = null; }
            else
            {
                exceptionCollector.Collect("Continent",() =>entity.Continent = Dto.CountryMetadata.CreateContinent(ContinentUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

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
                {
                    var ownedEntity = await CountryLocalNameFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedCountryLocalNames.Add(ownedEntity);
                }
				else
				{
					var key = Dto.CountryLocalNameMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
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
                entity.CountryLocalNames.Where(x => !updatedCountryLocalNames.Exists(upd => upd.Id == x.Id)).ToList());
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
			    entity.CreateRefToCountryBarCode(await CountryBarCodeFactory.CreateEntityAsync(updateDto.CountryBarCode, cultureCode));
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
                {
                    var ownedEntity = await CountryTimeZoneFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedCountryTimeZones.Add(ownedEntity);
                }
				else
				{
					var key = Dto.CountryTimeZoneMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.String>());
					var ownedEntity = entity.CountryTimeZones.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedCountryTimeZones.Add(await CountryTimeZoneFactory.CreateEntityAsync(ownedUpsertDto, cultureCode));
					else
					{
						await CountryTimeZoneFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedCountryTimeZones.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<ClientApi.Domain.CountryTimeZone>(
                entity.CountryTimeZones.Where(x => !updatedCountryTimeZones.Exists(upd => upd.Id == x.Id)).ToList());
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
                {
                    var ownedEntity = await HolidayFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedHolidays.Add(ownedEntity);
                }
				else
				{
					var key = Dto.HolidayMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Guid>());
					var ownedEntity = entity.Holidays.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						updatedHolidays.Add(await HolidayFactory.CreateEntityAsync(ownedUpsertDto, cultureCode));
					else
					{
						await HolidayFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedHolidays.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<ClientApi.Domain.Holiday>(
                entity.Holidays.Where(x => !updatedHolidays.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToHolidays(updatedHolidays);
		}
	}
}