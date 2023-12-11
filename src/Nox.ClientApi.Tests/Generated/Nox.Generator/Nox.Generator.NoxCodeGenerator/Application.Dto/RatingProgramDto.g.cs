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

public record RatingProgramKeyDto(System.Guid keyStoreId, System.Int64 keyId);

/// <summary>
/// Update RatingProgram
/// Rating program for store.
/// </summary>
public partial class RatingProgramDto : RatingProgramDtoBase
{

}

/// <summary>
/// Rating program for store.
/// </summary>
public abstract class RatingProgramDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.RatingProgram>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if(this.StoreId != default(System.Guid))
            ExecuteActionAndCollectValidationExceptions("StoreId", () => DomainNamespace.RatingProgramMetadata.CreateStoreId(this.StoreId), result);
        else
            result.Add("StoreId", new [] { "StoreId is Required." });
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.RatingProgramMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Guid StoreId { get; set; } = default!;

    /// <summary>
    /// The unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Rating Program Name     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Name { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}