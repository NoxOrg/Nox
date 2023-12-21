
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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Factories;

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IRepository repository,
        IEntityFactory<Cryptocash.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory,
        IEntityFactory<Cryptocash.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> holidayfactory
    ) : base(repository, countrytimezonefactory, holidayfactory)
    {}
}

internal abstract class CountryFactoryBase : IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<Cryptocash.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> CountryTimeZoneFactory {get;}
    protected IEntityFactory<Cryptocash.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> HolidayFactory {get;}

    public CountryFactoryBase(
        IRepository repository,
        IEntityFactory<Cryptocash.Domain.CountryTimeZone, CountryTimeZoneUpsertDto, CountryTimeZoneUpsertDto> countrytimezonefactory,
        IEntityFactory<Cryptocash.Domain.Holiday, HolidayUpsertDto, HolidayUpsertDto> holidayfactory
        )
    {
        _repository = repository;
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

    private async Task<Cryptocash.Domain.Country> ToEntityAsync(CountryCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Country();
        exceptionCollector.Collect("Id",() => entity.Id = CountryMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Cryptocash.Domain.CountryMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("OfficialName", () => entity.SetIfNotNull(createDto.OfficialName, (entity) => entity.OfficialName = 
            Cryptocash.Domain.CountryMetadata.CreateOfficialName(createDto.OfficialName.NonNullValue<System.String>())));
        exceptionCollector.Collect("CountryIsoNumeric", () => entity.SetIfNotNull(createDto.CountryIsoNumeric, (entity) => entity.CountryIsoNumeric = 
            Cryptocash.Domain.CountryMetadata.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>())));
        exceptionCollector.Collect("CountryIsoAlpha3", () => entity.SetIfNotNull(createDto.CountryIsoAlpha3, (entity) => entity.CountryIsoAlpha3 = 
            Cryptocash.Domain.CountryMetadata.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>())));
        exceptionCollector.Collect("GeoCoords", () => entity.SetIfNotNull(createDto.GeoCoords, (entity) => entity.GeoCoords = 
            Cryptocash.Domain.CountryMetadata.CreateGeoCoords(createDto.GeoCoords.NonNullValue<LatLongDto>())));
        exceptionCollector.Collect("FlagEmoji", () => entity.SetIfNotNull(createDto.FlagEmoji, (entity) => entity.FlagEmoji = 
            Cryptocash.Domain.CountryMetadata.CreateFlagEmoji(createDto.FlagEmoji.NonNullValue<System.String>())));
        exceptionCollector.Collect("FlagSvg", () => entity.SetIfNotNull(createDto.FlagSvg, (entity) => entity.FlagSvg = 
            Cryptocash.Domain.CountryMetadata.CreateFlagSvg(createDto.FlagSvg.NonNullValue<ImageDto>())));
        exceptionCollector.Collect("FlagPng", () => entity.SetIfNotNull(createDto.FlagPng, (entity) => entity.FlagPng = 
            Cryptocash.Domain.CountryMetadata.CreateFlagPng(createDto.FlagPng.NonNullValue<ImageDto>())));
        exceptionCollector.Collect("CoatOfArmsSvg", () => entity.SetIfNotNull(createDto.CoatOfArmsSvg, (entity) => entity.CoatOfArmsSvg = 
            Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsSvg(createDto.CoatOfArmsSvg.NonNullValue<ImageDto>())));
        exceptionCollector.Collect("CoatOfArmsPng", () => entity.SetIfNotNull(createDto.CoatOfArmsPng, (entity) => entity.CoatOfArmsPng = 
            Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsPng(createDto.CoatOfArmsPng.NonNullValue<ImageDto>())));
        exceptionCollector.Collect("GoogleMapsUrl", () => entity.SetIfNotNull(createDto.GoogleMapsUrl, (entity) => entity.GoogleMapsUrl = 
            Cryptocash.Domain.CountryMetadata.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>())));
        exceptionCollector.Collect("OpenStreetMapsUrl", () => entity.SetIfNotNull(createDto.OpenStreetMapsUrl, (entity) => entity.OpenStreetMapsUrl = 
            Cryptocash.Domain.CountryMetadata.CreateOpenStreetMapsUrl(createDto.OpenStreetMapsUrl.NonNullValue<System.String>())));
        exceptionCollector.Collect("StartOfWeek", () => entity.SetIfNotNull(createDto.StartOfWeek, (entity) => entity.StartOfWeek = 
            Cryptocash.Domain.CountryMetadata.CreateStartOfWeek(createDto.StartOfWeek.NonNullValue<System.UInt16>())));
        exceptionCollector.Collect("Population", () => entity.SetIfNotNull(createDto.Population, (entity) => entity.Population = 
            Cryptocash.Domain.CountryMetadata.CreatePopulation(createDto.Population.NonNullValue<System.Int32>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        createDto.CountryTimeZones?.ForEach(async dto =>
        {
            var countryTimeZone = await CountryTimeZoneFactory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefToCountryTimeZones(countryTimeZone);
        });
        createDto.Holidays?.ForEach(async dto =>
        {
            var holiday = await HolidayFactory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefToHolidays(holiday);
        });        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Cryptocash.Domain.CountryMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        if(updateDto.OfficialName is null)
        {
             entity.OfficialName = null;
        }
        else
        {
            exceptionCollector.Collect("OfficialName",() =>entity.OfficialName = Cryptocash.Domain.CountryMetadata.CreateOfficialName(updateDto.OfficialName.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.CountryIsoNumeric is null)
        {
             entity.CountryIsoNumeric = null;
        }
        else
        {
            exceptionCollector.Collect("CountryIsoNumeric",() =>entity.CountryIsoNumeric = Cryptocash.Domain.CountryMetadata.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>()));
        }
        if(updateDto.CountryIsoAlpha3 is null)
        {
             entity.CountryIsoAlpha3 = null;
        }
        else
        {
            exceptionCollector.Collect("CountryIsoAlpha3",() =>entity.CountryIsoAlpha3 = Cryptocash.Domain.CountryMetadata.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.GeoCoords is null)
        {
             entity.GeoCoords = null;
        }
        else
        {
            exceptionCollector.Collect("GeoCoords",() =>entity.GeoCoords = Cryptocash.Domain.CountryMetadata.CreateGeoCoords(updateDto.GeoCoords.ToValueFromNonNull<LatLongDto>()));
        }
        if(updateDto.FlagEmoji is null)
        {
             entity.FlagEmoji = null;
        }
        else
        {
            exceptionCollector.Collect("FlagEmoji",() =>entity.FlagEmoji = Cryptocash.Domain.CountryMetadata.CreateFlagEmoji(updateDto.FlagEmoji.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.FlagSvg is null)
        {
             entity.FlagSvg = null;
        }
        else
        {
            exceptionCollector.Collect("FlagSvg",() =>entity.FlagSvg = Cryptocash.Domain.CountryMetadata.CreateFlagSvg(updateDto.FlagSvg.ToValueFromNonNull<ImageDto>()));
        }
        if(updateDto.FlagPng is null)
        {
             entity.FlagPng = null;
        }
        else
        {
            exceptionCollector.Collect("FlagPng",() =>entity.FlagPng = Cryptocash.Domain.CountryMetadata.CreateFlagPng(updateDto.FlagPng.ToValueFromNonNull<ImageDto>()));
        }
        if(updateDto.CoatOfArmsSvg is null)
        {
             entity.CoatOfArmsSvg = null;
        }
        else
        {
            exceptionCollector.Collect("CoatOfArmsSvg",() =>entity.CoatOfArmsSvg = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsSvg(updateDto.CoatOfArmsSvg.ToValueFromNonNull<ImageDto>()));
        }
        if(updateDto.CoatOfArmsPng is null)
        {
             entity.CoatOfArmsPng = null;
        }
        else
        {
            exceptionCollector.Collect("CoatOfArmsPng",() =>entity.CoatOfArmsPng = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsPng(updateDto.CoatOfArmsPng.ToValueFromNonNull<ImageDto>()));
        }
        if(updateDto.GoogleMapsUrl is null)
        {
             entity.GoogleMapsUrl = null;
        }
        else
        {
            exceptionCollector.Collect("GoogleMapsUrl",() =>entity.GoogleMapsUrl = Cryptocash.Domain.CountryMetadata.CreateGoogleMapsUrl(updateDto.GoogleMapsUrl.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.OpenStreetMapsUrl is null)
        {
             entity.OpenStreetMapsUrl = null;
        }
        else
        {
            exceptionCollector.Collect("OpenStreetMapsUrl",() =>entity.OpenStreetMapsUrl = Cryptocash.Domain.CountryMetadata.CreateOpenStreetMapsUrl(updateDto.OpenStreetMapsUrl.ToValueFromNonNull<System.String>()));
        }
        exceptionCollector.Collect("StartOfWeek",() => entity.StartOfWeek = Cryptocash.Domain.CountryMetadata.CreateStartOfWeek(updateDto.StartOfWeek.NonNullValue<System.UInt16>()));
        exceptionCollector.Collect("Population",() => entity.Population = Cryptocash.Domain.CountryMetadata.CreatePopulation(updateDto.Population.NonNullValue<System.Int32>()));

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
                exceptionCollector.Collect("Name",() =>entity.Name = Cryptocash.Domain.CountryMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("OfficialName", out var OfficialNameUpdateValue))
        {
            if (OfficialNameUpdateValue == null) { entity.OfficialName = null; }
            else
            {
                exceptionCollector.Collect("OfficialName",() =>entity.OfficialName = Cryptocash.Domain.CountryMetadata.CreateOfficialName(OfficialNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoNumeric", out var CountryIsoNumericUpdateValue))
        {
            if (CountryIsoNumericUpdateValue == null) { entity.CountryIsoNumeric = null; }
            else
            {
                exceptionCollector.Collect("CountryIsoNumeric",() =>entity.CountryIsoNumeric = Cryptocash.Domain.CountryMetadata.CreateCountryIsoNumeric(CountryIsoNumericUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoAlpha3", out var CountryIsoAlpha3UpdateValue))
        {
            if (CountryIsoAlpha3UpdateValue == null) { entity.CountryIsoAlpha3 = null; }
            else
            {
                exceptionCollector.Collect("CountryIsoAlpha3",() =>entity.CountryIsoAlpha3 = Cryptocash.Domain.CountryMetadata.CreateCountryIsoAlpha3(CountryIsoAlpha3UpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("GeoCoords", out var GeoCoordsUpdateValue))
        {
            if (GeoCoordsUpdateValue == null) { entity.GeoCoords = null; }
            else
            {
                var entityToUpdate = entity.GeoCoords is null ? new LatLongDto() : entity.GeoCoords.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, GeoCoordsUpdateValue);
                exceptionCollector.Collect("GeoCoords",() =>entity.GeoCoords = Cryptocash.Domain.CountryMetadata.CreateGeoCoords(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("FlagEmoji", out var FlagEmojiUpdateValue))
        {
            if (FlagEmojiUpdateValue == null) { entity.FlagEmoji = null; }
            else
            {
                exceptionCollector.Collect("FlagEmoji",() =>entity.FlagEmoji = Cryptocash.Domain.CountryMetadata.CreateFlagEmoji(FlagEmojiUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("FlagSvg", out var FlagSvgUpdateValue))
        {
            if (FlagSvgUpdateValue == null) { entity.FlagSvg = null; }
            else
            {
                var entityToUpdate = entity.FlagSvg is null ? new ImageDto() : entity.FlagSvg.ToDto();
                ImageDto.UpdateFromDictionary(entityToUpdate, FlagSvgUpdateValue);
                exceptionCollector.Collect("FlagSvg",() =>entity.FlagSvg = Cryptocash.Domain.CountryMetadata.CreateFlagSvg(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("FlagPng", out var FlagPngUpdateValue))
        {
            if (FlagPngUpdateValue == null) { entity.FlagPng = null; }
            else
            {
                var entityToUpdate = entity.FlagPng is null ? new ImageDto() : entity.FlagPng.ToDto();
                ImageDto.UpdateFromDictionary(entityToUpdate, FlagPngUpdateValue);
                exceptionCollector.Collect("FlagPng",() =>entity.FlagPng = Cryptocash.Domain.CountryMetadata.CreateFlagPng(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("CoatOfArmsSvg", out var CoatOfArmsSvgUpdateValue))
        {
            if (CoatOfArmsSvgUpdateValue == null) { entity.CoatOfArmsSvg = null; }
            else
            {
                var entityToUpdate = entity.CoatOfArmsSvg is null ? new ImageDto() : entity.CoatOfArmsSvg.ToDto();
                ImageDto.UpdateFromDictionary(entityToUpdate, CoatOfArmsSvgUpdateValue);
                exceptionCollector.Collect("CoatOfArmsSvg",() =>entity.CoatOfArmsSvg = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsSvg(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("CoatOfArmsPng", out var CoatOfArmsPngUpdateValue))
        {
            if (CoatOfArmsPngUpdateValue == null) { entity.CoatOfArmsPng = null; }
            else
            {
                var entityToUpdate = entity.CoatOfArmsPng is null ? new ImageDto() : entity.CoatOfArmsPng.ToDto();
                ImageDto.UpdateFromDictionary(entityToUpdate, CoatOfArmsPngUpdateValue);
                exceptionCollector.Collect("CoatOfArmsPng",() =>entity.CoatOfArmsPng = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsPng(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("GoogleMapsUrl", out var GoogleMapsUrlUpdateValue))
        {
            if (GoogleMapsUrlUpdateValue == null) { entity.GoogleMapsUrl = null; }
            else
            {
                exceptionCollector.Collect("GoogleMapsUrl",() =>entity.GoogleMapsUrl = Cryptocash.Domain.CountryMetadata.CreateGoogleMapsUrl(GoogleMapsUrlUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("OpenStreetMapsUrl", out var OpenStreetMapsUrlUpdateValue))
        {
            if (OpenStreetMapsUrlUpdateValue == null) { entity.OpenStreetMapsUrl = null; }
            else
            {
                exceptionCollector.Collect("OpenStreetMapsUrl",() =>entity.OpenStreetMapsUrl = Cryptocash.Domain.CountryMetadata.CreateOpenStreetMapsUrl(OpenStreetMapsUrlUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("StartOfWeek", out var StartOfWeekUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(StartOfWeekUpdateValue, "Attribute 'StartOfWeek' can't be null.");
            {
                exceptionCollector.Collect("StartOfWeek",() =>entity.StartOfWeek = Cryptocash.Domain.CountryMetadata.CreateStartOfWeek(StartOfWeekUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Population", out var PopulationUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(PopulationUpdateValue, "Attribute 'Population' can't be null.");
            {
                exceptionCollector.Collect("Population",() =>entity.Population = Cryptocash.Domain.CountryMetadata.CreatePopulation(PopulationUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

	private async Task UpdateOwnedEntitiesAsync(CountryEntity entity, CountryUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.CountryTimeZones.Any())
        { 
            _repository.DeleteOwned(entity.CountryTimeZones);
			entity.DeleteAllRefToCountryTimeZones();
        }
		else
		{
			var updatedCountryTimeZones = new List<Cryptocash.Domain.CountryTimeZone>();
			foreach(var ownedUpsertDto in updateDto.CountryTimeZones)
			{
				if(ownedUpsertDto.Id is null)
                {
                    var ownedEntity = await CountryTimeZoneFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedCountryTimeZones.Add(ownedEntity);
                }
				else
				{
					var key = Cryptocash.Domain.CountryTimeZoneMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.CountryTimeZones.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("CountryTimeZones.Id", key.ToString());
					else
					{
						await CountryTimeZoneFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedCountryTimeZones.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<Cryptocash.Domain.CountryTimeZone>(
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
			var updatedHolidays = new List<Cryptocash.Domain.Holiday>();
			foreach(var ownedUpsertDto in updateDto.Holidays)
			{
				if(ownedUpsertDto.Id is null)
                {
                    var ownedEntity = await HolidayFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedHolidays.Add(ownedEntity);
                }
				else
				{
					var key = Cryptocash.Domain.HolidayMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.Holidays.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("Holidays.Id", key.ToString());
					else
					{
						await HolidayFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedHolidays.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<Cryptocash.Domain.Holiday>(
                entity.Holidays.Where(x => !updatedHolidays.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToHolidays(updatedHolidays);
		}
	}
}