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

public record CountryQualityOfLifeIndexKeyDto(System.Int64 keyCountryId, System.Int64 keyId);

/// <summary>
/// Update CountryQualityOfLifeIndex
/// Country Quality Of Life Index.
/// </summary>
public partial class CountryQualityOfLifeIndexDto : CountryQualityOfLifeIndexDtoBase
{

}

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
public abstract class CountryQualityOfLifeIndexDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.CountryQualityOfLifeIndex>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if(this.CountryId != default(System.Int64))
            ExecuteActionAndCollectValidationExceptions("CountryId", () => DomainNamespace.CountryQualityOfLifeIndexMetadata.CreateCountryId(this.CountryId), result);
        else
            result.Add("CountryId", new [] { "CountryId is Required." });
        ExecuteActionAndCollectValidationExceptions("IndexRating", () => DomainNamespace.CountryQualityOfLifeIndexMetadata.CreateIndexRating(this.IndexRating), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Int64 CountryId { get; set; } = default!;

    /// <summary>
    /// The unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Rating Index     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 IndexRating { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}