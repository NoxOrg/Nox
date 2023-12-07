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

public record ReferenceNumberEntityKeyDto(System.String keyId);

/// <summary>
/// Update ReferenceNumberEntity
/// ReferenceNumberEntity.
/// </summary>
public partial class ReferenceNumberEntityDto : ReferenceNumberEntityDtoBase
{

}

/// <summary>
/// ReferenceNumberEntity.
/// </summary>
public abstract class ReferenceNumberEntityDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.ReferenceNumberEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.ReferenceNumber is not null)
            ExecuteActionAndCollectValidationExceptions("ReferenceNumber", () => DomainNamespace.ReferenceNumberEntityMetadata.CreateReferenceNumber(this.ReferenceNumber.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// ReferenceNumber     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? ReferenceNumber { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}