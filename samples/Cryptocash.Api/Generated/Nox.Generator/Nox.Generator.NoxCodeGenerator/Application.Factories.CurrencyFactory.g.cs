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

public abstract class CurrencyFactoryBase: IEntityFactory<CurrencyCreateDto,Currency>
{
    protected IEntityFactory<BankNoteCreateDto,BankNote> BankNoteFactory {get;}
    protected IEntityFactory<ExchangeRateCreateDto,ExchangeRate> ExchangeRateFactory {get;}

    public CurrencyFactoryBase
    (
        IEntityFactory<BankNoteCreateDto,BankNote> banknotefactory,
        IEntityFactory<ExchangeRateCreateDto,ExchangeRate> exchangeratefactory
        )
    {        
        BankNoteFactory = banknotefactory;        
        ExchangeRateFactory = exchangeratefactory;
    }

    public virtual Currency CreateEntity(CurrencyCreateDto createDto)
    {
        return ToEntity(createDto);
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
        entity.BankNotes = createDto.BankNotes.Select(dto => BankNoteFactory.CreateEntity(dto)).ToList();
        entity.ExchangeRates = createDto.ExchangeRates.Select(dto => ExchangeRateFactory.CreateEntity(dto)).ToList();
        return entity;
    }
}

public partial class CurrencyFactory : CurrencyFactoryBase
{
    public CurrencyFactory
    (
        IEntityFactory<BankNoteCreateDto,BankNote> banknotefactory,
        IEntityFactory<ExchangeRateCreateDto,ExchangeRate> exchangeratefactory
    ): base(banknotefactory,exchangeratefactory)                      
    {}
}