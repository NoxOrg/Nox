// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing constraints with Foreign Key.
/// </summary>
public partial class EntityUniqueConstraintsWithForeignKeyCreateDto : EntityUniqueConstraintsWithForeignKeyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints with Foreign Key.
/// </summary>
public abstract class EntityUniqueConstraintsWithForeignKeyCreateDtoBase : IEntityDto<DomainNamespace.EntityUniqueConstraintsWithForeignKey>
{/// <summary>
    ///  
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.Guid Id { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? TextField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "SomeUniqueId is required")]
    
    public virtual System.Int32 SomeUniqueId { get; set; } = default!;

    /// <summary>
    /// EntityUniqueConstraintsWithForeignKey for ExactlyOne EntityUniqueConstraintsRelatedForeignKeys
    /// </summary>
    public System.Int32? EntityUniqueConstraintsRelatedForeignKeyId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual EntityUniqueConstraintsRelatedForeignKeyCreateDto? EntityUniqueConstraintsRelatedForeignKey { get; set; } = default!;
}