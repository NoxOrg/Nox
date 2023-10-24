// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The list of countries Localized DTO.
/// </summary>
internal partial class CountryLocalizedDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    public System.String CultureCode { get; set; } = default!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public System.String FormalName { get; set; } = default!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public System.String AlphaCode3 { get; set; } = default!;

    /// <summary>
    /// The capital city of the country (Optional).
    /// </summary>
    public System.String? Capital { get; set; }
}