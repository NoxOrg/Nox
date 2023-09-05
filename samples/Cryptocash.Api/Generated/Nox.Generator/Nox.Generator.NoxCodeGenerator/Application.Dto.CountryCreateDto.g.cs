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
public partial class CountryCreateDto 
{
    /// <summary>
    /// Country unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;    
    /// <summary>
    /// Country's name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;    
    /// <summary>
    /// Country's official name (Optional).
    /// </summary>
    public System.String? OfficialName { get; set; }    
    /// <summary>
    /// Country's iso number id (Optional).
    /// </summary>
    public System.UInt16? CountryIsoNumeric { get; set; }    
    /// <summary>
    /// Country's iso alpha3 id (Optional).
    /// </summary>
    public System.String? CountryIsoAlpha3 { get; set; }    
    /// <summary>
    /// Country's geo coordinates (Optional).
    /// </summary>
    public LatLongDto? GeoCoords { get; set; }    
    /// <summary>
    /// Country's flag emoji (Optional).
    /// </summary>
    public System.String? FlagEmoji { get; set; }    
    /// <summary>
    /// Country's flag in svg format (Optional).
    /// </summary>
    public ImageDto? FlagSvg { get; set; }    
    /// <summary>
    /// Country's flag in png format (Optional).
    /// </summary>
    public ImageDto? FlagPng { get; set; }    
    /// <summary>
    /// Country's coat of arms in svg format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsSvg { get; set; }    
    /// <summary>
    /// Country's coat of arms in png format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsPng { get; set; }    
    /// <summary>
    /// Country's map via google maps (Optional).
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }    
    /// <summary>
    /// Country's map via open street maps (Optional).
    /// </summary>
    public System.String? OpenStreetMapsUrl { get; set; }    
    /// <summary>
    /// Country's start of week day (Required).
    /// </summary>
    [Required(ErrorMessage = "StartOfWeek is required")]
    
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country used by ExactlyOne Currencies
    /// </summary>
    [Required(ErrorMessage = "CountryUsedByCurrency is required")]
    public System.String CountryUsedByCurrencyId { get; set; } = default!;

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneCreateDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayCreateDto> Holidays { get; set; } = new();

    public Cryptocash.Domain.Country ToEntity()
    {
        var entity = new Cryptocash.Domain.Country();
        entity.Id = Country.CreateId(Id);
        entity.Name = Cryptocash.Domain.Country.CreateName(Name);
        if (OfficialName is not null)entity.OfficialName = Cryptocash.Domain.Country.CreateOfficialName(OfficialName.NonNullValue<System.String>());
        if (CountryIsoNumeric is not null)entity.CountryIsoNumeric = Cryptocash.Domain.Country.CreateCountryIsoNumeric(CountryIsoNumeric.NonNullValue<System.UInt16>());
        if (CountryIsoAlpha3 is not null)entity.CountryIsoAlpha3 = Cryptocash.Domain.Country.CreateCountryIsoAlpha3(CountryIsoAlpha3.NonNullValue<System.String>());
        if (GeoCoords is not null)entity.GeoCoords = Cryptocash.Domain.Country.CreateGeoCoords(GeoCoords.NonNullValue<LatLongDto>());
        if (FlagEmoji is not null)entity.FlagEmoji = Cryptocash.Domain.Country.CreateFlagEmoji(FlagEmoji.NonNullValue<System.String>());
        if (FlagSvg is not null)entity.FlagSvg = Cryptocash.Domain.Country.CreateFlagSvg(FlagSvg.NonNullValue<ImageDto>());
        if (FlagPng is not null)entity.FlagPng = Cryptocash.Domain.Country.CreateFlagPng(FlagPng.NonNullValue<ImageDto>());
        if (CoatOfArmsSvg is not null)entity.CoatOfArmsSvg = Cryptocash.Domain.Country.CreateCoatOfArmsSvg(CoatOfArmsSvg.NonNullValue<ImageDto>());
        if (CoatOfArmsPng is not null)entity.CoatOfArmsPng = Cryptocash.Domain.Country.CreateCoatOfArmsPng(CoatOfArmsPng.NonNullValue<ImageDto>());
        if (GoogleMapsUrl is not null)entity.GoogleMapsUrl = Cryptocash.Domain.Country.CreateGoogleMapsUrl(GoogleMapsUrl.NonNullValue<System.String>());
        if (OpenStreetMapsUrl is not null)entity.OpenStreetMapsUrl = Cryptocash.Domain.Country.CreateOpenStreetMapsUrl(OpenStreetMapsUrl.NonNullValue<System.String>());
        entity.StartOfWeek = Cryptocash.Domain.Country.CreateStartOfWeek(StartOfWeek);
        //entity.Currency = Currency.ToEntity();
        //entity.Commissions = Commissions.Select(dto => dto.ToEntity()).ToList();
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        //entity.Customers = Customers.Select(dto => dto.ToEntity()).ToList();
        entity.CountryTimeZones = CountryTimeZones.Select(dto => dto.ToEntity()).ToList();
        entity.Holidays = Holidays.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}