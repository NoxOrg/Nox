// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Presentation.Api.OData;

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxTypeDto
{
    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public String TextField { get; set; } = default!;
    /// <summary>
    /// VatNumber Nox Type (Required).
    /// </summary>
    public String VatNumberField { get; set; } = default!;
    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public String CountryCode2Field { get; set; } = default!;
    /// <summary>
    /// CountryCode3 Nox Type (Required).
    /// </summary>
    public String CountryCode3Field { get; set; } = default!;
    /// <summary>
    /// Formula Nox Type (Optional).
    /// </summary>
    public String? FormulaField { get; set; } 
}