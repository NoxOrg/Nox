// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// The list of countries.
/// </summary>
public partial class CountryDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("Name", () => SampleWebApp.Domain.Country.CreateName(this.Name), result);
        ValidateField("FormalName", () => SampleWebApp.Domain.Country.CreateFormalName(this.FormalName), result);
        ValidateField("AlphaCode3", () => SampleWebApp.Domain.Country.CreateAlphaCode3(this.AlphaCode3), result);
        ValidateField("AlphaCode2", () => SampleWebApp.Domain.Country.CreateAlphaCode2(this.AlphaCode2), result);
        ValidateField("NumericCode", () => SampleWebApp.Domain.Country.CreateNumericCode(this.NumericCode), result);
        if (this.DialingCodes is not null)
            ValidateField("DialingCodes", () => SampleWebApp.Domain.Country.CreateDialingCodes(this.DialingCodes.NonNullValue<System.String>()), result);
        if (this.Capital is not null)
            ValidateField("Capital", () => SampleWebApp.Domain.Country.CreateCapital(this.Capital.NonNullValue<System.String>()), result);
        if (this.Demonym is not null)
            ValidateField("Demonym", () => SampleWebApp.Domain.Country.CreateDemonym(this.Demonym.NonNullValue<System.String>()), result);
        ValidateField("AreaInSquareKilometres", () => SampleWebApp.Domain.Country.CreateAreaInSquareKilometres(this.AreaInSquareKilometres), result);
        if (this.GeoCoord is not null)
            ValidateField("GeoCoord", () => SampleWebApp.Domain.Country.CreateGeoCoord(this.GeoCoord.NonNullValue<LatLongDto>()), result);
        ValidateField("GeoRegion", () => SampleWebApp.Domain.Country.CreateGeoRegion(this.GeoRegion), result);
        ValidateField("GeoSubRegion", () => SampleWebApp.Domain.Country.CreateGeoSubRegion(this.GeoSubRegion), result);
        ValidateField("GeoWorldRegion", () => SampleWebApp.Domain.Country.CreateGeoWorldRegion(this.GeoWorldRegion), result);
        if (this.Population is not null)
            ValidateField("Population", () => SampleWebApp.Domain.Country.CreatePopulation(this.Population.NonNullValue<System.Int32>()), result);
        if (this.TopLevelDomains is not null)
            ValidateField("TopLevelDomains", () => SampleWebApp.Domain.Country.CreateTopLevelDomains(this.TopLevelDomains.NonNullValue<System.String>()), result);   

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