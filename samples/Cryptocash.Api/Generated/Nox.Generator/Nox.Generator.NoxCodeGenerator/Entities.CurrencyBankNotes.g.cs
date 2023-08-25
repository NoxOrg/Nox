// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class CurrencyBankNotes : AuditableEntityBase
{
    /// <summary>
    /// The currency bank note unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The currency's bank note identifier (Required).
    /// </summary>
    public Nox.Types.Text BankNote { get; set; } = null!;

    /// <summary>
    /// Is bank note rare or frequent (Required).
    /// </summary>
    public Nox.Types.Boolean IsRare { get; set; } = null!;

    /// <summary>
    /// CurrencyBankNotes The currency's related bank notes OneOrMany Currencies
    /// </summary>
    public virtual List<Currency> Currencies { get; set; } = new();

    public List<Currency> Currency => Currencies;
}