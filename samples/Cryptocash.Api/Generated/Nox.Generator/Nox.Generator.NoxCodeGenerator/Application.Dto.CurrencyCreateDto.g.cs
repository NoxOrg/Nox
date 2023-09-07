// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyCreateDto : IEntityCreateDto <Currency>
{
    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;    
    /// <summary>
    /// Currency's name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;    
    /// <summary>
    /// Currency's iso number id (Required).
    /// </summary>
    [Required(ErrorMessage = "CurrencyIsoNumeric is required")]
    
    public System.Int16 CurrencyIsoNumeric { get; set; } = default!;    
    /// <summary>
    /// Currency's symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "Symbol is required")]
    
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
    [Required(ErrorMessage = "SpaceBetweenAmountAndSymbol is required")]
    
    public System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;    
    /// <summary>
    /// Currency's numeric decimal digits (Required).
    /// </summary>
    [Required(ErrorMessage = "DecimalDigits is required")]
    
    public System.Int32 DecimalDigits { get; set; } = default!;    
    /// <summary>
    /// Currency's major name (Required).
    /// </summary>
    [Required(ErrorMessage = "MajorName is required")]
    
    public System.String MajorName { get; set; } = default!;    
    /// <summary>
    /// Currency's major display symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "MajorSymbol is required")]
    
    public System.String MajorSymbol { get; set; } = default!;    
    /// <summary>
    /// Currency's minor name (Required).
    /// </summary>
    [Required(ErrorMessage = "MinorName is required")]
    
    public System.String MinorName { get; set; } = default!;    
    /// <summary>
    /// Currency's minor display symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "MinorSymbol is required")]
    
    public System.String MinorSymbol { get; set; } = default!;    
    /// <summary>
    /// Currency's minor value when converted to major (Required).
    /// </summary>
    [Required(ErrorMessage = "MinorToMajorValue is required")]
    
    public MoneyDto MinorToMajorValue { get; set; } = default!;

    /// <summary>
    /// Currency commonly used ZeroOrMany BankNotes
    /// </summary>
    public virtual List<BankNoteCreateDto> BankNotes { get; set; } = new();

    /// <summary>
    /// Currency exchanged from OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateCreateDto> ExchangeRates { get; set; } = new();

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
        entity.BankNotes = BankNotes.Select(dto => dto.ToEntity()).ToList();
        entity.ExchangeRates = ExchangeRates.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}