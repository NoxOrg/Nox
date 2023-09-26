// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CurrencyKeyDto(System.String keyId);

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("Name", () => Cryptocash.Domain.Currency.CreateName(this.Name), result);
        ValidateField("CurrencyIsoNumeric", () => Cryptocash.Domain.Currency.CreateCurrencyIsoNumeric(this.CurrencyIsoNumeric), result);
        ValidateField("Symbol", () => Cryptocash.Domain.Currency.CreateSymbol(this.Symbol), result);
        if (this.ThousandsSeparator is not null)
            ValidateField("ThousandsSeparator", () => Cryptocash.Domain.Currency.CreateThousandsSeparator(this.ThousandsSeparator.NonNullValue<System.String>()), result);
        if (this.DecimalSeparator is not null)
            ValidateField("DecimalSeparator", () => Cryptocash.Domain.Currency.CreateDecimalSeparator(this.DecimalSeparator.NonNullValue<System.String>()), result);
        ValidateField("SpaceBetweenAmountAndSymbol", () => Cryptocash.Domain.Currency.CreateSpaceBetweenAmountAndSymbol(this.SpaceBetweenAmountAndSymbol), result);
        ValidateField("DecimalDigits", () => Cryptocash.Domain.Currency.CreateDecimalDigits(this.DecimalDigits), result);
        ValidateField("MajorName", () => Cryptocash.Domain.Currency.CreateMajorName(this.MajorName), result);
        ValidateField("MajorSymbol", () => Cryptocash.Domain.Currency.CreateMajorSymbol(this.MajorSymbol), result);
        ValidateField("MinorName", () => Cryptocash.Domain.Currency.CreateMinorName(this.MinorName), result);
        ValidateField("MinorSymbol", () => Cryptocash.Domain.Currency.CreateMinorSymbol(this.MinorSymbol), result);
        ValidateField("MinorToMajorValue", () => Cryptocash.Domain.Currency.CreateMinorToMajorValue(this.MinorToMajorValue), result);

        return result;
    }

    private void ValidateField<T>(string fieldName, Func<T> action, Dictionary<string, IEnumerable<string>> result)
    {
        try
        {
            action();
        }
        catch (TypeValidationException ex)
        {
            result.Add(fieldName, ex.Errors.Select(x => x.ErrorMessage));
        }
        catch (NullReferenceException)
        {
            result.Add(fieldName, new List<string> { $"{fieldName} is Required." });
        }
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
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}