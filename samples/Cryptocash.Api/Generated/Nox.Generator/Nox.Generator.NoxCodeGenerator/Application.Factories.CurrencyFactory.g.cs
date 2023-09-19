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

    public void UpdateEntity(Currency entity, CurrencyUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
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

    private void MapEntity(Currency entity, CurrencyUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.Name = Cryptocash.Domain.Currency.CreateName(updateDto.Name);
        entity.CurrencyIsoNumeric = Cryptocash.Domain.Currency.CreateCurrencyIsoNumeric(updateDto.CurrencyIsoNumeric);
        entity.Symbol = Cryptocash.Domain.Currency.CreateSymbol(updateDto.Symbol);
        if (updateDto.ThousandsSeparator is not null)entity.ThousandsSeparator = Cryptocash.Domain.Currency.CreateThousandsSeparator(updateDto.ThousandsSeparator.NonNullValue<System.String>());
        if (updateDto.DecimalSeparator is not null)entity.DecimalSeparator = Cryptocash.Domain.Currency.CreateDecimalSeparator(updateDto.DecimalSeparator.NonNullValue<System.String>());
        entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.Currency.CreateSpaceBetweenAmountAndSymbol(updateDto.SpaceBetweenAmountAndSymbol);
        entity.DecimalDigits = Cryptocash.Domain.Currency.CreateDecimalDigits(updateDto.DecimalDigits);
        entity.MajorName = Cryptocash.Domain.Currency.CreateMajorName(updateDto.MajorName);
        entity.MajorSymbol = Cryptocash.Domain.Currency.CreateMajorSymbol(updateDto.MajorSymbol);
        entity.MinorName = Cryptocash.Domain.Currency.CreateMinorName(updateDto.MinorName);
        entity.MinorSymbol = Cryptocash.Domain.Currency.CreateMinorSymbol(updateDto.MinorSymbol);
        entity.MinorToMajorValue = Cryptocash.Domain.Currency.CreateMinorToMajorValue(updateDto.MinorToMajorValue);

        // TODO: discuss about keys
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