// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Workplace Localized Upsert DTO.
/// </summary>
public partial class WorkplaceLocalizedUpsertDto
{
    /// <summary>
    /// Workplace Description
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Description { get; set; }
}