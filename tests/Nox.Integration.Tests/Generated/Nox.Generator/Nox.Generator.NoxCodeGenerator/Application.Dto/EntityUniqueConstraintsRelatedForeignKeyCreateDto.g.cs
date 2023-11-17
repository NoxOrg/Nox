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
/// Entity created for testing constraints.
/// </summary>
public partial class EntityUniqueConstraintsRelatedForeignKeyCreateDto : EntityUniqueConstraintsRelatedForeignKeyCreateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public abstract class EntityUniqueConstraintsRelatedForeignKeyCreateDtoBase : IEntityDto<DomainNamespace.EntityUniqueConstraintsRelatedForeignKey>
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.Int32 Id { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? TextField { get; set; }

    /// <summary>
    /// EntityUniqueConstraintsRelatedForeignKey for ZeroOrMany EntityUniqueConstraintsWithForeignKeys
    /// </summary>
    public virtual List<System.Guid> EntityUniqueConstraintsWithForeignKeysId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<EntityUniqueConstraintsWithForeignKeyCreateDto> EntityUniqueConstraintsWithForeignKeys { get; set; } = new();
}