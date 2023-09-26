// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryKeyDto(System.Int64 keyId);

/// <summary>
/// Country Entity.
/// </summary>
public partial class CountryDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("Name", () => ClientApi.Domain.Country.CreateName(this.Name), result);
        if (this.Population is not null)
            ValidateField("Population", () => ClientApi.Domain.Country.CreatePopulation(this.Population.NonNullValue<System.Int32>()), result);
        if (this.CountryDebt is not null)
            ValidateField("CountryDebt", () => ClientApi.Domain.Country.CreateCountryDebt(this.CountryDebt.NonNullValue<MoneyDto>()), result);
        if (this.FirstLanguageCode is not null)
            ValidateField("FirstLanguageCode", () => ClientApi.Domain.Country.CreateFirstLanguageCode(this.FirstLanguageCode.NonNullValue<System.String>()), result); 
        if (this.CountryIsoNumeric is not null)
            ValidateField("CountryIsoNumeric", () => ClientApi.Domain.Country.CreateCountryIsoNumeric(this.CountryIsoNumeric.NonNullValue<System.UInt16>()), result);
        if (this.CountryIsoAlpha3 is not null)
            ValidateField("CountryIsoAlpha3", () => ClientApi.Domain.Country.CreateCountryIsoAlpha3(this.CountryIsoAlpha3.NonNullValue<System.String>()), result);
        if (this.GoogleMapsUrl is not null)
            ValidateField("GoogleMapsUrl", () => ClientApi.Domain.Country.CreateGoogleMapsUrl(this.GoogleMapsUrl.NonNullValue<System.String>()), result);
        if (this.StartOfWeek is not null)
            ValidateField("StartOfWeek", () => ClientApi.Domain.Country.CreateStartOfWeek(this.StartOfWeek.NonNullValue<System.UInt16>()), result);

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
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Population (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }

    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public MoneyDto? CountryDebt { get; set; }

    /// <summary>
    /// First Official Language (Optional).
    /// </summary>
    public System.String? FirstLanguageCode { get; set; }

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? ShortDescription { get; set; }

    /// <summary>
    /// Country's iso number id (Optional).
    /// </summary>
    public System.UInt16? CountryIsoNumeric { get; set; }

    /// <summary>
    /// Country's iso alpha3 id (Optional).
    /// </summary>
    public System.String? CountryIsoAlpha3 { get; set; }

    /// <summary>
    /// Country's map via google maps (Optional).
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// Country's start of week day (Optional).
    /// </summary>
    public System.UInt16? StartOfWeek { get; set; }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<WorkplaceDto> PhysicalWorkplaces { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameDto> CountryShortNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCodeDto? CountryBarCode { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}