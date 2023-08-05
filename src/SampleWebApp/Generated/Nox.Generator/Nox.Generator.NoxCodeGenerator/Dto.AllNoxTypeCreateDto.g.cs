// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxTypeCreateDto
{
    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public System.String TextField { get; set; } = default!;
    /// <summary>
    /// VatNumber Nox Type (Required).
    /// </summary>
    public VatNumberDto VatNumberField { get; set; } = default!;
    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public System.String CountryCode2Field { get; set; } = default!;
    /// <summary>
    /// CountryCode3 Nox Type (Required).
    /// </summary>
    public System.String CountryCode3Field { get; set; } = default!;
    /// <summary>
    /// Formula Nox Type (Optional).
    /// </summary>
    public System.String? FormulaField { get; set; } 
}