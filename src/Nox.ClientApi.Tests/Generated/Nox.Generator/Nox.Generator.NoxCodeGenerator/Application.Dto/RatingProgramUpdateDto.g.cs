// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Rating program for store.
/// </summary>
public partial class RatingProgramUpdateDto : RatingProgramUpdateDtoBase
{

}

/// <summary>
/// Patch entity RatingProgram: Rating program for store.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class RatingProgramPatchDto: { { className} }
{

}

/// <summary>
/// Rating program for store
/// </summary>
public partial class RatingProgramUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.RatingProgram>
{
    /// <summary>
    /// Rating Program Name     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Name { get; set; }
}