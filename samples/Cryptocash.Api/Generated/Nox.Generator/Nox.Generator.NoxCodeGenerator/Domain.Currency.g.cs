// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class Currency : AuditableEntityBase
{
    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    public CurrencyCode3 Id { get; set; } = null!;

    /// <summary>
    /// Currency's name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Currency's iso number id (Required).
    /// </summary>
    public Nox.Types.CurrencyNumber CurrencyIsoNumeric { get; set; } = null!;

    /// <summary>
    /// Currency's symbol (Required).
    /// </summary>
    public Nox.Types.Text Symbol { get; set; } = null!;

    /// <summary>
    /// Currency's numeric thousands notation separator (Optional).
    /// </summary>
    public Nox.Types.Text? ThousandsSeparator { get; set; } = null!;

    /// <summary>
    /// Currency's numeric decimal notation separator (Optional).
    /// </summary>
    public Nox.Types.Text? DecimalSeparator { get; set; } = null!;

    /// <summary>
    /// Currency's numeric space between amount and symbol (Required).
    /// </summary>
    public Nox.Types.Boolean SpaceBetweenAmountAndSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's numeric decimal digits (Required).
    /// </summary>
    public Nox.Types.Number DecimalDigits { get; set; } = null!;

    /// <summary>
    /// Currency's major name (Required).
    /// </summary>
    public Nox.Types.Text MajorName { get; set; } = null!;

    /// <summary>
    /// Currency's major display symbol (Required).
    /// </summary>
    public Nox.Types.Text MajorSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's minor name (Required).
    /// </summary>
    public Nox.Types.Text MinorName { get; set; } = null!;

    /// <summary>
    /// Currency's minor display symbol (Required).
    /// </summary>
    public Nox.Types.Text MinorSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's minor value when converted to major (Required).
    /// </summary>
    public Nox.Types.Money MinorToMajorValue { get; set; } = null!;

    /// <summary>
    /// Currency Currency's bank notes OneOrMany CurrencyBankNotes
    /// </summary>
    public virtual List<CurrencyBankNotes> CurrencyBankNotes { get; set; } = new();

    public List<CurrencyBankNotes> BankNotes => CurrencyBankNotes;

    /// <summary>
    /// Currency Country's currency ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    /// <summary>
    /// Currency Cash stock currency ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStock> MinimumCashStocks { get; set; } = new();

    public List<MinimumCashStock> MinimumCashStock => MinimumCashStocks;

    /// <summary>
    /// Currency Exchanged from currency OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRate> ExchangeRates { get; set; } = new();

    public List<ExchangeRate> ExchangeRateFrom => ExchangeRates;
}