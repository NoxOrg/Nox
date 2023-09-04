// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

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
    /// Currency's major name (Required).
    /// </summary>
    public System.String MajorName { get; set; } = default!;

    /// <summary>
    /// Currency's major display symbol (Required).
    /// </summary>
    public System.String MajorSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's minor name (Required).
    /// </summary>
    public System.String MinorName { get; set; } = default!;

    /// <summary>
    /// Currency's minor display symbol (Required).
    /// </summary>
    public System.String MinorSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's minor value when converted to major (Required).
    /// </summary>
    public MoneyDto MinorToMajorValue { get; set; } = default!;

    /// <summary>
    /// Currency Currency's bank notes OneOrMany BankNotes
    /// </summary>
    public virtual List<BankNotesDto> BankNotes { get; set; } = new();

    /// <summary>
    /// Currency Country's currency OneOrMany Countries
    /// </summary>
    public virtual List<CountryDto> Country { get; set; } = new();

    /// <summary>
    /// Currency Cash stock currency ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> MinimumCashStock { get; set; } = new();

    /// <summary>
    /// Currency Exchanged from currency OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateDto> ExchangeRateFrom { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }    
}