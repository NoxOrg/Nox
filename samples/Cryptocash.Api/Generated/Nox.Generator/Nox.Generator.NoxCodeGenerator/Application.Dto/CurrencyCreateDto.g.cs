// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyCreateDto : CurrencyCreateDtoBase
{

}

/// <summary>
/// Currency and related data.
/// </summary>
public abstract class CurrencyCreateDtoBase : IEntityDto<DomainNamespace.Currency>
{
    /// <summary>
    /// Currency unique identifier
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    /// Currency's name 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Currency's iso number id 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "CurrencyIsoNumeric is required")]
    
    public virtual System.Int16 CurrencyIsoNumeric { get; set; } = default!;
    /// <summary>
    /// Currency's symbol 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Symbol is required")]
    
    public virtual System.String Symbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric thousands notation separator 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? ThousandsSeparator { get; set; }
    /// <summary>
    /// Currency's numeric decimal notation separator 
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? DecimalSeparator { get; set; }
    /// <summary>
    /// Currency's numeric space between amount and symbol 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "SpaceBetweenAmountAndSymbol is required")]
    
    public virtual System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric decimal digits 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "DecimalDigits is required")]
    
    public virtual System.Int32 DecimalDigits { get; set; } = default!;
    /// <summary>
    /// Currency's major name 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MajorName is required")]
    
    public virtual System.String MajorName { get; set; } = default!;
    /// <summary>
    /// Currency's major display symbol 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MajorSymbol is required")]
    
    public virtual System.String MajorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor name 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MinorName is required")]
    
    public virtual System.String MinorName { get; set; } = default!;
    /// <summary>
    /// Currency's minor display symbol 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MinorSymbol is required")]
    
    public virtual System.String MinorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor value when converted to major 
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MinorToMajorValue is required")]
    
    public virtual MoneyDto MinorToMajorValue { get; set; } = default!;

    /// <summary>
    /// Currency used by OneOrMany Countries
    /// </summary>
    public virtual List<System.String> CountriesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<CountryCreateDto> Countries { get; set; } = new();

    /// <summary>
    /// Currency used by ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<System.Int64> MinimumCashStocksId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<MinimumCashStockCreateDto> MinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Currency commonly used ZeroOrMany BankNotes
    /// </summary>
    public virtual List<BankNoteCreateDto> CurrencyCommonBankNotes { get; set; } = new();

    /// <summary>
    /// Currency exchanged from OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateCreateDto> CurrencyExchangedFromRates { get; set; } = new();
}