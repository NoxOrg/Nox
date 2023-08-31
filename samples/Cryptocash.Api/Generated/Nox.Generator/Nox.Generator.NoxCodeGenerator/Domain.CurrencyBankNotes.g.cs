// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class CurrencyBankNotes : AuditableEntityBase
{
    /// <summary>
    /// Currency bank note unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Currency's bank note identifier (Required).
    /// </summary>
    public Nox.Types.Text BankNote { get; set; } = null!;

    /// <summary>
    /// Is bank note rare or frequent (Required).
    /// </summary>
    public Nox.Types.Boolean IsRare { get; set; } = null!;

    /// <summary>
    /// CurrencyBankNotes Currency's bank notes ExactlyOne Currencies
    /// </summary>
    public virtual Currency Currency { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CurrencyId { get; set; } = null!;
}