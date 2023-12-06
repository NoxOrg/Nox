// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record LanguageKeyDto(System.String keyId);

/// <summary>
/// Update Language
/// Language.
/// </summary>
public partial class LanguageDto : LanguageDtoBase
{

}

/// <summary>
/// Language.
/// </summary>
public abstract class LanguageDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Language>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.LanguageMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.CountryIsoNumeric is not null)
            ExecuteActionAndCollectValidationExceptions("CountryIsoNumeric", () => DomainNamespace.LanguageMetadata.CreateCountryIsoNumeric(this.CountryIsoNumeric.NonNullValue<System.UInt16>()), result);
        if (this.CountryIsoAlpha3 is not null)
            ExecuteActionAndCollectValidationExceptions("CountryIsoAlpha3", () => DomainNamespace.LanguageMetadata.CreateCountryIsoAlpha3(this.CountryIsoAlpha3.NonNullValue<System.String>()), result);
        if (this.Region is not null)
            ExecuteActionAndCollectValidationExceptions("Region", () => DomainNamespace.LanguageMetadata.CreateRegion(this.Region.NonNullValue<System.String>()), result);
        else
            result.Add("Region", new [] { "Region is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Language unique identifier
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String Name { get; set; } = default!;

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
    /// Region of country     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String Region { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}