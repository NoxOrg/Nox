// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
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
    public virtual List<CountryDto> Countries { get; set; } = new();

    /// <summary>
    /// Currency Cash stock currency ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> MinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Currency Exchanged from currency OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateDto> ExchangeRates { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public Currency ToEntity()
    {
        var entity = new Currency();
        entity.Id = Currency.CreateId(Id);
        entity.Name = Currency.CreateName(Name);
        entity.CurrencyIsoNumeric = Currency.CreateCurrencyIsoNumeric(CurrencyIsoNumeric);
        entity.Symbol = Currency.CreateSymbol(Symbol);
        if (ThousandsSeparator is not null)entity.ThousandsSeparator = Currency.CreateThousandsSeparator(ThousandsSeparator.NonNullValue<System.String>());
        if (DecimalSeparator is not null)entity.DecimalSeparator = Currency.CreateDecimalSeparator(DecimalSeparator.NonNullValue<System.String>());
        entity.SpaceBetweenAmountAndSymbol = Currency.CreateSpaceBetweenAmountAndSymbol(SpaceBetweenAmountAndSymbol);
        entity.DecimalDigits = Currency.CreateDecimalDigits(DecimalDigits);
        entity.MajorName = Currency.CreateMajorName(MajorName);
        entity.MajorSymbol = Currency.CreateMajorSymbol(MajorSymbol);
        entity.MinorName = Currency.CreateMinorName(MinorName);
        entity.MinorSymbol = Currency.CreateMinorSymbol(MinorSymbol);
        entity.MinorToMajorValue = Currency.CreateMinorToMajorValue(MinorToMajorValue);
        entity.BankNotes = BankNotes.Select(dto => dto.ToEntity()).ToList();
        entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        entity.ExchangeRates = ExchangeRates.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}