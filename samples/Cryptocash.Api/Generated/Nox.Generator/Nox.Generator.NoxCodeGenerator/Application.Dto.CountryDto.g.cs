// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryDto
{

    /// <summary>
    /// The country unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// The country's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public System.String OfficialName { get; set; } = default!;

    /// <summary>
    /// The country's iso number id (Required).
    /// </summary>
    public System.UInt16 CountryIsoNumeric { get; set; } = default!;

    /// <summary>
    /// The country's iso alpha3 id (Required).
    /// </summary>
    public System.String CountryIsoAlpha3 { get; set; } = default!;

    /// <summary>
    /// The country's geo coordinates (Required).
    /// </summary>
    public LatLongDto GeoCoords { get; set; } = default!;

    /// <summary>
    /// The country's flag emoji (Optional).
    /// </summary>
    public System.String? FlagEmoji { get; set; }

    /// <summary>
    /// The country's flag in svg format (Optional).
    /// </summary>
    public ImageDto? FlagSvg { get; set; }

    /// <summary>
    /// The country's flag in png format (Optional).
    /// </summary>
    public ImageDto? FlagPng { get; set; }

    /// <summary>
    /// The country's coat of arms in svg format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsSvg { get; set; }

    /// <summary>
    /// The country's coat of arms in png format (Optional).
    /// </summary>
    public ImageDto? CoatOfArmsPng { get; set; }

    /// <summary>
    /// The country's map via google maps (Optional).
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// The country's map via open street maps (Optional).
    /// </summary>
    public System.String? OpenStreeMapsUrl { get; set; }

    /// <summary>
    /// The country's map via open street maps (Required).
    /// </summary>
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country The country's related currencies ZeroOrMany Currencies
    /// </summary>
    public virtual List<CurrencyDto> Currencies { get; set; } = new();

    /// <summary>
    /// Country The country's related timezones ZeroOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZonesDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country The commission related country ZeroOrOne Commissions
    /// </summary>
    //EF maps ForeignKey Automatically...
    public virtual string? CommissionId { get; set; } = null!;
    public virtual CommissionDto? Commission { get; set; } = null!;

    /// <summary>
    /// Country The country of the vending machine ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachines { get; set; } = new();

    /// <summary>
    /// Country The related country ZeroOrOne Holidays
    /// </summary>
    public virtual HolidaysDto? Holidays { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public Country ToEntity()
    {
        var entity = new Country();
        entity.Id = Country.CreateId(Id);
        entity.Name = Country.CreateName(Name);
        entity.OfficialName = Country.CreateOfficialName(OfficialName);
        entity.CountryIsoNumeric = Country.CreateCountryIsoNumeric(CountryIsoNumeric);
        entity.CountryIsoAlpha3 = Country.CreateCountryIsoAlpha3(CountryIsoAlpha3);
        entity.GeoCoords = Country.CreateGeoCoords(GeoCoords);
        if (FlagEmoji is not null)entity.FlagEmoji = Country.CreateFlagEmoji(FlagEmoji.NonNullValue<System.String>());
        if (FlagSvg is not null)entity.FlagSvg = Country.CreateFlagSvg(FlagSvg.NonNullValue<ImageDto>());
        if (FlagPng is not null)entity.FlagPng = Country.CreateFlagPng(FlagPng.NonNullValue<ImageDto>());
        if (CoatOfArmsSvg is not null)entity.CoatOfArmsSvg = Country.CreateCoatOfArmsSvg(CoatOfArmsSvg.NonNullValue<ImageDto>());
        if (CoatOfArmsPng is not null)entity.CoatOfArmsPng = Country.CreateCoatOfArmsPng(CoatOfArmsPng.NonNullValue<ImageDto>());
        if (GoogleMapsUrl is not null)entity.GoogleMapsUrl = Country.CreateGoogleMapsUrl(GoogleMapsUrl.NonNullValue<System.String>());
        if (OpenStreeMapsUrl is not null)entity.OpenStreeMapsUrl = Country.CreateOpenStreeMapsUrl(OpenStreeMapsUrl.NonNullValue<System.String>());
        entity.StartOfWeek = Country.CreateStartOfWeek(StartOfWeek);
        entity.Currencies = Currencies.Select(dto => dto.ToEntity()).ToList();
        entity.CountryTimeZones = CountryTimeZones.Select(dto => dto.ToEntity()).ToList();
        entity.Commission = Commission?.ToEntity();
        entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        entity.Holidays = Holidays?.ToEntity();
        return entity;
    }

}