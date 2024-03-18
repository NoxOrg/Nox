// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace ClientApi.Application.Dto;

public record CountryKeyDto(System.Int64 keyId);

/// <summary>
/// Update Country
/// Country Entity Country representation for the Client API tests.
/// </summary>
public partial class CountryDto : CountryDtoBase
{

}

/// <summary>
/// Country Entity Country representation for the Client API tests.
/// </summary>
public abstract class CountryDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => CountryMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Population is not null)
            CollectValidationExceptions("Population", () => CountryMetadata.CreatePopulation(this.Population.NonNullValue<System.Int32>()), result);
        if (this.CountryDebt is not null)
            CollectValidationExceptions("CountryDebt", () => CountryMetadata.CreateCountryDebt(this.CountryDebt.NonNullValue<MoneyDto>()), result); 
        if (this.CapitalCityLocation is not null)
            CollectValidationExceptions("CapitalCityLocation", () => CountryMetadata.CreateCapitalCityLocation(this.CapitalCityLocation.NonNullValue<LatLongDto>()), result);
        if (this.FirstLanguageCode is not null)
            CollectValidationExceptions("FirstLanguageCode", () => CountryMetadata.CreateFirstLanguageCode(this.FirstLanguageCode.NonNullValue<System.String>()), result); 
        if (this.CountryIsoNumeric is not null)
            CollectValidationExceptions("CountryIsoNumeric", () => CountryMetadata.CreateCountryIsoNumeric(this.CountryIsoNumeric.NonNullValue<System.UInt16>()), result);
        if (this.CountryIsoAlpha3 is not null)
            CollectValidationExceptions("CountryIsoAlpha3", () => CountryMetadata.CreateCountryIsoAlpha3(this.CountryIsoAlpha3.NonNullValue<System.String>()), result);
        if (this.GoogleMapsUrl is not null)
            CollectValidationExceptions("GoogleMapsUrl", () => CountryMetadata.CreateGoogleMapsUrl(this.GoogleMapsUrl.NonNullValue<System.String>()), result);
        if (this.StartOfWeek is not null)
            CollectValidationExceptions("StartOfWeek", () => CountryMetadata.CreateStartOfWeek(this.StartOfWeek.NonNullValue<System.UInt16>()), result);
        if (this.TestAttForLocalization is not null)
            CollectValidationExceptions("TestAttForLocalization", () => CountryMetadata.CreateTestAttForLocalization(this.TestAttForLocalization.NonNullValue<System.String>()), result);
        if (this.Continent is not null)
            CollectValidationExceptions("Continent", () => CountryMetadata.CreateContinent(this.Continent.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// The unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Country Name     Set a unique name for the country Do not use abbreviations     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Population Number of People living in the country     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int32? Population { get; set; }

    /// <summary>
    /// The Money     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public MoneyDto? CountryDebt { get; set; }

    /// <summary>
    /// national debt per person     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public double? DebtPerCapita { get; set; }

    /// <summary>
    /// The capital location     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public LatLongDto? CapitalCityLocation { get; set; }

    /// <summary>
    /// First Official Language     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? FirstLanguageCode { get; set; }

    /// <summary>
    /// The Formula     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Country's iso number id     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.UInt16? CountryIsoNumeric { get; set; }

    /// <summary>
    /// Country's iso alpha3 id     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? CountryIsoAlpha3 { get; set; }

    /// <summary>
    /// Country's map via google maps     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// Country's start of week day     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.UInt16? StartOfWeek { get; set; }

    /// <summary>
    /// TestAttForLocalization     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? TestAttForLocalization { get; set; }

    /// <summary>
    /// Country Continent     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int32? Continent { get; set; }
    public string? ContinentName { get; set; } = default!;

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<WorkplaceDto> Workplaces { get; set; } = new();

    /// <summary>
    /// Country Country stores ZeroOrMany Stores
    /// </summary>
    public virtual List<StoreDto> Stores { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameDto> CountryLocalNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCodeDto? CountryBarCode { get; set; } = null!;

    /// <summary>
    /// Country uses OneOrMany CountryTimeZones
    /// </summary>
    public virtual List<CountryTimeZoneDto> CountryTimeZones { get; set; } = new();

    /// <summary>
    /// Country owned ZeroOrMany Holidays
    /// </summary>
    public virtual List<HolidayDto> Holidays { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}