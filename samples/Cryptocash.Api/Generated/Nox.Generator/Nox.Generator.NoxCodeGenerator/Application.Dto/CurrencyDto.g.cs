// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CurrencyKeyDto(System.String keyId);

/// <summary>
/// Update Currency
/// Currency and related data.
/// </summary>
public partial class CurrencyDto : CurrencyDtoBase
{

}

/// <summary>
/// Currency and related data.
/// </summary>
public abstract class CurrencyDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Currency>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.CurrencyMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        ExecuteActionAndCollectValidationExceptions("CurrencyIsoNumeric", () => DomainNamespace.CurrencyMetadata.CreateCurrencyIsoNumeric(this.CurrencyIsoNumeric), result);
    
        if (this.Symbol is not null)
            ExecuteActionAndCollectValidationExceptions("Symbol", () => DomainNamespace.CurrencyMetadata.CreateSymbol(this.Symbol.NonNullValue<System.String>()), result);
        else
            result.Add("Symbol", new [] { "Symbol is Required." });
    
        if (this.ThousandsSeparator is not null)
            ExecuteActionAndCollectValidationExceptions("ThousandsSeparator", () => DomainNamespace.CurrencyMetadata.CreateThousandsSeparator(this.ThousandsSeparator.NonNullValue<System.String>()), result);
        if (this.DecimalSeparator is not null)
            ExecuteActionAndCollectValidationExceptions("DecimalSeparator", () => DomainNamespace.CurrencyMetadata.CreateDecimalSeparator(this.DecimalSeparator.NonNullValue<System.String>()), result);
        ExecuteActionAndCollectValidationExceptions("SpaceBetweenAmountAndSymbol", () => DomainNamespace.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(this.SpaceBetweenAmountAndSymbol), result);
    
        ExecuteActionAndCollectValidationExceptions("DecimalDigits", () => DomainNamespace.CurrencyMetadata.CreateDecimalDigits(this.DecimalDigits), result);
    
        if (this.MajorName is not null)
            ExecuteActionAndCollectValidationExceptions("MajorName", () => DomainNamespace.CurrencyMetadata.CreateMajorName(this.MajorName.NonNullValue<System.String>()), result);
        else
            result.Add("MajorName", new [] { "MajorName is Required." });
    
        if (this.MajorSymbol is not null)
            ExecuteActionAndCollectValidationExceptions("MajorSymbol", () => DomainNamespace.CurrencyMetadata.CreateMajorSymbol(this.MajorSymbol.NonNullValue<System.String>()), result);
        else
            result.Add("MajorSymbol", new [] { "MajorSymbol is Required." });
    
        if (this.MinorName is not null)
            ExecuteActionAndCollectValidationExceptions("MinorName", () => DomainNamespace.CurrencyMetadata.CreateMinorName(this.MinorName.NonNullValue<System.String>()), result);
        else
            result.Add("MinorName", new [] { "MinorName is Required." });
    
        if (this.MinorSymbol is not null)
            ExecuteActionAndCollectValidationExceptions("MinorSymbol", () => DomainNamespace.CurrencyMetadata.CreateMinorSymbol(this.MinorSymbol.NonNullValue<System.String>()), result);
        else
            result.Add("MinorSymbol", new [] { "MinorSymbol is Required." });
    
        if (this.MinorToMajorValue is not null)
            ExecuteActionAndCollectValidationExceptions("MinorToMajorValue", () => DomainNamespace.CurrencyMetadata.CreateMinorToMajorValue(this.MinorToMajorValue.NonNullValue<MoneyDto>()), result);
        else
            result.Add("MinorToMajorValue", new [] { "MinorToMajorValue is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Currency unique identifier
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Currency's name     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Currency's iso number id     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.Int16 CurrencyIsoNumeric { get; set; } = default!;

    /// <summary>
    /// Currency's symbol     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String Symbol { get; set; } = default!;

    /// <summary>
    /// Currency's numeric thousands notation separator     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? ThousandsSeparator { get; set; }

    /// <summary>
    /// Currency's numeric decimal notation separator     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? DecimalSeparator { get; set; }

    /// <summary>
    /// Currency's numeric space between amount and symbol     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's numeric decimal digits     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.Int32 DecimalDigits { get; set; } = default!;

    /// <summary>
    /// Currency's major name     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String MajorName { get; set; } = default!;

    /// <summary>
    /// Currency's major display symbol     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String MajorSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's minor name     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String MinorName { get; set; } = default!;

    /// <summary>
    /// Currency's minor display symbol     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.String MinorSymbol { get; set; } = default!;

    /// <summary>
    /// Currency's minor value when converted to major     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public MoneyDto MinorToMajorValue { get; set; } = default!;

    /// <summary>
    /// Currency used by OneOrMany Countries
    /// </summary>
    public virtual List<CountryDto> Countries { get; set; } = new();

    /// <summary>
    /// Currency used by ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> MinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Currency commonly used ZeroOrMany BankNotes
    /// </summary>
    public virtual List<BankNoteDto> BankNotes { get; set; } = new();

    /// <summary>
    /// Currency exchanged from OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateDto> ExchangeRates { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}