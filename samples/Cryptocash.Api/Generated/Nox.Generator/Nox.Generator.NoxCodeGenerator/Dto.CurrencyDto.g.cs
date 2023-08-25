// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record CurrencyKeyDto(System.String keyId);

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyDto
{

    /// <summary>
    /// The currency unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The currency's iso number id (Required).
    /// </summary>
    public System.Int16 CurrencyIsoNumeric { get; set; } = default!;

    /// <summary>
    /// The currency's symbol (Required).
    /// </summary>
    public System.String Symbol { get; set; } = default!;

    /// <summary>
    /// The currency's numeric thousands notation separator (Required).
    /// </summary>
    public System.String ThousandsSeperator { get; set; } = default!;

    /// <summary>
    /// The currency's numeric decimal notation separator (Required).
    /// </summary>
    public System.String DecimalSeparator { get; set; } = default!;

    /// <summary>
    /// The currency's numeric space between amount and symbol (Required).
    /// </summary>
    public System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;

    /// <summary>
    /// The currency's numeric decimal digits (Required).
    /// </summary>
    public System.Int32 DecimalDigits { get; set; } = default!;

    /// <summary>
    /// Currency The currency's related units major and minor ExactlyOne CurrencyUnits
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CurrencyUnitsId { get; set; } = null!;
    public virtual CurrencyUnitsDto CurrencyUnits { get; set; } = null!;

    /// <summary>
    /// Currency The currency's related bank notes OneOrMany CurrencyBankNotes
    /// </summary>
    public virtual List<CurrencyBankNotesDto> CurrencyBankNotes { get; set; } = new();

    /// <summary>
    /// Currency The country's related currencies ZeroOrMany Countries
    /// </summary>
    public virtual List<CountryDto> Countries { get; set; } = new();

    /// <summary>
    /// Currency The currency of the cash stock ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> MinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Currency The currency exchanged from ZeroOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateDto> ExchangeRates { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}