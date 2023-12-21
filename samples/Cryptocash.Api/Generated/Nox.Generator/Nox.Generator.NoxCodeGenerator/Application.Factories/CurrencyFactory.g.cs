// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Factories;

internal partial class CurrencyFactory : CurrencyFactoryBase
{
    public CurrencyFactory
    (
        IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> banknotefactory,
        IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> exchangeratefactory,
        IRepository repository
    ) : base(banknotefactory,exchangeratefactory, repository)
    {}
}

internal abstract class CurrencyFactoryBase : IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> BankNoteFactory {get;}
    protected IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> ExchangeRateFactory {get;}

    public CurrencyFactoryBase(
        IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> banknotefactory,
        IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> exchangeratefactory,
        IRepository repository
        )
    {
        BankNoteFactory = banknotefactory;
        ExchangeRateFactory = exchangeratefactory;
        _repository = repository;
    }

    public virtual async Task<CurrencyEntity> CreateEntityAsync(CurrencyCreateDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<Cryptocash.Domain.Currency> ToEntityAsync(CurrencyCreateDto createDto)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Currency();
        exceptionCollector.Collect("Id",() => entity.Id = CurrencyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Cryptocash.Domain.CurrencyMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("CurrencyIsoNumeric", () => entity.SetIfNotNull(createDto.CurrencyIsoNumeric, (entity) => entity.CurrencyIsoNumeric = 
            Cryptocash.Domain.CurrencyMetadata.CreateCurrencyIsoNumeric(createDto.CurrencyIsoNumeric.NonNullValue<System.Int16>())));
        exceptionCollector.Collect("Symbol", () => entity.SetIfNotNull(createDto.Symbol, (entity) => entity.Symbol = 
            Cryptocash.Domain.CurrencyMetadata.CreateSymbol(createDto.Symbol.NonNullValue<System.String>())));
        exceptionCollector.Collect("ThousandsSeparator", () => entity.SetIfNotNull(createDto.ThousandsSeparator, (entity) => entity.ThousandsSeparator = 
            Cryptocash.Domain.CurrencyMetadata.CreateThousandsSeparator(createDto.ThousandsSeparator.NonNullValue<System.String>())));
        exceptionCollector.Collect("DecimalSeparator", () => entity.SetIfNotNull(createDto.DecimalSeparator, (entity) => entity.DecimalSeparator = 
            Cryptocash.Domain.CurrencyMetadata.CreateDecimalSeparator(createDto.DecimalSeparator.NonNullValue<System.String>())));
        exceptionCollector.Collect("SpaceBetweenAmountAndSymbol", () => entity.SetIfNotNull(createDto.SpaceBetweenAmountAndSymbol, (entity) => entity.SpaceBetweenAmountAndSymbol = 
            Cryptocash.Domain.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(createDto.SpaceBetweenAmountAndSymbol.NonNullValue<System.Boolean>())));
        exceptionCollector.Collect("SymbolOnLeft", () => entity.SetIfNotNull(createDto.SymbolOnLeft, (entity) => entity.SymbolOnLeft = 
            Cryptocash.Domain.CurrencyMetadata.CreateSymbolOnLeft(createDto.SymbolOnLeft.NonNullValue<System.Boolean>())));
        exceptionCollector.Collect("DecimalDigits", () => entity.SetIfNotNull(createDto.DecimalDigits, (entity) => entity.DecimalDigits = 
            Cryptocash.Domain.CurrencyMetadata.CreateDecimalDigits(createDto.DecimalDigits.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("MajorName", () => entity.SetIfNotNull(createDto.MajorName, (entity) => entity.MajorName = 
            Cryptocash.Domain.CurrencyMetadata.CreateMajorName(createDto.MajorName.NonNullValue<System.String>())));
        exceptionCollector.Collect("MajorSymbol", () => entity.SetIfNotNull(createDto.MajorSymbol, (entity) => entity.MajorSymbol = 
            Cryptocash.Domain.CurrencyMetadata.CreateMajorSymbol(createDto.MajorSymbol.NonNullValue<System.String>())));
        exceptionCollector.Collect("MinorName", () => entity.SetIfNotNull(createDto.MinorName, (entity) => entity.MinorName = 
            Cryptocash.Domain.CurrencyMetadata.CreateMinorName(createDto.MinorName.NonNullValue<System.String>())));
        exceptionCollector.Collect("MinorSymbol", () => entity.SetIfNotNull(createDto.MinorSymbol, (entity) => entity.MinorSymbol = 
            Cryptocash.Domain.CurrencyMetadata.CreateMinorSymbol(createDto.MinorSymbol.NonNullValue<System.String>())));
        exceptionCollector.Collect("MinorToMajorValue", () => entity.SetIfNotNull(createDto.MinorToMajorValue, (entity) => entity.MinorToMajorValue = 
            Cryptocash.Domain.CurrencyMetadata.CreateMinorToMajorValue(createDto.MinorToMajorValue.NonNullValue<MoneyDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        foreach (var dto in createDto.BankNotes)
        {
            var newRelatedEntity = await BankNoteFactory.CreateEntityAsync(dto);
            entity.CreateRefToBankNotes(newRelatedEntity);
        }
        foreach (var dto in createDto.ExchangeRates)
        {
            var newRelatedEntity = await ExchangeRateFactory.CreateEntityAsync(dto);
            entity.CreateRefToExchangeRates(newRelatedEntity);
        }        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Cryptocash.Domain.CurrencyMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("CurrencyIsoNumeric",() => entity.CurrencyIsoNumeric = Cryptocash.Domain.CurrencyMetadata.CreateCurrencyIsoNumeric(updateDto.CurrencyIsoNumeric.NonNullValue<System.Int16>()));
        exceptionCollector.Collect("Symbol",() => entity.Symbol = Cryptocash.Domain.CurrencyMetadata.CreateSymbol(updateDto.Symbol.NonNullValue<System.String>()));
        if(updateDto.ThousandsSeparator is null)
        {
             entity.ThousandsSeparator = null;
        }
        else
        {
            exceptionCollector.Collect("ThousandsSeparator",() =>entity.ThousandsSeparator = Cryptocash.Domain.CurrencyMetadata.CreateThousandsSeparator(updateDto.ThousandsSeparator.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.DecimalSeparator is null)
        {
             entity.DecimalSeparator = null;
        }
        else
        {
            exceptionCollector.Collect("DecimalSeparator",() =>entity.DecimalSeparator = Cryptocash.Domain.CurrencyMetadata.CreateDecimalSeparator(updateDto.DecimalSeparator.ToValueFromNonNull<System.String>()));
        }
        exceptionCollector.Collect("SpaceBetweenAmountAndSymbol",() => entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(updateDto.SpaceBetweenAmountAndSymbol.NonNullValue<System.Boolean>()));
        exceptionCollector.Collect("SymbolOnLeft",() => entity.SymbolOnLeft = Cryptocash.Domain.CurrencyMetadata.CreateSymbolOnLeft(updateDto.SymbolOnLeft.NonNullValue<System.Boolean>()));
        exceptionCollector.Collect("DecimalDigits",() => entity.DecimalDigits = Cryptocash.Domain.CurrencyMetadata.CreateDecimalDigits(updateDto.DecimalDigits.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("MajorName",() => entity.MajorName = Cryptocash.Domain.CurrencyMetadata.CreateMajorName(updateDto.MajorName.NonNullValue<System.String>()));
        exceptionCollector.Collect("MajorSymbol",() => entity.MajorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMajorSymbol(updateDto.MajorSymbol.NonNullValue<System.String>()));
        exceptionCollector.Collect("MinorName",() => entity.MinorName = Cryptocash.Domain.CurrencyMetadata.CreateMinorName(updateDto.MinorName.NonNullValue<System.String>()));
        exceptionCollector.Collect("MinorSymbol",() => entity.MinorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMinorSymbol(updateDto.MinorSymbol.NonNullValue<System.String>()));
        exceptionCollector.Collect("MinorToMajorValue",() => entity.MinorToMajorValue = Cryptocash.Domain.CurrencyMetadata.CreateMinorToMajorValue(updateDto.MinorToMajorValue.NonNullValue<MoneyDto>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
	    await UpdateOwnedEntitiesAsync(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NameUpdateValue, "Attribute 'Name' can't be null.");
            {
                exceptionCollector.Collect("Name",() =>entity.Name = Cryptocash.Domain.CurrencyMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CurrencyIsoNumeric", out var CurrencyIsoNumericUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(CurrencyIsoNumericUpdateValue, "Attribute 'CurrencyIsoNumeric' can't be null.");
            {
                exceptionCollector.Collect("CurrencyIsoNumeric",() =>entity.CurrencyIsoNumeric = Cryptocash.Domain.CurrencyMetadata.CreateCurrencyIsoNumeric(CurrencyIsoNumericUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Symbol", out var SymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SymbolUpdateValue, "Attribute 'Symbol' can't be null.");
            {
                exceptionCollector.Collect("Symbol",() =>entity.Symbol = Cryptocash.Domain.CurrencyMetadata.CreateSymbol(SymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("ThousandsSeparator", out var ThousandsSeparatorUpdateValue))
        {
            if (ThousandsSeparatorUpdateValue == null) { entity.ThousandsSeparator = null; }
            else
            {
                exceptionCollector.Collect("ThousandsSeparator",() =>entity.ThousandsSeparator = Cryptocash.Domain.CurrencyMetadata.CreateThousandsSeparator(ThousandsSeparatorUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DecimalSeparator", out var DecimalSeparatorUpdateValue))
        {
            if (DecimalSeparatorUpdateValue == null) { entity.DecimalSeparator = null; }
            else
            {
                exceptionCollector.Collect("DecimalSeparator",() =>entity.DecimalSeparator = Cryptocash.Domain.CurrencyMetadata.CreateDecimalSeparator(DecimalSeparatorUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SpaceBetweenAmountAndSymbol", out var SpaceBetweenAmountAndSymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SpaceBetweenAmountAndSymbolUpdateValue, "Attribute 'SpaceBetweenAmountAndSymbol' can't be null.");
            {
                exceptionCollector.Collect("SpaceBetweenAmountAndSymbol",() =>entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(SpaceBetweenAmountAndSymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SymbolOnLeft", out var SymbolOnLeftUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SymbolOnLeftUpdateValue, "Attribute 'SymbolOnLeft' can't be null.");
            {
                exceptionCollector.Collect("SymbolOnLeft",() =>entity.SymbolOnLeft = Cryptocash.Domain.CurrencyMetadata.CreateSymbolOnLeft(SymbolOnLeftUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DecimalDigits", out var DecimalDigitsUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(DecimalDigitsUpdateValue, "Attribute 'DecimalDigits' can't be null.");
            {
                exceptionCollector.Collect("DecimalDigits",() =>entity.DecimalDigits = Cryptocash.Domain.CurrencyMetadata.CreateDecimalDigits(DecimalDigitsUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MajorName", out var MajorNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MajorNameUpdateValue, "Attribute 'MajorName' can't be null.");
            {
                exceptionCollector.Collect("MajorName",() =>entity.MajorName = Cryptocash.Domain.CurrencyMetadata.CreateMajorName(MajorNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MajorSymbol", out var MajorSymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MajorSymbolUpdateValue, "Attribute 'MajorSymbol' can't be null.");
            {
                exceptionCollector.Collect("MajorSymbol",() =>entity.MajorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMajorSymbol(MajorSymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MinorName", out var MinorNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MinorNameUpdateValue, "Attribute 'MinorName' can't be null.");
            {
                exceptionCollector.Collect("MinorName",() =>entity.MinorName = Cryptocash.Domain.CurrencyMetadata.CreateMinorName(MinorNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MinorSymbol", out var MinorSymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MinorSymbolUpdateValue, "Attribute 'MinorSymbol' can't be null.");
            {
                exceptionCollector.Collect("MinorSymbol",() =>entity.MinorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMinorSymbol(MinorSymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MinorToMajorValue", out var MinorToMajorValueUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MinorToMajorValueUpdateValue, "Attribute 'MinorToMajorValue' can't be null.");
            {
                var entityToUpdate = entity.MinorToMajorValue is null ? new MoneyDto() : entity.MinorToMajorValue.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, MinorToMajorValueUpdateValue);
                exceptionCollector.Collect("MinorToMajorValue",() =>entity.MinorToMajorValue = Cryptocash.Domain.CurrencyMetadata.CreateMinorToMajorValue(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private async Task UpdateOwnedEntitiesAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
	{
        if(!updateDto.BankNotes.Any())
        { 
            _repository.DeleteOwned(entity.BankNotes);
			entity.DeleteAllRefToBankNotes();
        }
		else
		{
			var updatedBankNotes = new List<Cryptocash.Domain.BankNote>();
			foreach(var ownedUpsertDto in updateDto.BankNotes)
			{
				if(ownedUpsertDto.Id is null)
					updatedBankNotes.Add(await BankNoteFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = Cryptocash.Domain.BankNoteMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.BankNotes.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("BankNotes.Id", key.ToString());
					else
					{
						await BankNoteFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedBankNotes.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<Cryptocash.Domain.BankNote>(
                entity.BankNotes.Where(x => !updatedBankNotes.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToBankNotes(updatedBankNotes);
		}
        if(!updateDto.ExchangeRates.Any())
        { 
            _repository.DeleteOwned(entity.ExchangeRates);
			entity.DeleteAllRefToExchangeRates();
        }
		else
		{
			var updatedExchangeRates = new List<Cryptocash.Domain.ExchangeRate>();
			foreach(var ownedUpsertDto in updateDto.ExchangeRates)
			{
				if(ownedUpsertDto.Id is null)
					updatedExchangeRates.Add(await ExchangeRateFactory.CreateEntityAsync(ownedUpsertDto));
				else
				{
					var key = Cryptocash.Domain.ExchangeRateMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.ExchangeRates.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("ExchangeRates.Id", key.ToString());
					else
					{
						await ExchangeRateFactory.UpdateEntityAsync(ownedEntity, ownedUpsertDto, cultureCode);
						updatedExchangeRates.Add(ownedEntity);
					}
				}
			}
            _repository.DeleteOwned<Cryptocash.Domain.ExchangeRate>(
                entity.ExchangeRates.Where(x => !updatedExchangeRates.Any(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToExchangeRates(updatedExchangeRates);
		}
	}
}