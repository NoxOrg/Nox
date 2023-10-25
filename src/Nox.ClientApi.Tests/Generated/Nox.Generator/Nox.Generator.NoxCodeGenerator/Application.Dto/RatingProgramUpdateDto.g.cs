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
public partial class RatingProgramUpdateDto : IEntityDto<DomainNamespace.RatingProgram>
{
    /// <summary>
    /// Rating Program Name (Optional).
    /// </summary>
    public System.String? Name { get; set; }
}