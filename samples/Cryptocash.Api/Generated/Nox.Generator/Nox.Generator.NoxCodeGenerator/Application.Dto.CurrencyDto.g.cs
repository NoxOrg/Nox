// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Dto;

public record CurrencyKeyDto(System.String keyId);

public partial class CurrencyDto : CurrencyDtoBase
{

}

/// <summary>
/// Currency and related data.
/// </summary>
public abstract class CurrencyDtoBase : EntityDtoBase, IEntityDto<CurrencyEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => Cryptocash.Domain.CurrencyMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        ExecuteActionAndCollectValidationExceptions("CurrencyIsoNumeric", () => Cryptocash.Domain.CurrencyMetadata.CreateCurrencyIsoNumeric(this.CurrencyIsoNumeric), result);
    
        if (this.Symbol is not null)
            ExecuteActionAndCollectValidationExceptions("Symbol", () => Cryptocash.Domain.CurrencyMetadata.CreateSymbol(this.Symbol.NonNullValue<System.String>()), result);
        else
            result.Add("Symbol", new [] { "Symbol is Required." });
    
        if (this.ThousandsSeparator is not null)
            ExecuteActionAndCollectValidationExceptions("ThousandsSeparator", () => Cryptocash.Domain.CurrencyMetadata.CreateThousandsSeparator(this.ThousandsSeparator.NonNullValue<System.String>()), result);
        if (this.DecimalSeparator is not null)
            ExecuteActionAndCollectValidationExceptions("DecimalSeparator", () => Cryptocash.Domain.CurrencyMetadata.CreateDecimalSeparator(this.DecimalSeparator.NonNullValue<System.String>()), result);
        ExecuteActionAndCollectValidationExceptions("SpaceBetweenAmountAndSymbol", () => Cryptocash.Domain.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(this.SpaceBetweenAmountAndSymbol), result);
    
        ExecuteActionAndCollectValidationExceptions("DecimalDigits", () => Cryptocash.Domain.CurrencyMetadata.CreateDecimalDigits(this.DecimalDigits), result);
    
        if (this.MajorName is not null)
            ExecuteActionAndCollectValidationExceptions("MajorName", () => Cryptocash.Domain.CurrencyMetadata.CreateMajorName(this.MajorName.NonNullValue<System.String>()), result);
        else
            result.Add("MajorName", new [] { "MajorName is Required." });
    
        if (this.MajorSymbol is not null)
            ExecuteActionAndCollectValidationExceptions("MajorSymbol", () => Cryptocash.Domain.CurrencyMetadata.CreateMajorSymbol(this.MajorSymbol.NonNullValue<System.String>()), result);
        else
            result.Add("MajorSymbol", new [] { "MajorSymbol is Required." });
    
        if (this.MinorName is not null)
            ExecuteActionAndCollectValidationExceptions("MinorName", () => Cryptocash.Domain.CurrencyMetadata.CreateMinorName(this.MinorName.NonNullValue<System.String>()), result);
        else
            result.Add("MinorName", new [] { "MinorName is Required." });
    
        if (this.MinorSymbol is not null)
            ExecuteActionAndCollectValidationExceptions("MinorSymbol", () => Cryptocash.Domain.CurrencyMetadata.CreateMinorSymbol(this.MinorSymbol.NonNullValue<System.String>()), result);
        else
            result.Add("MinorSymbol", new [] { "MinorSymbol is Required." });
    
        if (this.MinorToMajorValue is not null)
            ExecuteActionAndCollectValidationExceptions("MinorToMajorValue", () => Cryptocash.Domain.CurrencyMetadata.CreateMinorToMajorValue(this.MinorToMajorValue.NonNullValue<MoneyDto>()), result);
        else
            result.Add("MinorToMajorValue", new [] { "MinorToMajorValue is Required." });
    

        return result;
    }
    #endregion

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
    /// Currency used by OneOrMany Countries
    /// </summary>
    public virtual List<CountryDto> CurrencyUsedByCountry { get; set; } = new();

    /// <summary>
    /// Currency used by ZeroOrMany MinimumCashStocks
    /// </summary>
    public virtual List<MinimumCashStockDto> CurrencyUsedByMinimumCashStocks { get; set; } = new();

    /// <summary>
    /// Currency commonly used ZeroOrMany BankNotes
    /// </summary>
    public virtual List<BankNoteDto> CurrencyCommonBankNotes { get; set; } = new();

    /// <summary>
    /// Currency exchanged from OneOrMany ExchangeRates
    /// </summary>
    public virtual List<ExchangeRateDto> CurrencyExchangedFromRates { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}