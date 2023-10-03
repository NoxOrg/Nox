// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class CurrencyExtensions
{
    public static CurrencyDto ToDto(this Currency entity)
    {
        var dto = new CurrencyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.Name, () => dto.Name = entity!.Name!.Value);
        SetIfNotNull(entity?.CurrencyIsoNumeric, () => dto.CurrencyIsoNumeric = entity!.CurrencyIsoNumeric!.Value);
        SetIfNotNull(entity?.Symbol, () => dto.Symbol = entity!.Symbol!.Value);
        SetIfNotNull(entity?.ThousandsSeparator, () => dto.ThousandsSeparator = entity!.ThousandsSeparator!.Value);
        SetIfNotNull(entity?.DecimalSeparator, () => dto.DecimalSeparator = entity!.DecimalSeparator!.Value);
        SetIfNotNull(entity?.SpaceBetweenAmountAndSymbol, () => dto.SpaceBetweenAmountAndSymbol = entity!.SpaceBetweenAmountAndSymbol!.Value);
        SetIfNotNull(entity?.DecimalDigits, () => dto.DecimalDigits = entity!.DecimalDigits!.Value);
        SetIfNotNull(entity?.MajorName, () => dto.MajorName = entity!.MajorName!.Value);
        SetIfNotNull(entity?.MajorSymbol, () => dto.MajorSymbol = entity!.MajorSymbol!.Value);
        SetIfNotNull(entity?.MinorName, () => dto.MinorName = entity!.MinorName!.Value);
        SetIfNotNull(entity?.MinorSymbol, () => dto.MinorSymbol = entity!.MinorSymbol!.Value);
        SetIfNotNull(entity?.MinorToMajorValue, () => dto.MinorToMajorValue = entity!.MinorToMajorValue!.ToDto());
        SetIfNotNull(entity?.CurrencyUsedByCountry, () => dto.CurrencyUsedByCountry = entity!.CurrencyUsedByCountry.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CurrencyUsedByMinimumCashStocks, () => dto.CurrencyUsedByMinimumCashStocks = entity!.CurrencyUsedByMinimumCashStocks.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CurrencyCommonBankNotes, () => dto.CurrencyCommonBankNotes = entity!.CurrencyCommonBankNotes.Select(e => e.ToDto()).ToList());
        SetIfNotNull(entity?.CurrencyExchangedFromRates, () => dto.CurrencyExchangedFromRates = entity!.CurrencyExchangedFromRates.Select(e => e.ToDto()).ToList());

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}