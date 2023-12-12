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
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String? Id { get; set; }
    /// <summary>
    /// Currency's name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Currency's iso number id     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "CurrencyIsoNumeric is required")]
    
    public virtual System.Int16? CurrencyIsoNumeric { get; set; }
    /// <summary>
    /// Currency's symbol     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Symbol is required")]
    
    public virtual System.String? Symbol { get; set; }
    /// <summary>
    /// Currency's numeric thousands notation separator     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? ThousandsSeparator { get; set; }
    /// <summary>
    /// Currency's numeric decimal notation separator     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? DecimalSeparator { get; set; }
    /// <summary>
    /// Currency's numeric space between amount and symbol     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "SpaceBetweenAmountAndSymbol is required")]
    
    public virtual System.Boolean? SpaceBetweenAmountAndSymbol { get; set; }
    /// <summary>
    /// Currency's symbol position     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "SymbolOnLeft is required")]
    
    public virtual System.Boolean? SymbolOnLeft { get; set; }
    /// <summary>
    /// Currency's numeric decimal digits     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "DecimalDigits is required")]
    
    public virtual System.Int32? DecimalDigits { get; set; }
    /// <summary>
    /// Currency's major name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "MajorName is required")]
    
    public virtual System.String? MajorName { get; set; }
    /// <summary>
    /// Currency's major display symbol     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "MajorSymbol is required")]
    
    public virtual System.String? MajorSymbol { get; set; }
    /// <summary>
    /// Currency's minor name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "MinorName is required")]
    
    public virtual System.String? MinorName { get; set; }
    /// <summary>
    /// Currency's minor display symbol     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "MinorSymbol is required")]
    
    public virtual System.String? MinorSymbol { get; set; }
    /// <summary>
    /// Currency's minor value when converted to major     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "MinorToMajorValue is required")]
    
    public virtual MoneyDto? MinorToMajorValue { get; set; }

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
    public virtual List<BankNoteUpsertDto> BankNotes { get; set; } = new();

    /// <summary>
    /// Currency exchanged from OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateUpsertDto> ExchangeRates { get; set; } = new();
}