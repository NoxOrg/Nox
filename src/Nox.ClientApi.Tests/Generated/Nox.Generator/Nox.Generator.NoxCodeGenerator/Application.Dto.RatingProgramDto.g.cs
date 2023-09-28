
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

public record RatingProgramKeyDto(System.Guid keyStoreId, System.Int64 keyId);

public partial class RatingProgramDto : RatingProgramDtoBase
{

}

/// <summary>
/// Rating program for store.
/// </summary>
public abstract class RatingProgramDtoBase : EntityDtoBase, IEntityDto<RatingProgram>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if(this.StoreId != default(System.Guid))
            TryGetValidationExceptions("StoreId", () => ClientApi.Domain.RatingProgramMetadata.CreateStoreId(this.StoreId), result);
        else
            result.Add("StoreId", new [] { "StoreId is Required." });
        if (this.Name is not null)
            TryGetValidationExceptions("Name", () => ClientApi.Domain.RatingProgramMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.Guid StoreId { get; set; } = default!;

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Rating Program Name (Optional).
    /// </summary>
    public System.String? Name { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}