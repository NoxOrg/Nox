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
/// Entity created for testing constraints.
/// </summary>
public partial class EntityUniqueConstraintsRelatedForeignKeyUpdateDto : EntityUniqueConstraintsRelatedForeignKeyUpdateDtoBase
{

}

/// <summary>
/// Patch entity EntityUniqueConstraintsRelatedForeignKey: Entity created for testing constraints.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class EntityUniqueConstraintsRelatedForeignKeyPatchDto: { { className} }
{

}

/// <summary>
/// Entity created for testing constraints
/// </summary>
public partial class EntityUniqueConstraintsRelatedForeignKeyUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.EntityUniqueConstraintsRelatedForeignKey>
{
    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? TextField { get; set; }
}