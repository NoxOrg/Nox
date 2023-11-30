// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;



/// <summary>
/// Entity created for testing constraints with Foreign Key.
/// </summary>
public partial class EntityUniqueConstraintsWithForeignKeyPartialUpdateDto : EntityUniqueConstraintsWithForeignKeyPartialUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints with Foreign Key
/// </summary>
public partial class EntityUniqueConstraintsWithForeignKeyPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.EntityUniqueConstraintsWithForeignKey>
{
    /// <summary>
    /// 
    /// </summary>
    public virtual System.String? TextField { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public virtual System.Int32 SomeUniqueId { get; set; } = default!;
}