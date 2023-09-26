// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("Name", () => Cryptocash.Domain.Country.CreateName(this.Name), result);
        if (this.OfficialName is not null)
            ValidateField("OfficialName", () => Cryptocash.Domain.Country.CreateOfficialName(this.OfficialName.NonNullValue<System.String>()), result);
        if (this.CountryIsoNumeric is not null)
            ValidateField("CountryIsoNumeric", () => Cryptocash.Domain.Country.CreateCountryIsoNumeric(this.CountryIsoNumeric.NonNullValue<System.UInt16>()), result);
        if (this.CountryIsoAlpha3 is not null)
            ValidateField("CountryIsoAlpha3", () => Cryptocash.Domain.Country.CreateCountryIsoAlpha3(this.CountryIsoAlpha3.NonNullValue<System.String>()), result);
        if (this.GeoCoords is not null)
            ValidateField("GeoCoords", () => Cryptocash.Domain.Country.CreateGeoCoords(this.GeoCoords.NonNullValue<LatLongDto>()), result);
        if (this.FlagEmoji is not null)
            ValidateField("FlagEmoji", () => Cryptocash.Domain.Country.CreateFlagEmoji(this.FlagEmoji.NonNullValue<System.String>()), result);
        if (this.FlagSvg is not null)
            ValidateField("FlagSvg", () => Cryptocash.Domain.Country.CreateFlagSvg(this.FlagSvg.NonNullValue<ImageDto>()), result);
        if (this.FlagPng is not null)
            ValidateField("FlagPng", () => Cryptocash.Domain.Country.CreateFlagPng(this.FlagPng.NonNullValue<ImageDto>()), result);
        if (this.CoatOfArmsSvg is not null)
            ValidateField("CoatOfArmsSvg", () => Cryptocash.Domain.Country.CreateCoatOfArmsSvg(this.CoatOfArmsSvg.NonNullValue<ImageDto>()), result);
        if (this.CoatOfArmsPng is not null)
            ValidateField("CoatOfArmsPng", () => Cryptocash.Domain.Country.CreateCoatOfArmsPng(this.CoatOfArmsPng.NonNullValue<ImageDto>()), result);
        if (this.GoogleMapsUrl is not null)
            ValidateField("GoogleMapsUrl", () => Cryptocash.Domain.Country.CreateGoogleMapsUrl(this.GoogleMapsUrl.NonNullValue<System.String>()), result);
        if (this.OpenStreetMapsUrl is not null)
            ValidateField("OpenStreetMapsUrl", () => Cryptocash.Domain.Country.CreateOpenStreetMapsUrl(this.OpenStreetMapsUrl.NonNullValue<System.String>()), result);
        ValidateField("StartOfWeek", () => Cryptocash.Domain.Country.CreateStartOfWeek(this.StartOfWeek), result);

        return result;
    }

    private void ValidateField<T>(string fieldName, Func<T> action, Dictionary<string, IEnumerable<string>> result)
    {
        try
        {
            action();
        }
        catch (TypeValidationException ex)
        {
            result.Add(fieldName, ex.Errors.Select(x => x.ErrorMessage));
        }
        catch (NullReferenceException)
        {
            result.Add(fieldName, new List<string> { $"{fieldName} is Required." });
        }
    }
    #endregion

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
    /// Country used by ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? CountryUsedByCurrencyId { get; set; } = default!;
    public virtual CurrencyDto? CountryUsedByCurrency { get; set; } = null!;

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<CommissionDto> CountryUsedByCommissions { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> CountryUsedByVendingMachines { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<CustomerDto> CountryUsedByCustomers { get; set; } = new();

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneDto> CountryOwnedTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayDto> CountryOwnedHolidays { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}