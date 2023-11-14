// Generated

#nullable enable

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Country Localized Upsert DTO.
/// </summary>
public partial class CountryLocalizedUpsertDto
{
    /// <summary>
    /// The country's official name
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String FormalName { get; set; } = default!;
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String AlphaCode3 { get; set; } = default!;
    /// <summary>
    /// The capital city of the country
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? Capital { get; set; }
}