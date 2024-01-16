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
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? TextField { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "SomeUniqueId is required")]
    
    public virtual System.Int32? SomeUniqueId { get; set; }

    /// <summary>
    /// EntityUniqueConstraintsWithForeignKey for ExactlyOne EntityUniqueConstraintsRelatedForeignKeys
    /// </summary>
    public System.Int32? EntityUniqueConstraintsRelatedForeignKeyId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual EntityUniqueConstraintsRelatedForeignKeyCreateDto? EntityUniqueConstraintsRelatedForeignKey { get; set; } = default!;
}