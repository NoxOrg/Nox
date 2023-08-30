﻿// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using Cryptocash.Application.DataTransferObjects;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CurrencyKeyDto(System.String keyId);

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyDto
{

    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Currency's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Currency's iso number id (Required).
    /// </summary>
    public System.Int16 CurrencyIsoNumeric { get; set; } = default!;

    /// <summary>
    /// Currency's symbol (Required).
    /// </summary>
    public System.String Symbol { get; set; } = default!;

    /// <summary>
    /// Currency's numeric thousands notation separator (Optional).
    /// </summary>
    public System.String? ThousandsSeparator { get; set; }

    /// <summary>
    /// Currency's numeric decimal notation separator (Optional).
    /// </summary>
    public System.String? DecimalSeparator { get; set; }

    /// <summary>
    /// Currency's numeric space between amount and symbol (Required).
    /// </summary>
    public System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's numeric decimal digits (Required).
    /// </summary>
    public System.Int32 DecimalDigits { get; set; } = default!;

    /// <summary>
    /// Currency Currency's related units ExactlyOne CurrencyUnits
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CurrencyUnitsId { get; set; } = null!;
    public virtual CurrencyUnitsDto CurrencyUnits { get; set; } = null!;

    /// <summary>
    /// Currency Currency's bank notes OneOrMany CurrencyBankNotes
    /// </summary>
    public virtual List<CurrencyBankNotesDto> CurrencyBankNotes { get; set; } = new();

    /// <summary>
    /// Currency Country's related currencies ZeroOrMany Countries
    /// </summary>
    public virtual List<CountryDto> Countries { get; set; } = new();

    /// <summary>
    /// Currency Cash stock currency ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> MinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Currency Exchanged from currency ZeroOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateDto> ExchangeRates { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}