// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Exchange rate and related data.
/// </summary>
public partial class ExchangeRate : AuditableEntityBase
{
    /// <summary>
    /// Exchange rate unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.Number EffectiveRate { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.DateTime EffectiveAt { get; set; } = null!;

    /// <summary>
    /// ExchangeRate Exchange rate relative to CHF (Swiss Franc) ExactlyOne Currencies
    /// </summary>
    public virtual Currency Currency { get; set; } = null!;

    public Currency CurrencyFrom => Currency;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CurrencyId { get; set; } = null!;
}