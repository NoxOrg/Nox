
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

public record CountryQualityOfLifeIndexKeyDto(System.Int64 keyCountryId, System.Int64 keyId);

public partial class CountryQualityOfLifeIndexDto : CountryQualityOfLifeIndexDtoBase
{

}

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
public abstract class CountryQualityOfLifeIndexDtoBase : EntityDtoBase, IEntityDto<CountryQualityOfLifeIndex>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if(this.CountryId != default(System.Int64))
            TryGetValidationExceptions("CountryId", () => ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateCountryId(this.CountryId), result);
        else
            result.Add("CountryId", new [] { "CountryId is Required." });
        TryGetValidationExceptions("IndexRating", () => ClientApi.Domain.CountryQualityOfLifeIndexMetadata.CreateIndexRating(this.IndexRating), result);
    

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Int64 CountryId { get; set; } = default!;

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Rating Index (Required).
    /// </summary>
    public System.Int32 IndexRating { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}