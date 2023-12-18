// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record AProductKeyDto(System.Int64 keyId);

/// <summary>
/// Update AProduct
/// ReferenceNumberEntity.
/// </summary>
public partial class AProductDto : AProductDtoBase
{

}

/// <summary>
/// ReferenceNumberEntity.
/// </summary>
public abstract class AProductDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.AProduct>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        ExecuteActionAndCollectValidationExceptions("MyGuid", () => DomainNamespace.AProductMetadata.CreateMyGuid(this.MyGuid), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// ReferenceNumber     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Guid MyGuid { get; set; } = default!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}