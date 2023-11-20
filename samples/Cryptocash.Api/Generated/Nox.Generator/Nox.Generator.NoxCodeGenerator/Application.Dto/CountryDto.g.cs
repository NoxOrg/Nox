// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// Update Country
/// Country and related data.
/// </summary>
public partial class CountryDto : CountryDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Country>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.CountryMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.OfficialName is not null)
            ExecuteActionAndCollectValidationExceptions("OfficialName", () => DomainNamespace.CountryMetadata.CreateOfficialName(this.OfficialName.NonNullValue<System.String>()), result);
        if (this.CountryIsoNumeric is not null)
            ExecuteActionAndCollectValidationExceptions("CountryIsoNumeric", () => DomainNamespace.CountryMetadata.CreateCountryIsoNumeric(this.CountryIsoNumeric.NonNullValue<System.UInt16>()), result);
        if (this.CountryIsoAlpha3 is not null)
            ExecuteActionAndCollectValidationExceptions("CountryIsoAlpha3", () => DomainNamespace.CountryMetadata.CreateCountryIsoAlpha3(this.CountryIsoAlpha3.NonNullValue<System.String>()), result);
        if (this.GeoCoords is not null)
            ExecuteActionAndCollectValidationExceptions("GeoCoords", () => DomainNamespace.CountryMetadata.CreateGeoCoords(this.GeoCoords.NonNullValue<LatLongDto>()), result);
        if (this.FlagEmoji is not null)
            ExecuteActionAndCollectValidationExceptions("FlagEmoji", () => DomainNamespace.CountryMetadata.CreateFlagEmoji(this.FlagEmoji.NonNullValue<System.String>()), result);
        if (this.FlagSvg is not null)
            ExecuteActionAndCollectValidationExceptions("FlagSvg", () => DomainNamespace.CountryMetadata.CreateFlagSvg(this.FlagSvg.NonNullValue<ImageDto>()), result);
        if (this.FlagPng is not null)
            ExecuteActionAndCollectValidationExceptions("FlagPng", () => DomainNamespace.CountryMetadata.CreateFlagPng(this.FlagPng.NonNullValue<ImageDto>()), result);
        if (this.CoatOfArmsSvg is not null)
            ExecuteActionAndCollectValidationExceptions("CoatOfArmsSvg", () => DomainNamespace.CountryMetadata.CreateCoatOfArmsSvg(this.CoatOfArmsSvg.NonNullValue<ImageDto>()), result);
        if (this.CoatOfArmsPng is not null)
            ExecuteActionAndCollectValidationExceptions("CoatOfArmsPng", () => DomainNamespace.CountryMetadata.CreateCoatOfArmsPng(this.CoatOfArmsPng.NonNullValue<ImageDto>()), result);
        if (this.GoogleMapsUrl is not null)
            ExecuteActionAndCollectValidationExceptions("GoogleMapsUrl", () => DomainNamespace.CountryMetadata.CreateGoogleMapsUrl(this.GoogleMapsUrl.NonNullValue<System.String>()), result);
        if (this.OpenStreetMapsUrl is not null)
            ExecuteActionAndCollectValidationExceptions("OpenStreetMapsUrl", () => DomainNamespace.CountryMetadata.CreateOpenStreetMapsUrl(this.OpenStreetMapsUrl.NonNullValue<System.String>()), result);
        ExecuteActionAndCollectValidationExceptions("StartOfWeek", () => DomainNamespace.CountryMetadata.CreateStartOfWeek(this.StartOfWeek), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country unique identifier
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country's official name     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? OfficialName { get; set; }

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
    /// Country's geo coordinates     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public LatLongDto? GeoCoords { get; set; }

    /// <summary>
    /// Country's flag emoji     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? FlagEmoji { get; set; }

    /// <summary>
    /// Country's flag in svg format     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public ImageDto? FlagSvg { get; set; }

    /// <summary>
    /// Country's flag in png format     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public ImageDto? FlagPng { get; set; }

    /// <summary>
    /// Country's coat of arms in svg format     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public ImageDto? CoatOfArmsSvg { get; set; }

    /// <summary>
    /// Country's coat of arms in png format     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public ImageDto? CoatOfArmsPng { get; set; }

    /// <summary>
    /// Country's map via google maps     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// Country's map via open street maps     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? OpenStreetMapsUrl { get; set; }

    /// <summary>
    /// Country's start of week day     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.UInt16 StartOfWeek { get; set; } = default!;

    /// <summary>
    /// Country used by ExactlyOne Currencies
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? CurrencyId { get; set; } = default!;
    public virtual CurrencyDto? Currency { get; set; } = null!;

    /// <summary>
    /// Country used by OneOrMany Commissions
    /// </summary>
    public virtual List<CommissionDto> Commissions { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachineDto> VendingMachines { get; set; } = new();

    /// <summary>
    /// Country used by ZeroOrMany Customers
    /// </summary>
    public virtual List<CustomerDto> Customers { get; set; } = new();

    /// <summary>
    /// Country owned OneOrMany CountryTimeZones
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