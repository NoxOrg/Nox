﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace TestWebApp.Application.Dto;

public record EntityUniqueConstraintsRelatedForeignKeyKeyDto(System.Int32 keyId);

/// <summary>
/// Update EntityUniqueConstraintsRelatedForeignKey
/// Entity created for testing constraints.
/// </summary>
public partial class EntityUniqueConstraintsRelatedForeignKeyDto : EntityUniqueConstraintsRelatedForeignKeyDtoBase
{

}

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract class EntityUniqueConstraintsRelatedForeignKeyDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextField is not null)
            CollectValidationExceptions("TextField", () => EntityUniqueConstraintsRelatedForeignKeyMetadata.CreateTextField(this.TextField.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.Int32 Id { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? TextField { get; set; }

    /// <summary>
    /// EntityUniqueConstraintsRelatedForeignKey for ZeroOrMany EntityUniqueConstraintsWithForeignKeys
    /// </summary>
    public virtual List<EntityUniqueConstraintsWithForeignKeyDto> EntityUniqueConstraintsWithForeignKeys { get; set; } = new();

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}