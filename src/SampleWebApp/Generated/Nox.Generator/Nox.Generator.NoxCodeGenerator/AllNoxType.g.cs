// Generated

#nullable enable

using Nox.Types;
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
}