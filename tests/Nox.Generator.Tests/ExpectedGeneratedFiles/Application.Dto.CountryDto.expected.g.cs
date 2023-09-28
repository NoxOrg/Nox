// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record CountryKeyDto(System.String keyId);

public partial class CountryDto : CountryDtoBase
{

}

/// <summary>
/// The list of countries.
/// </summary>
public abstract class CountryDtoBase : EntityDtoBase, IEntityDto<Country>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => SampleWebApp.Domain.CountryMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.FormalName is not null)
            ExecuteActionAndCollectValidationExceptions("FormalName", () => SampleWebApp.Domain.CountryMetadata.CreateFormalName(this.FormalName.NonNullValue<System.String>()), result);
        else
            result.Add("FormalName", new [] { "FormalName is Required." });
    
        if (this.AlphaCode3 is not null)
            ExecuteActionAndCollectValidationExceptions("AlphaCode3", () => SampleWebApp.Domain.CountryMetadata.CreateAlphaCode3(this.AlphaCode3.NonNullValue<System.String>()), result);
        else
            result.Add("AlphaCode3", new [] { "AlphaCode3 is Required." });
    
        if (this.AlphaCode2 is not null)
            ExecuteActionAndCollectValidationExceptions("AlphaCode2", () => SampleWebApp.Domain.CountryMetadata.CreateAlphaCode2(this.AlphaCode2.NonNullValue<System.String>()), result);
        else
            result.Add("AlphaCode2", new [] { "AlphaCode2 is Required." });
    
        ExecuteActionAndCollectValidationExceptions("NumericCode", () => SampleWebApp.Domain.CountryMetadata.CreateNumericCode(this.NumericCode), result);
    
        if (this.DialingCodes is not null)
            ExecuteActionAndCollectValidationExceptions("DialingCodes", () => SampleWebApp.Domain.CountryMetadata.CreateDialingCodes(this.DialingCodes.NonNullValue<System.String>()), result);
        if (this.Capital is not null)
            ExecuteActionAndCollectValidationExceptions("Capital", () => SampleWebApp.Domain.CountryMetadata.CreateCapital(this.Capital.NonNullValue<System.String>()), result);
        if (this.Demonym is not null)
            ExecuteActionAndCollectValidationExceptions("Demonym", () => SampleWebApp.Domain.CountryMetadata.CreateDemonym(this.Demonym.NonNullValue<System.String>()), result);
        ExecuteActionAndCollectValidationExceptions("AreaInSquareKilometres", () => SampleWebApp.Domain.CountryMetadata.CreateAreaInSquareKilometres(this.AreaInSquareKilometres), result);
    
        if (this.GeoCoord is not null)
            ExecuteActionAndCollectValidationExceptions("GeoCoord", () => SampleWebApp.Domain.CountryMetadata.CreateGeoCoord(this.GeoCoord.NonNullValue<LatLongDto>()), result);
        if (this.GeoRegion is not null)
            ExecuteActionAndCollectValidationExceptions("GeoRegion", () => SampleWebApp.Domain.CountryMetadata.CreateGeoRegion(this.GeoRegion.NonNullValue<System.String>()), result);
        else
            result.Add("GeoRegion", new [] { "GeoRegion is Required." });
    
        if (this.GeoSubRegion is not null)
            ExecuteActionAndCollectValidationExceptions("GeoSubRegion", () => SampleWebApp.Domain.CountryMetadata.CreateGeoSubRegion(this.GeoSubRegion.NonNullValue<System.String>()), result);
        else
            result.Add("GeoSubRegion", new [] { "GeoSubRegion is Required." });
    
        if (this.GeoWorldRegion is not null)
            ExecuteActionAndCollectValidationExceptions("GeoWorldRegion", () => SampleWebApp.Domain.CountryMetadata.CreateGeoWorldRegion(this.GeoWorldRegion.NonNullValue<System.String>()), result);
        else
            result.Add("GeoWorldRegion", new [] { "GeoWorldRegion is Required." });
    
        if (this.Population is not null)
            ExecuteActionAndCollectValidationExceptions("Population", () => SampleWebApp.Domain.CountryMetadata.CreatePopulation(this.Population.NonNullValue<System.Int32>()), result);
        if (this.TopLevelDomains is not null)
            ExecuteActionAndCollectValidationExceptions("TopLevelDomains", () => SampleWebApp.Domain.CountryMetadata.CreateTopLevelDomains(this.TopLevelDomains.NonNullValue<System.String>()), result);   

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// The country's common name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public System.String FormalName { get; set; } = default!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public System.String AlphaCode3 { get; set; } = default!;

    /// <summary>
    /// The country's official ISO 4217 alpha-2 code (Required).
    /// </summary>
    public System.String AlphaCode2 { get; set; } = default!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public System.Int16 NumericCode { get; set; } = default!;

    /// <summary>
    /// The country's phone dialing codes (comma-delimited) (Optional).
    /// </summary>
    public System.String? DialingCodes { get; set; }

    /// <summary>
    /// The capital city of the country (Optional).
    /// </summary>
    public System.String? Capital { get; set; }

    /// <summary>
    /// Noun denoting the natives of the country (Optional).
    /// </summary>
    public System.String? Demonym { get; set; }

    /// <summary>
    /// Country area in square kilometers (Required).
    /// </summary>
    public System.Int32 AreaInSquareKilometres { get; set; } = default!;

    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth (Optional).
    /// </summary>
    public LatLongDto? GeoCoord { get; set; }

    /// <summary>
    /// The region the country is in (Required).
    /// </summary>
    public System.String GeoRegion { get; set; } = default!;

    /// <summary>
    /// The sub-region the country is in (Required).
    /// </summary>
    public System.String GeoSubRegion { get; set; } = default!;

    /// <summary>
    /// The world region the country is in (Required).
    /// </summary>
    public System.String GeoWorldRegion { get; set; } = default!;

    /// <summary>
    /// The estimated population of the country (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }

    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited) (Optional).
    /// </summary>
    public System.String? TopLevelDomains { get; set; }
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}