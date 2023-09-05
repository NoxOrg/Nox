// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryCreateDto : CountryUpdateDto
{
    /// <summary>
    /// Country unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

    public Country ToEntity()
    {
        var entity = new Country();
        entity.Id = Country.CreateId(Id);
        entity.Name = Country.CreateName(Name);
        if (OfficialName is not null)entity.OfficialName = Country.CreateOfficialName(OfficialName.NonNullValue<System.String>());
        if (CountryIsoNumeric is not null)entity.CountryIsoNumeric = Country.CreateCountryIsoNumeric(CountryIsoNumeric.NonNullValue<System.UInt16>());
        if (CountryIsoAlpha3 is not null)entity.CountryIsoAlpha3 = Country.CreateCountryIsoAlpha3(CountryIsoAlpha3.NonNullValue<System.String>());
        if (GeoCoords is not null)entity.GeoCoords = Country.CreateGeoCoords(GeoCoords.NonNullValue<LatLongDto>());
        if (FlagEmoji is not null)entity.FlagEmoji = Country.CreateFlagEmoji(FlagEmoji.NonNullValue<System.String>());
        if (FlagSvg is not null)entity.FlagSvg = Country.CreateFlagSvg(FlagSvg.NonNullValue<ImageDto>());
        if (FlagPng is not null)entity.FlagPng = Country.CreateFlagPng(FlagPng.NonNullValue<ImageDto>());
        if (CoatOfArmsSvg is not null)entity.CoatOfArmsSvg = Country.CreateCoatOfArmsSvg(CoatOfArmsSvg.NonNullValue<ImageDto>());
        if (CoatOfArmsPng is not null)entity.CoatOfArmsPng = Country.CreateCoatOfArmsPng(CoatOfArmsPng.NonNullValue<ImageDto>());
        if (GoogleMapsUrl is not null)entity.GoogleMapsUrl = Country.CreateGoogleMapsUrl(GoogleMapsUrl.NonNullValue<System.String>());
        if (OpenStreetMapsUrl is not null)entity.OpenStreetMapsUrl = Country.CreateOpenStreetMapsUrl(OpenStreetMapsUrl.NonNullValue<System.String>());
        entity.StartOfWeek = Country.CreateStartOfWeek(StartOfWeek);
        //entity.Currency = Currency.ToEntity();
        //entity.Commissions = Commissions.Select(dto => dto.ToEntity()).ToList();
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        //entity.Customers = Customers.Select(dto => dto.ToEntity()).ToList();
        //entity.CountryTimeZones = CountryTimeZones.Select(dto => dto.ToEntity()).ToList();
        //entity.Holidays = Holidays.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}