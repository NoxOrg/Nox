// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public record EntityUniqueConstraintsWithForeignKeyKeyDto(System.Guid keyId);

/// <summary>
/// Update EntityUniqueConstraintsWithForeignKey
/// Entity created for testing constraints with Foreign Key.
/// </summary>
public partial class EntityUniqueConstraintsWithForeignKeyDto : EntityUniqueConstraintsWithForeignKeyDtoBase
{

}

/// <summary>
/// Entity created for testing constraints with Foreign Key.
/// </summary>
public abstract class EntityUniqueConstraintsWithForeignKeyDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.EntityUniqueConstraintsWithForeignKey>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextField is not null)
            ExecuteActionAndCollectValidationExceptions("TextField", () => DomainNamespace.EntityUniqueConstraintsWithForeignKeyMetadata.CreateTextField(this.TextField.NonNullValue<System.String>()), result);
        ExecuteActionAndCollectValidationExceptions("SomeUniqueId", () => DomainNamespace.EntityUniqueConstraintsWithForeignKeyMetadata.CreateSomeUniqueId(this.SomeUniqueId), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? TextField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 SomeUniqueId { get; set; } = default!;

    /// <summary>
    /// EntityUniqueConstraintsWithForeignKey for ExactlyOne EntityUniqueConstraintsRelatedForeignKeys
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int32? EntityUniqueConstraintsRelatedForeignKeyId { get; set; } = default!;
    public virtual EntityUniqueConstraintsRelatedForeignKeyDto? EntityUniqueConstraintsRelatedForeignKey { get; set; } = null!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}