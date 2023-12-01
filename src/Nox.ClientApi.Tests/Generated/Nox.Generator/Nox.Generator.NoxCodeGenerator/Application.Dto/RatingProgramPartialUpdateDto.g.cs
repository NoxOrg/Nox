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
public partial class RatingProgramPartialUpdateDto : RatingProgramPartialUpdateDtoBase
{

}

/// <summary>
/// Rating program for store
/// </summary>
public partial class RatingProgramPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.RatingProgram>
{
    /// <summary>
    /// Rating Program Name
    /// </summary>
    public virtual System.String? Name { get; set; }
}