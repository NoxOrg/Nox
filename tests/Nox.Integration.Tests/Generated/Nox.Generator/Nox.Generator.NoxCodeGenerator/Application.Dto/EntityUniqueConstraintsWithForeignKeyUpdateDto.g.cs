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
/// Entity created for testing constraints with Foreign Key
/// </summary>
public partial class EntityUniqueConstraintsWithForeignKeyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.EntityUniqueConstraintsWithForeignKey>
{
    /// <summary>
    ///  
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.String? TextField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "SomeUniqueId is required")]
    
    public virtual System.Int32 SomeUniqueId { get; set; } = default!;
}