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


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryKeyDto(System.Int64 keyId);

public partial class CountryDto : CountryDtoBase
{

}

/// <summary>
/// Country Entity Country representation for the Client API tests.
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
    
        if (this.Population is not null)
            ExecuteActionAndCollectValidationExceptions("Population", () => DomainNamespace.CountryMetadata.CreatePopulation(this.Population.NonNullValue<System.Int32>()), result);
        if (this.CountryDebt is not null)
            ExecuteActionAndCollectValidationExceptions("CountryDebt", () => DomainNamespace.CountryMetadata.CreateCountryDebt(this.CountryDebt.NonNullValue<MoneyDto>()), result);
        if (this.FirstLanguageCode is not null)
            ExecuteActionAndCollectValidationExceptions("FirstLanguageCode", () => DomainNamespace.CountryMetadata.CreateFirstLanguageCode(this.FirstLanguageCode.NonNullValue<System.String>()), result); 
        if (this.CountryIsoNumeric is not null)
            ExecuteActionAndCollectValidationExceptions("CountryIsoNumeric", () => DomainNamespace.CountryMetadata.CreateCountryIsoNumeric(this.CountryIsoNumeric.NonNullValue<System.UInt16>()), result);
        if (this.CountryIsoAlpha3 is not null)
            ExecuteActionAndCollectValidationExceptions("CountryIsoAlpha3", () => DomainNamespace.CountryMetadata.CreateCountryIsoAlpha3(this.CountryIsoAlpha3.NonNullValue<System.String>()), result);
        if (this.GoogleMapsUrl is not null)
            ExecuteActionAndCollectValidationExceptions("GoogleMapsUrl", () => DomainNamespace.CountryMetadata.CreateGoogleMapsUrl(this.GoogleMapsUrl.NonNullValue<System.String>()), result);
        if (this.StartOfWeek is not null)
            ExecuteActionAndCollectValidationExceptions("StartOfWeek", () => DomainNamespace.CountryMetadata.CreateStartOfWeek(this.StartOfWeek.NonNullValue<System.UInt16>()), result);
        if (this.Continent is not null)
            ExecuteActionAndCollectValidationExceptions("Continent", () => DomainNamespace.CountryMetadata.CreateContinent(this.Continent.NonNullValue<System.Int32>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// The unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Country Name     Set a unique name for the country Do not use abbreviations 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Population Number of People living in the country 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Int32? Population { get; set; }

    /// <summary>
    /// The Money 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public MoneyDto? CountryDebt { get; set; }

    /// <summary>
    /// First Official Language 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? FirstLanguageCode { get; set; }

    /// <summary>
    /// The Formula 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? ShortDescription { get; set; }

    /// <summary>
    /// Country's iso number id 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.UInt16? CountryIsoNumeric { get; set; }

    /// <summary>
    /// Country's iso alpha3 id 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? CountryIsoAlpha3 { get; set; }

    /// <summary>
    /// Country's map via google maps 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? GoogleMapsUrl { get; set; }

    /// <summary>
    /// Country's start of week day 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.UInt16? StartOfWeek { get; set; }

    /// <summary>
    /// Country Continent 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Int32? Continent { get; set; }
    [NotMapped]
    public string? ContinentName { get; set; } = default!;

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<WorkplaceDto> Workplaces { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameDto> CountryShortNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCodeDto? CountryBarCode { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}