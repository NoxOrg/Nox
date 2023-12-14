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
/// TenantBrand Localized Upsert DTO.
/// </summary>
public partial class TenantBrandLocalizedUpsertDto
{
    /// <summary>
    /// Teanant Brand Description
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Description { get; set; } = default!;
}