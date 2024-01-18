// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing constraints.
/// </summary>
public partial class EntityUniqueConstraintsRelatedForeignKeyUpdateDto : EntityUniqueConstraintsRelatedForeignKeyUpdateDtoBase
{

}

/// <summary>
/// Entity created for testing constraints
/// </summary>
public partial class EntityUniqueConstraintsRelatedForeignKeyUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? TextField { get; set; }
}