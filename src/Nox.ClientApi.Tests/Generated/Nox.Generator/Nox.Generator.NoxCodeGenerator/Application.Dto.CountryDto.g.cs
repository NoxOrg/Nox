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
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryKeyDto(System.Int64 keyId);

public partial class CountryDto : CountryDtoBase
{

}

/// <summary>
/// Country Entity.
/// </summary>
public abstract class CountryDtoBase : EntityDtoBase, IEntityDto<Country>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            TryGetValidationExceptions("Name", () => ClientApi.Domain.CountryMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Population is not null)
            TryGetValidationExceptions("Population", () => ClientApi.Domain.CountryMetadata.CreatePopulation(this.Population.NonNullValue<System.Int32>()), result);
        if (this.CountryDebt is not null)
            TryGetValidationExceptions("CountryDebt", () => ClientApi.Domain.CountryMetadata.CreateCountryDebt(this.CountryDebt.NonNullValue<MoneyDto>()), result);
        if (this.FirstLanguageCode is not null)
            TryGetValidationExceptions("FirstLanguageCode", () => ClientApi.Domain.CountryMetadata.CreateFirstLanguageCode(this.FirstLanguageCode.NonNullValue<System.String>()), result); 
        if (this.CountryIsoNumeric is not null)
            TryGetValidationExceptions("CountryIsoNumeric", () => ClientApi.Domain.CountryMetadata.CreateCountryIsoNumeric(this.CountryIsoNumeric.NonNullValue<System.UInt16>()), result);
        if (this.CountryIsoAlpha3 is not null)
            TryGetValidationExceptions("CountryIsoAlpha3", () => ClientApi.Domain.CountryMetadata.CreateCountryIsoAlpha3(this.CountryIsoAlpha3.NonNullValue<System.String>()), result);
        if (this.GoogleMapsUrl is not null)
            TryGetValidationExceptions("GoogleMapsUrl", () => ClientApi.Domain.CountryMetadata.CreateGoogleMapsUrl(this.GoogleMapsUrl.NonNullValue<System.String>()), result);
        if (this.StartOfWeek is not null)
            TryGetValidationExceptions("StartOfWeek", () => ClientApi.Domain.CountryMetadata.CreateStartOfWeek(this.StartOfWeek.NonNullValue<System.UInt16>()), result);

        return result;
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