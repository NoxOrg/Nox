// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class CurrencyExtensions
{
    public static CurrencyDto ToDto(this Cryptocash.Domain.Currency entity)
    {
        var dto = new CurrencyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.Name, (dto) => dto.Name =entity!.Name!.Value);
        dto.SetIfNotNull(entity?.CurrencyIsoNumeric, (dto) => dto.CurrencyIsoNumeric =entity!.CurrencyIsoNumeric!.Value);
        dto.SetIfNotNull(entity?.Symbol, (dto) => dto.Symbol =entity!.Symbol!.Value);
        dto.SetIfNotNull(entity?.ThousandsSeparator, (dto) => dto.ThousandsSeparator =entity!.ThousandsSeparator!.Value);
        dto.SetIfNotNull(entity?.DecimalSeparator, (dto) => dto.DecimalSeparator =entity!.DecimalSeparator!.Value);
        dto.SetIfNotNull(entity?.SpaceBetweenAmountAndSymbol, (dto) => dto.SpaceBetweenAmountAndSymbol =entity!.SpaceBetweenAmountAndSymbol!.Value);
        dto.SetIfNotNull(entity?.DecimalDigits, (dto) => dto.DecimalDigits =entity!.DecimalDigits!.Value);
        dto.SetIfNotNull(entity?.MajorName, (dto) => dto.MajorName =entity!.MajorName!.Value);
        dto.SetIfNotNull(entity?.MajorSymbol, (dto) => dto.MajorSymbol =entity!.MajorSymbol!.Value);
        dto.SetIfNotNull(entity?.MinorName, (dto) => dto.MinorName =entity!.MinorName!.Value);
        dto.SetIfNotNull(entity?.MinorSymbol, (dto) => dto.MinorSymbol =entity!.MinorSymbol!.Value);
        dto.SetIfNotNull(entity?.MinorToMajorValue, (dto) => dto.MinorToMajorValue =entity!.MinorToMajorValue!.ToDto());
        dto.SetIfNotNull(entity?.Countries, (dto) => dto.Countries = entity!.Countries.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.MinimumCashStocks, (dto) => dto.MinimumCashStocks = entity!.MinimumCashStocks.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.BankNotes, (dto) => dto.BankNotes = entity!.BankNotes.Select(e => e.ToDto()).ToList());
        dto.SetIfNotNull(entity?.ExchangeRates, (dto) => dto.ExchangeRates = entity!.ExchangeRates.Select(e => e.ToDto()).ToList());

        return dto;
    }
}