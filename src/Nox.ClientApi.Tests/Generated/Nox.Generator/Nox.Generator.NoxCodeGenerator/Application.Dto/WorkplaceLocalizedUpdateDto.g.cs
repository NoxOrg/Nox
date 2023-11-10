// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Workplace Localized Create DTO.
/// </summary>
public partial class WorkplaceLocalizedUpdateDto
{
    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    internal System.UInt32 Id { get; set; } = default!;
    
    internal System.String CultureCode { get; set; } = default!;
    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public System.String? Description { get; set; }
}