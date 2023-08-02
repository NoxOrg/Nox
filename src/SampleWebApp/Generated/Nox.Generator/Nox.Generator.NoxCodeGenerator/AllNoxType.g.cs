// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxType : AuditableEntityBase
{

    /// <summary>
    /// The currency's primary key / identifier (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public Text TextField { get; set; } = null!;

    /// <summary>
    /// VatNumber Nox Type (Required).
    /// </summary>
    public VatNumber VatNumberField { get; set; } = null!;

    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public CountryCode2 CountryCode2Field { get; set; } = null!;

    /// <summary>
    /// CountryCode3 Nox Type (Required).
    /// </summary>
    public CountryCode3 CountryCode3Field { get; set; } = null!;

    /// <summary>
    /// Formula Nox Type (Optional).
    /// </summary>
    public Formula? FormulaField { get; set; } = null!;
}