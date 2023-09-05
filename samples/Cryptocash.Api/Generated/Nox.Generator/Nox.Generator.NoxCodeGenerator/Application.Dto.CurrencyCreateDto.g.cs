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

    public Cryptocash.Domain.Currency ToEntity()
    {
        var entity = new Cryptocash.Domain.Currency();
        entity.Id = Currency.CreateId(Id);
        entity.Name = Cryptocash.Domain.Currency.CreateName(Name);
        entity.CurrencyIsoNumeric = Cryptocash.Domain.Currency.CreateCurrencyIsoNumeric(CurrencyIsoNumeric);
        entity.Symbol = Cryptocash.Domain.Currency.CreateSymbol(Symbol);
        if (ThousandsSeparator is not null)entity.ThousandsSeparator = Cryptocash.Domain.Currency.CreateThousandsSeparator(ThousandsSeparator.NonNullValue<System.String>());
        if (DecimalSeparator is not null)entity.DecimalSeparator = Cryptocash.Domain.Currency.CreateDecimalSeparator(DecimalSeparator.NonNullValue<System.String>());
        entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.Currency.CreateSpaceBetweenAmountAndSymbol(SpaceBetweenAmountAndSymbol);
        entity.DecimalDigits = Cryptocash.Domain.Currency.CreateDecimalDigits(DecimalDigits);
        entity.MajorName = Cryptocash.Domain.Currency.CreateMajorName(MajorName);
        entity.MajorSymbol = Cryptocash.Domain.Currency.CreateMajorSymbol(MajorSymbol);
        entity.MinorName = Cryptocash.Domain.Currency.CreateMinorName(MinorName);
        entity.MinorSymbol = Cryptocash.Domain.Currency.CreateMinorSymbol(MinorSymbol);
        entity.MinorToMajorValue = Cryptocash.Domain.Currency.CreateMinorToMajorValue(MinorToMajorValue);
        //entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        //entity.BankNotes = BankNotes.Select(dto => dto.ToEntity()).ToList();
        //entity.ExchangeRates = ExchangeRates.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}