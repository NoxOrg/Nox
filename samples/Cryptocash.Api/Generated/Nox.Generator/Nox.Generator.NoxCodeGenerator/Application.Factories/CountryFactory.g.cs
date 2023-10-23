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

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CountryEntity = Cryptocash.Domain.Country;

namespace Cryptocash.Application.Factories;

internal abstract class CountryFactoryBase : IEntityFactory<CountryEntity, CountryCreateDto, CountryUpdateDto>
{
    protected IEntityFactory<Cryptocash.Domain.CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> CountryTimeZoneFactory {get;}
    protected IEntityFactory<Cryptocash.Domain.Holiday, HolidayCreateDto, HolidayUpdateDto> HolidayFactory {get;}

    public CountryFactoryBase
    (
        IEntityFactory<Cryptocash.Domain.CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> countrytimezonefactory,
        IEntityFactory<Cryptocash.Domain.Holiday, HolidayCreateDto, HolidayUpdateDto> holidayfactory
        )
    {
        CountryTimeZoneFactory = countrytimezonefactory;
        HolidayFactory = holidayfactory;
    }

    public virtual CountryEntity CreateEntity(CountryCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(CountryEntity entity, CountryUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(CountryEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.Country ToEntity(CountryCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Country();
        entity.Id = CountryMetadata.CreateId(createDto.Id);
        entity.Name = Cryptocash.Domain.CountryMetadata.CreateName(createDto.Name);
        if (createDto.OfficialName is not null)entity.OfficialName = Cryptocash.Domain.CountryMetadata.CreateOfficialName(createDto.OfficialName.NonNullValue<System.String>());
        if (createDto.CountryIsoNumeric is not null)entity.CountryIsoNumeric = Cryptocash.Domain.CountryMetadata.CreateCountryIsoNumeric(createDto.CountryIsoNumeric.NonNullValue<System.UInt16>());
        if (createDto.CountryIsoAlpha3 is not null)entity.CountryIsoAlpha3 = Cryptocash.Domain.CountryMetadata.CreateCountryIsoAlpha3(createDto.CountryIsoAlpha3.NonNullValue<System.String>());
        if (createDto.GeoCoords is not null)entity.GeoCoords = Cryptocash.Domain.CountryMetadata.CreateGeoCoords(createDto.GeoCoords.NonNullValue<LatLongDto>());
        if (createDto.FlagEmoji is not null)entity.FlagEmoji = Cryptocash.Domain.CountryMetadata.CreateFlagEmoji(createDto.FlagEmoji.NonNullValue<System.String>());
        if (createDto.FlagSvg is not null)entity.FlagSvg = Cryptocash.Domain.CountryMetadata.CreateFlagSvg(createDto.FlagSvg.NonNullValue<ImageDto>());
        if (createDto.FlagPng is not null)entity.FlagPng = Cryptocash.Domain.CountryMetadata.CreateFlagPng(createDto.FlagPng.NonNullValue<ImageDto>());
        if (createDto.CoatOfArmsSvg is not null)entity.CoatOfArmsSvg = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsSvg(createDto.CoatOfArmsSvg.NonNullValue<ImageDto>());
        if (createDto.CoatOfArmsPng is not null)entity.CoatOfArmsPng = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsPng(createDto.CoatOfArmsPng.NonNullValue<ImageDto>());
        if (createDto.GoogleMapsUrl is not null)entity.GoogleMapsUrl = Cryptocash.Domain.CountryMetadata.CreateGoogleMapsUrl(createDto.GoogleMapsUrl.NonNullValue<System.String>());
        if (createDto.OpenStreetMapsUrl is not null)entity.OpenStreetMapsUrl = Cryptocash.Domain.CountryMetadata.CreateOpenStreetMapsUrl(createDto.OpenStreetMapsUrl.NonNullValue<System.String>());
        entity.StartOfWeek = Cryptocash.Domain.CountryMetadata.CreateStartOfWeek(createDto.StartOfWeek);
        createDto.CountryOwnedTimeZones.ForEach(dto => entity.CreateRefToCountryOwnedTimeZones(CountryTimeZoneFactory.CreateEntity(dto)));
        createDto.CountryOwnedHolidays.ForEach(dto => entity.CreateRefToCountryOwnedHolidays(HolidayFactory.CreateEntity(dto)));
        return entity;
    }

    private void UpdateEntityInternal(CountryEntity entity, CountryUpdateDto updateDto)
    {
        entity.Name = Cryptocash.Domain.CountryMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        if (updateDto.OfficialName == null) { entity.OfficialName = null; } else {
            entity.OfficialName = Cryptocash.Domain.CountryMetadata.CreateOfficialName(updateDto.OfficialName.ToValueFromNonNull<System.String>());
        }
        if (updateDto.CountryIsoNumeric == null) { entity.CountryIsoNumeric = null; } else {
            entity.CountryIsoNumeric = Cryptocash.Domain.CountryMetadata.CreateCountryIsoNumeric(updateDto.CountryIsoNumeric.ToValueFromNonNull<System.UInt16>());
        }
        if (updateDto.CountryIsoAlpha3 == null) { entity.CountryIsoAlpha3 = null; } else {
            entity.CountryIsoAlpha3 = Cryptocash.Domain.CountryMetadata.CreateCountryIsoAlpha3(updateDto.CountryIsoAlpha3.ToValueFromNonNull<System.String>());
        }
        if (updateDto.GeoCoords == null) { entity.GeoCoords = null; } else {
            entity.GeoCoords = Cryptocash.Domain.CountryMetadata.CreateGeoCoords(updateDto.GeoCoords.ToValueFromNonNull<LatLongDto>());
        }
        if (updateDto.FlagEmoji == null) { entity.FlagEmoji = null; } else {
            entity.FlagEmoji = Cryptocash.Domain.CountryMetadata.CreateFlagEmoji(updateDto.FlagEmoji.ToValueFromNonNull<System.String>());
        }
        if (updateDto.FlagSvg == null) { entity.FlagSvg = null; } else {
            entity.FlagSvg = Cryptocash.Domain.CountryMetadata.CreateFlagSvg(updateDto.FlagSvg.ToValueFromNonNull<ImageDto>());
        }
        if (updateDto.FlagPng == null) { entity.FlagPng = null; } else {
            entity.FlagPng = Cryptocash.Domain.CountryMetadata.CreateFlagPng(updateDto.FlagPng.ToValueFromNonNull<ImageDto>());
        }
        if (updateDto.CoatOfArmsSvg == null) { entity.CoatOfArmsSvg = null; } else {
            entity.CoatOfArmsSvg = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsSvg(updateDto.CoatOfArmsSvg.ToValueFromNonNull<ImageDto>());
        }
        if (updateDto.CoatOfArmsPng == null) { entity.CoatOfArmsPng = null; } else {
            entity.CoatOfArmsPng = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsPng(updateDto.CoatOfArmsPng.ToValueFromNonNull<ImageDto>());
        }
        if (updateDto.GoogleMapsUrl == null) { entity.GoogleMapsUrl = null; } else {
            entity.GoogleMapsUrl = Cryptocash.Domain.CountryMetadata.CreateGoogleMapsUrl(updateDto.GoogleMapsUrl.ToValueFromNonNull<System.String>());
        }
        if (updateDto.OpenStreetMapsUrl == null) { entity.OpenStreetMapsUrl = null; } else {
            entity.OpenStreetMapsUrl = Cryptocash.Domain.CountryMetadata.CreateOpenStreetMapsUrl(updateDto.OpenStreetMapsUrl.ToValueFromNonNull<System.String>());
        }
        entity.StartOfWeek = Cryptocash.Domain.CountryMetadata.CreateStartOfWeek(updateDto.StartOfWeek.NonNullValue<System.UInt16>());
    }

    private void PartialUpdateEntityInternal(CountryEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = Cryptocash.Domain.CountryMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("OfficialName", out var OfficialNameUpdateValue))
        {
            if (OfficialNameUpdateValue == null) { entity.OfficialName = null; }
            else
            {
                entity.OfficialName = Cryptocash.Domain.CountryMetadata.CreateOfficialName(OfficialNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoNumeric", out var CountryIsoNumericUpdateValue))
        {
            if (CountryIsoNumericUpdateValue == null) { entity.CountryIsoNumeric = null; }
            else
            {
                entity.CountryIsoNumeric = Cryptocash.Domain.CountryMetadata.CreateCountryIsoNumeric(CountryIsoNumericUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryIsoAlpha3", out var CountryIsoAlpha3UpdateValue))
        {
            if (CountryIsoAlpha3UpdateValue == null) { entity.CountryIsoAlpha3 = null; }
            else
            {
                entity.CountryIsoAlpha3 = Cryptocash.Domain.CountryMetadata.CreateCountryIsoAlpha3(CountryIsoAlpha3UpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GeoCoords", out var GeoCoordsUpdateValue))
        {
            if (GeoCoordsUpdateValue == null) { entity.GeoCoords = null; }
            else
            {
                entity.GeoCoords = Cryptocash.Domain.CountryMetadata.CreateGeoCoords(GeoCoordsUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FlagEmoji", out var FlagEmojiUpdateValue))
        {
            if (FlagEmojiUpdateValue == null) { entity.FlagEmoji = null; }
            else
            {
                entity.FlagEmoji = Cryptocash.Domain.CountryMetadata.CreateFlagEmoji(FlagEmojiUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FlagSvg", out var FlagSvgUpdateValue))
        {
            if (FlagSvgUpdateValue == null) { entity.FlagSvg = null; }
            else
            {
                entity.FlagSvg = Cryptocash.Domain.CountryMetadata.CreateFlagSvg(FlagSvgUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FlagPng", out var FlagPngUpdateValue))
        {
            if (FlagPngUpdateValue == null) { entity.FlagPng = null; }
            else
            {
                entity.FlagPng = Cryptocash.Domain.CountryMetadata.CreateFlagPng(FlagPngUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CoatOfArmsSvg", out var CoatOfArmsSvgUpdateValue))
        {
            if (CoatOfArmsSvgUpdateValue == null) { entity.CoatOfArmsSvg = null; }
            else
            {
                entity.CoatOfArmsSvg = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsSvg(CoatOfArmsSvgUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CoatOfArmsPng", out var CoatOfArmsPngUpdateValue))
        {
            if (CoatOfArmsPngUpdateValue == null) { entity.CoatOfArmsPng = null; }
            else
            {
                entity.CoatOfArmsPng = Cryptocash.Domain.CountryMetadata.CreateCoatOfArmsPng(CoatOfArmsPngUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GoogleMapsUrl", out var GoogleMapsUrlUpdateValue))
        {
            if (GoogleMapsUrlUpdateValue == null) { entity.GoogleMapsUrl = null; }
            else
            {
                entity.GoogleMapsUrl = Cryptocash.Domain.CountryMetadata.CreateGoogleMapsUrl(GoogleMapsUrlUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("OpenStreetMapsUrl", out var OpenStreetMapsUrlUpdateValue))
        {
            if (OpenStreetMapsUrlUpdateValue == null) { entity.OpenStreetMapsUrl = null; }
            else
            {
                entity.OpenStreetMapsUrl = Cryptocash.Domain.CountryMetadata.CreateOpenStreetMapsUrl(OpenStreetMapsUrlUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("StartOfWeek", out var StartOfWeekUpdateValue))
        {
            if (StartOfWeekUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'StartOfWeek' can't be null");
            }
            {
                entity.StartOfWeek = Cryptocash.Domain.CountryMetadata.CreateStartOfWeek(StartOfWeekUpdateValue);
            }
        }
    }
}

internal partial class CountryFactory : CountryFactoryBase
{
    public CountryFactory
    (
        IEntityFactory<Cryptocash.Domain.CountryTimeZone, CountryTimeZoneCreateDto, CountryTimeZoneUpdateDto> countrytimezonefactory,
        IEntityFactory<Cryptocash.Domain.Holiday, HolidayCreateDto, HolidayUpdateDto> holidayfactory
    ) : base(countrytimezonefactory,holidayfactory)
    {}
}