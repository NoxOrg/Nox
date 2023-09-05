// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyCreateDto : CurrencyUpdateDto
{
    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

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
        //entity.BankNotes = BankNotes.Select(dto => dto.ToEntity()).ToList();
        //entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        //entity.ExchangeRates = ExchangeRates.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}