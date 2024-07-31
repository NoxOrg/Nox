// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class EntityUniqueConstraintsWithForeignKeyUpdateDtoBase: EntityDtoBase
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
    
    public virtual System.Int32? SomeUniqueId { get; set; }
}