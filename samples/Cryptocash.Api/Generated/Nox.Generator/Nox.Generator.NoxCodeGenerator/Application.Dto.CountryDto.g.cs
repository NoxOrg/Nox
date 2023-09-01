// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryDto
{

    /// <summary>
    /// Country unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Country's name (Required).
    /// </summary>
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
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country Country's currency ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String CurrencyId { get; set; } = default!;
    public virtual CurrencyDto Currency { get; set; } = null!;

    /// <summary>
    /// Country Country's time zones OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZonesDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country Commission's country OneOrMany Commissions
    /// </summary>
    public virtual List<CommissionDto> Commissions { get; set; } = new();

    /// <summary>
    /// Country Vending machine's country ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachines { get; set; } = new();

    /// <summary>
    /// Country Country's holidays ZeroOrMany CountryHolidays
    /// </summary>
    public virtual List<CountryHolidayDto> CountryHolidays { get; set; } = new();

    /// <summary>
    /// Country Customer's country ZeroOrMany Customers
    /// </summary>
    public virtual List<CustomerDto> Customers { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

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
        entity.Currency = Currency.ToEntity();
        entity.CountryTimeZones = CountryTimeZones.Select(dto => dto.ToEntity()).ToList();
        entity.Commissions = Commissions.Select(dto => dto.ToEntity()).ToList();
        entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        entity.CountryHolidays = CountryHolidays.Select(dto => dto.ToEntity()).ToList();
        entity.Customers = Customers.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}