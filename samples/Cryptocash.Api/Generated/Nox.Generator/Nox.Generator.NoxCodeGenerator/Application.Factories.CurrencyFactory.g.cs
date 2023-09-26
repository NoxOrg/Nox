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

internal abstract class CurrencyFactoryBase : IEntityFactory<Currency, CurrencyCreateDto, CurrencyUpdateDto>
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

    public virtual void PartialUpdateEntity(Currency entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
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
    }

    private void PartialUpdateEntityInternal(Currency entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = Cryptocash.Domain.Currency.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CurrencyIsoNumeric", out var CurrencyIsoNumericUpdateValue))
        {
            if (CurrencyIsoNumericUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'CurrencyIsoNumeric' can't be null");
            }
            {
                entity.CurrencyIsoNumeric = Cryptocash.Domain.Currency.CreateCurrencyIsoNumeric(CurrencyIsoNumericUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Symbol", out var SymbolUpdateValue))
        {
            if (SymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Symbol' can't be null");
            }
            {
                entity.Symbol = Cryptocash.Domain.Currency.CreateSymbol(SymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("ThousandsSeparator", out var ThousandsSeparatorUpdateValue))
        {
            if (ThousandsSeparatorUpdateValue == null) { entity.ThousandsSeparator = null; }
            else
            {
                entity.ThousandsSeparator = Cryptocash.Domain.Currency.CreateThousandsSeparator(ThousandsSeparatorUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DecimalSeparator", out var DecimalSeparatorUpdateValue))
        {
            if (DecimalSeparatorUpdateValue == null) { entity.DecimalSeparator = null; }
            else
            {
                entity.DecimalSeparator = Cryptocash.Domain.Currency.CreateDecimalSeparator(DecimalSeparatorUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("SpaceBetweenAmountAndSymbol", out var SpaceBetweenAmountAndSymbolUpdateValue))
        {
            if (SpaceBetweenAmountAndSymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'SpaceBetweenAmountAndSymbol' can't be null");
            }
            {
                entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.Currency.CreateSpaceBetweenAmountAndSymbol(SpaceBetweenAmountAndSymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DecimalDigits", out var DecimalDigitsUpdateValue))
        {
            if (DecimalDigitsUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'DecimalDigits' can't be null");
            }
            {
                entity.DecimalDigits = Cryptocash.Domain.Currency.CreateDecimalDigits(DecimalDigitsUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MajorName", out var MajorNameUpdateValue))
        {
            if (MajorNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MajorName' can't be null");
            }
            {
                entity.MajorName = Cryptocash.Domain.Currency.CreateMajorName(MajorNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MajorSymbol", out var MajorSymbolUpdateValue))
        {
            if (MajorSymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MajorSymbol' can't be null");
            }
            {
                entity.MajorSymbol = Cryptocash.Domain.Currency.CreateMajorSymbol(MajorSymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MinorName", out var MinorNameUpdateValue))
        {
            if (MinorNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MinorName' can't be null");
            }
            {
                entity.MinorName = Cryptocash.Domain.Currency.CreateMinorName(MinorNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MinorSymbol", out var MinorSymbolUpdateValue))
        {
            if (MinorSymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MinorSymbol' can't be null");
            }
            {
                entity.MinorSymbol = Cryptocash.Domain.Currency.CreateMinorSymbol(MinorSymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MinorToMajorValue", out var MinorToMajorValueUpdateValue))
        {
            if (MinorToMajorValueUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MinorToMajorValue' can't be null");
            }
            {
                entity.MinorToMajorValue = Cryptocash.Domain.Currency.CreateMinorToMajorValue(MinorToMajorValueUpdateValue);
            }
        }
    }
}

internal partial class CurrencyFactory : CurrencyFactoryBase
{
    public CurrencyFactory
    (
        IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto> banknotefactory,
        IEntityFactory<ExchangeRate, ExchangeRateCreateDto, ExchangeRateUpdateDto> exchangeratefactory
    ): base(banknotefactory,exchangeratefactory)
    {}
}