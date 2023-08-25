// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class Currency : AuditableEntityBase
{
    /// <summary>
    /// The currency unique identifier (Required).
    /// </summary>
    public CurrencyCode3 Id { get; set; } = null!;

    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The currency's iso number id (Required).
    /// </summary>
    public Nox.Types.CurrencyNumber CurrencyIsoNumeric { get; set; } = null!;

    /// <summary>
    /// The currency's symbol (Required).
    /// </summary>
    public Nox.Types.Text Symbol { get; set; } = null!;

    /// <summary>
    /// The currency's numeric thousands notation separator (Required).
    /// </summary>
    public Nox.Types.Text ThousandsSeperator { get; set; } = null!;

    /// <summary>
    /// The currency's numeric decimal notation separator (Required).
    /// </summary>
    public Nox.Types.Text DecimalSeparator { get; set; } = null!;

    /// <summary>
    /// The currency's numeric space between amount and symbol (Required).
    /// </summary>
    public Nox.Types.Boolean SpaceBetweenAmountAndSymbol { get; set; } = null!;

    /// <summary>
    /// The currency's numeric decimal digits (Required).
    /// </summary>
    public Nox.Types.Number DecimalDigits { get; set; } = null!;

    /// <summary>
    /// Currency The currency's related units major and minor ExactlyOne CurrencyUnits
    /// </summary>
    public virtual CurrencyUnits CurrencyUnits { get; set; } = null!;

    public CurrencyUnits Unit => CurrencyUnits;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity CurrencyUnits
    /// </summary>
    public Nox.Types.DatabaseNumber CurrencyUnitsId { get; set; } = null!;

    /// <summary>
    /// Currency The currency's related bank notes OneOrMany CurrencyBankNotes
    /// </summary>
    public virtual List<CurrencyBankNotes> CurrencyBankNotes { get; set; } = new();

    public List<CurrencyBankNotes> BankNotes => CurrencyBankNotes;

    /// <summary>
    /// Currency The country's related currencies ZeroOrMany Countries
    /// </summary>
    public virtual List<Country> Countries { get; set; } = new();

    public List<Country> Country => Countries;

    /// <summary>
    /// Currency The currency of the cash stock ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> MinimumCashStocks { get; set; } = new();

    public List<MinimumCashStock> MinimumCashStock => MinimumCashStocks;

    /// <summary>
    /// Currency The currency exchanged from ZeroOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRate> ExchangeRates { get; set; } = new();

    public List<ExchangeRate> ExchangeRateFrom => ExchangeRates;
}