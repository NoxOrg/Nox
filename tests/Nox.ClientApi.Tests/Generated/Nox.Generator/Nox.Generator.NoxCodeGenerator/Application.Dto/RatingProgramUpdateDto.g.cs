// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class RatingProgramUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Rating Program Name     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Name { get; set; }
}