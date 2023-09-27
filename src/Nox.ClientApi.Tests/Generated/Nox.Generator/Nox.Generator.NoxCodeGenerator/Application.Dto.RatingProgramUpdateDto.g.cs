// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Rating program for store.
/// </summary>
public partial class RatingProgramUpdateDto : IEntityDto<RatingProgram>
{
    /// <summary>
    /// Rating Program Name (Optional).
    /// </summary>
    public System.String? Name { get; set; }
}