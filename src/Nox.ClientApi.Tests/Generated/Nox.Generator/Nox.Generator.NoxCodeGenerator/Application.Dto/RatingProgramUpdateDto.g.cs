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
/// Rating program for store
/// </summary>
public partial class RatingProgramUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.RatingProgram>
{
    /// <summary>
    /// Rating Program Name 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.String? Name { get; set; }
}