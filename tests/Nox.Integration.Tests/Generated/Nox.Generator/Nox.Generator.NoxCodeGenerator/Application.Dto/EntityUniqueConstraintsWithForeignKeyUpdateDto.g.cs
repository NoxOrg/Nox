﻿// Generated

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
public partial class EntityUniqueConstraintsWithForeignKeyUpdateDto : EntityUniqueConstraintsWithForeignKeyUpdateDtoBase
{

}

/// <summary>
/// Patch entity EntityUniqueConstraintsWithForeignKey: Entity created for testing constraints with Foreign Key.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class EntityUniqueConstraintsWithForeignKeyPatchDto: { { className} }
{

}

/// <summary>
/// Entity created for testing constraints with Foreign Key
/// </summary>
public partial class EntityUniqueConstraintsWithForeignKeyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.EntityUniqueConstraintsWithForeignKey>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? TextField { get; set; }
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "SomeUniqueId is required")]
    
    public virtual System.Int32 SomeUniqueId { get; set; } = default!;
}