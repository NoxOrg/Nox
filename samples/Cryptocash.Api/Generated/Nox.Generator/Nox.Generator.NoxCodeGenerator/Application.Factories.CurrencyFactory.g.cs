// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using Currency = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Factories;

public abstract class CurrencyFactoryBase : IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto>
{
    protected IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto> BankNoteFactory {get;}
    protected IEntityFactory<ExchangeRate, ExchangeRateCreateDto, ExchangeRateUpdateDto> ExchangeRateFactory {get;}

    public CurrencyFactoryBase
    (
        IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto> banknotefactory,
        IEntityFactory<ExchangeRate, ExchangeRateCreateDto, ExchangeRateUpdateDto> exchangeratefactory
        )
    {
        BankNoteFactory = banknotefactory;
        ExchangeRateFactory = exchangeratefactory;
    }

    public virtual Currency CreateEntity(CurrencyCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(Currency entity, CurrencyUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private Cryptocash.Domain.Currency ToEntity(CurrencyCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Currency();
        entity.Id = Currency.CreateId(createDto.Id);
        entity.Name = Cryptocash.Domain.Currency.CreateName(createDto.Name);
        entity.CurrencyIsoNumeric = Cryptocash.Domain.Currency.CreateCurrencyIsoNumeric(createDto.CurrencyIsoNumeric);
        entity.Symbol = Cryptocash.Domain.Currency.CreateSymbol(createDto.Symbol);
        if (createDto.ThousandsSeparator is not null)entity.ThousandsSeparator = Cryptocash.Domain.Currency.CreateThousandsSeparator(createDto.ThousandsSeparator.NonNullValue<System.String>());
        if (createDto.DecimalSeparator is not null)entity.DecimalSeparator = Cryptocash.Domain.Currency.CreateDecimalSeparator(createDto.DecimalSeparator.NonNullValue<System.String>());
        entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.Currency.CreateSpaceBetweenAmountAndSymbol(createDto.SpaceBetweenAmountAndSymbol);
        entity.DecimalDigits = Cryptocash.Domain.Currency.CreateDecimalDigits(createDto.DecimalDigits);
        entity.MajorName = Cryptocash.Domain.Currency.CreateMajorName(createDto.MajorName);
        entity.MajorSymbol = Cryptocash.Domain.Currency.CreateMajorSymbol(createDto.MajorSymbol);
        entity.MinorName = Cryptocash.Domain.Currency.CreateMinorName(createDto.MinorName);
        entity.MinorSymbol = Cryptocash.Domain.Currency.CreateMinorSymbol(createDto.MinorSymbol);
        entity.MinorToMajorValue = Cryptocash.Domain.Currency.CreateMinorToMajorValue(createDto.MinorToMajorValue);
        //entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
        entity.CurrencyCommonBankNotes = createDto.CurrencyCommonBankNotes.Select(dto => BankNoteFactory.CreateEntity(dto)).ToList();
        entity.CurrencyExchangedFromRates = createDto.CurrencyExchangedFromRates.Select(dto => ExchangeRateFactory.CreateEntity(dto)).ToList();
        return entity;
    }

    private void UpdateEntityInternal(Currency entity, CurrencyUpdateDto updateDto)
    {
        entity.Name = Cryptocash.Domain.Currency.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.CurrencyIsoNumeric = Cryptocash.Domain.Currency.CreateCurrencyIsoNumeric(updateDto.CurrencyIsoNumeric.NonNullValue<System.Int16>());
        entity.Symbol = Cryptocash.Domain.Currency.CreateSymbol(updateDto.Symbol.NonNullValue<System.String>());
        if (updateDto.ThousandsSeparator == null) { entity.ThousandsSeparator = null; } else {
            entity.ThousandsSeparator = Cryptocash.Domain.Currency.CreateThousandsSeparator(updateDto.ThousandsSeparator.ToValueFromNonNull<System.String>());
        }
        if (updateDto.DecimalSeparator == null) { entity.DecimalSeparator = null; } else {
            entity.DecimalSeparator = Cryptocash.Domain.Currency.CreateDecimalSeparator(updateDto.DecimalSeparator.ToValueFromNonNull<System.String>());
        }
        entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.Currency.CreateSpaceBetweenAmountAndSymbol(updateDto.SpaceBetweenAmountAndSymbol.NonNullValue<System.Boolean>());
        entity.DecimalDigits = Cryptocash.Domain.Currency.CreateDecimalDigits(updateDto.DecimalDigits.NonNullValue<System.Int32>());
        entity.MajorName = Cryptocash.Domain.Currency.CreateMajorName(updateDto.MajorName.NonNullValue<System.String>());
        entity.MajorSymbol = Cryptocash.Domain.Currency.CreateMajorSymbol(updateDto.MajorSymbol.NonNullValue<System.String>());
        entity.MinorName = Cryptocash.Domain.Currency.CreateMinorName(updateDto.MinorName.NonNullValue<System.String>());
        entity.MinorSymbol = Cryptocash.Domain.Currency.CreateMinorSymbol(updateDto.MinorSymbol.NonNullValue<System.String>());
        entity.MinorToMajorValue = Cryptocash.Domain.Currency.CreateMinorToMajorValue(updateDto.MinorToMajorValue.NonNullValue<MoneyDto>());
        //entity.Countries = Countries.Select(dto => dto.ToEntity()).ToList();
        //entity.MinimumCashStocks = MinimumCashStocks.Select(dto => dto.ToEntity()).ToList();
    }
}

public partial class CurrencyFactory : CurrencyFactoryBase
{
    public CurrencyFactory
    (
        IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto> banknotefactory,
        IEntityFactory<ExchangeRate, ExchangeRateCreateDto, ExchangeRateUpdateDto> exchangeratefactory
    ): base(banknotefactory,exchangeratefactory)
    {}
}