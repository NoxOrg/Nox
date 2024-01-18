
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
using Dto = Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CurrencyEntity = Cryptocash.Domain.Currency;

namespace Cryptocash.Application.Factories;

internal partial class CurrencyFactory : CurrencyFactoryBase
{
    public CurrencyFactory
    (
        IRepository repository,
        IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> banknotefactory,
        IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> exchangeratefactory
    ) : base(repository, banknotefactory, exchangeratefactory)
    {}
}

internal abstract class CurrencyFactoryBase : IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto>
{
    private readonly IRepository _repository;
    protected IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> BankNoteFactory {get;}
    protected IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> ExchangeRateFactory {get;}

    public CurrencyFactoryBase(
        IRepository repository,
        IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> banknotefactory,
        IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> exchangeratefactory
        )
    {
        _repository = repository;
        BankNoteFactory = banknotefactory;
        ExchangeRateFactory = exchangeratefactory;
    }

    public virtual async Task<CurrencyEntity> CreateEntityAsync(CurrencyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CurrencyEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CurrencyEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CurrencyEntity));
        }   
    }

    private async Task<Cryptocash.Domain.Currency> ToEntityAsync(CurrencyCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Currency();
        exceptionCollector.Collect("Id",() => entity.Id = Dto.CurrencyMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("Name", () => entity.SetIfNotNull(createDto.Name, (entity) => entity.Name = 
            Dto.CurrencyMetadata.CreateName(createDto.Name.NonNullValue<System.String>())));
        exceptionCollector.Collect("CurrencyIsoNumeric", () => entity.SetIfNotNull(createDto.CurrencyIsoNumeric, (entity) => entity.CurrencyIsoNumeric = 
            Dto.CurrencyMetadata.CreateCurrencyIsoNumeric(createDto.CurrencyIsoNumeric.NonNullValue<System.Int16>())));
        exceptionCollector.Collect("Symbol", () => entity.SetIfNotNull(createDto.Symbol, (entity) => entity.Symbol = 
            Dto.CurrencyMetadata.CreateSymbol(createDto.Symbol.NonNullValue<System.String>())));
        exceptionCollector.Collect("ThousandsSeparator", () => entity.SetIfNotNull(createDto.ThousandsSeparator, (entity) => entity.ThousandsSeparator = 
            Dto.CurrencyMetadata.CreateThousandsSeparator(createDto.ThousandsSeparator.NonNullValue<System.String>())));
        exceptionCollector.Collect("DecimalSeparator", () => entity.SetIfNotNull(createDto.DecimalSeparator, (entity) => entity.DecimalSeparator = 
            Dto.CurrencyMetadata.CreateDecimalSeparator(createDto.DecimalSeparator.NonNullValue<System.String>())));
        exceptionCollector.Collect("SpaceBetweenAmountAndSymbol", () => entity.SetIfNotNull(createDto.SpaceBetweenAmountAndSymbol, (entity) => entity.SpaceBetweenAmountAndSymbol = 
            Dto.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(createDto.SpaceBetweenAmountAndSymbol.NonNullValue<System.Boolean>())));
        exceptionCollector.Collect("SymbolOnLeft", () => entity.SetIfNotNull(createDto.SymbolOnLeft, (entity) => entity.SymbolOnLeft = 
            Dto.CurrencyMetadata.CreateSymbolOnLeft(createDto.SymbolOnLeft.NonNullValue<System.Boolean>())));
        exceptionCollector.Collect("DecimalDigits", () => entity.SetIfNotNull(createDto.DecimalDigits, (entity) => entity.DecimalDigits = 
            Dto.CurrencyMetadata.CreateDecimalDigits(createDto.DecimalDigits.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("MajorName", () => entity.SetIfNotNull(createDto.MajorName, (entity) => entity.MajorName = 
            Dto.CurrencyMetadata.CreateMajorName(createDto.MajorName.NonNullValue<System.String>())));
        exceptionCollector.Collect("MajorSymbol", () => entity.SetIfNotNull(createDto.MajorSymbol, (entity) => entity.MajorSymbol = 
            Dto.CurrencyMetadata.CreateMajorSymbol(createDto.MajorSymbol.NonNullValue<System.String>())));
        exceptionCollector.Collect("MinorName", () => entity.SetIfNotNull(createDto.MinorName, (entity) => entity.MinorName = 
            Dto.CurrencyMetadata.CreateMinorName(createDto.MinorName.NonNullValue<System.String>())));
        exceptionCollector.Collect("MinorSymbol", () => entity.SetIfNotNull(createDto.MinorSymbol, (entity) => entity.MinorSymbol = 
            Dto.CurrencyMetadata.CreateMinorSymbol(createDto.MinorSymbol.NonNullValue<System.String>())));
        exceptionCollector.Collect("MinorToMajorValue", () => entity.SetIfNotNull(createDto.MinorToMajorValue, (entity) => entity.MinorToMajorValue = 
            Dto.CurrencyMetadata.CreateMinorToMajorValue(createDto.MinorToMajorValue.NonNullValue<MoneyDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        createDto.BankNotes?.ForEach(async dto =>
        {
            var bankNote = await BankNoteFactory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefToBankNotes(bankNote);
        });
        createDto.ExchangeRates?.ForEach(async dto =>
        {
            var exchangeRate = await ExchangeRateFactory.CreateEntityAsync(dto, cultureCode);
            entity.CreateRefToExchangeRates(exchangeRate);
        });        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("Name",() => entity.Name = Dto.CurrencyMetadata.CreateName(updateDto.Name.NonNullValue<System.String>()));
        exceptionCollector.Collect("CurrencyIsoNumeric",() => entity.CurrencyIsoNumeric = Dto.CurrencyMetadata.CreateCurrencyIsoNumeric(updateDto.CurrencyIsoNumeric.NonNullValue<System.Int16>()));
        exceptionCollector.Collect("Symbol",() => entity.Symbol = Dto.CurrencyMetadata.CreateSymbol(updateDto.Symbol.NonNullValue<System.String>()));
        if(updateDto.ThousandsSeparator is null)
        {
             entity.ThousandsSeparator = null;
        }
        else
        {
            exceptionCollector.Collect("ThousandsSeparator",() =>entity.ThousandsSeparator = Dto.CurrencyMetadata.CreateThousandsSeparator(updateDto.ThousandsSeparator.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.DecimalSeparator is null)
        {
             entity.DecimalSeparator = null;
        }
        else
        {
            exceptionCollector.Collect("DecimalSeparator",() =>entity.DecimalSeparator = Dto.CurrencyMetadata.CreateDecimalSeparator(updateDto.DecimalSeparator.ToValueFromNonNull<System.String>()));
        }
        exceptionCollector.Collect("SpaceBetweenAmountAndSymbol",() => entity.SpaceBetweenAmountAndSymbol = Dto.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(updateDto.SpaceBetweenAmountAndSymbol.NonNullValue<System.Boolean>()));
        exceptionCollector.Collect("SymbolOnLeft",() => entity.SymbolOnLeft = Dto.CurrencyMetadata.CreateSymbolOnLeft(updateDto.SymbolOnLeft.NonNullValue<System.Boolean>()));
        exceptionCollector.Collect("DecimalDigits",() => entity.DecimalDigits = Dto.CurrencyMetadata.CreateDecimalDigits(updateDto.DecimalDigits.NonNullValue<System.Int32>()));
        exceptionCollector.Collect("MajorName",() => entity.MajorName = Dto.CurrencyMetadata.CreateMajorName(updateDto.MajorName.NonNullValue<System.String>()));
        exceptionCollector.Collect("MajorSymbol",() => entity.MajorSymbol = Dto.CurrencyMetadata.CreateMajorSymbol(updateDto.MajorSymbol.NonNullValue<System.String>()));
        exceptionCollector.Collect("MinorName",() => entity.MinorName = Dto.CurrencyMetadata.CreateMinorName(updateDto.MinorName.NonNullValue<System.String>()));
        exceptionCollector.Collect("MinorSymbol",() => entity.MinorSymbol = Dto.CurrencyMetadata.CreateMinorSymbol(updateDto.MinorSymbol.NonNullValue<System.String>()));
        exceptionCollector.Collect("MinorToMajorValue",() => entity.MinorToMajorValue = Dto.CurrencyMetadata.CreateMinorToMajorValue(updateDto.MinorToMajorValue.NonNullValue<MoneyDto>()));

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
                exceptionCollector.Collect("Name",() =>entity.Name = Dto.CurrencyMetadata.CreateName(NameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CurrencyIsoNumeric", out var CurrencyIsoNumericUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(CurrencyIsoNumericUpdateValue, "Attribute 'CurrencyIsoNumeric' can't be null.");
            {
                exceptionCollector.Collect("CurrencyIsoNumeric",() =>entity.CurrencyIsoNumeric = Dto.CurrencyMetadata.CreateCurrencyIsoNumeric(CurrencyIsoNumericUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Symbol", out var SymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SymbolUpdateValue, "Attribute 'Symbol' can't be null.");
            {
                exceptionCollector.Collect("Symbol",() =>entity.Symbol = Dto.CurrencyMetadata.CreateSymbol(SymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("ThousandsSeparator", out var ThousandsSeparatorUpdateValue))
        {
            if (ThousandsSeparatorUpdateValue == null) { entity.ThousandsSeparator = null; }
            else
            {
                exceptionCollector.Collect("ThousandsSeparator",() =>entity.ThousandsSeparator = Dto.CurrencyMetadata.CreateThousandsSeparator(ThousandsSeparatorUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DecimalSeparator", out var DecimalSeparatorUpdateValue))
        {
            if (DecimalSeparatorUpdateValue == null) { entity.DecimalSeparator = null; }
            else
            {
                exceptionCollector.Collect("DecimalSeparator",() =>entity.DecimalSeparator = Dto.CurrencyMetadata.CreateDecimalSeparator(DecimalSeparatorUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SpaceBetweenAmountAndSymbol", out var SpaceBetweenAmountAndSymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SpaceBetweenAmountAndSymbolUpdateValue, "Attribute 'SpaceBetweenAmountAndSymbol' can't be null.");
            {
                exceptionCollector.Collect("SpaceBetweenAmountAndSymbol",() =>entity.SpaceBetweenAmountAndSymbol = Dto.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(SpaceBetweenAmountAndSymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("SymbolOnLeft", out var SymbolOnLeftUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(SymbolOnLeftUpdateValue, "Attribute 'SymbolOnLeft' can't be null.");
            {
                exceptionCollector.Collect("SymbolOnLeft",() =>entity.SymbolOnLeft = Dto.CurrencyMetadata.CreateSymbolOnLeft(SymbolOnLeftUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DecimalDigits", out var DecimalDigitsUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(DecimalDigitsUpdateValue, "Attribute 'DecimalDigits' can't be null.");
            {
                exceptionCollector.Collect("DecimalDigits",() =>entity.DecimalDigits = Dto.CurrencyMetadata.CreateDecimalDigits(DecimalDigitsUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MajorName", out var MajorNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MajorNameUpdateValue, "Attribute 'MajorName' can't be null.");
            {
                exceptionCollector.Collect("MajorName",() =>entity.MajorName = Dto.CurrencyMetadata.CreateMajorName(MajorNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MajorSymbol", out var MajorSymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MajorSymbolUpdateValue, "Attribute 'MajorSymbol' can't be null.");
            {
                exceptionCollector.Collect("MajorSymbol",() =>entity.MajorSymbol = Dto.CurrencyMetadata.CreateMajorSymbol(MajorSymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MinorName", out var MinorNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MinorNameUpdateValue, "Attribute 'MinorName' can't be null.");
            {
                exceptionCollector.Collect("MinorName",() =>entity.MinorName = Dto.CurrencyMetadata.CreateMinorName(MinorNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MinorSymbol", out var MinorSymbolUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MinorSymbolUpdateValue, "Attribute 'MinorSymbol' can't be null.");
            {
                exceptionCollector.Collect("MinorSymbol",() =>entity.MinorSymbol = Dto.CurrencyMetadata.CreateMinorSymbol(MinorSymbolUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MinorToMajorValue", out var MinorToMajorValueUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(MinorToMajorValueUpdateValue, "Attribute 'MinorToMajorValue' can't be null.");
            {
                var entityToUpdate = entity.MinorToMajorValue is null ? new MoneyDto() : entity.MinorToMajorValue.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, MinorToMajorValueUpdateValue);
                exceptionCollector.Collect("MinorToMajorValue",() =>entity.MinorToMajorValue = Dto.CurrencyMetadata.CreateMinorToMajorValue(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }

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
                {
                    var ownedEntity = await BankNoteFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedBankNotes.Add(ownedEntity);
                }
				else
				{
					var key = Dto.BankNoteMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
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
                entity.BankNotes.Where(x => !updatedBankNotes.Exists(upd => upd.Id == x.Id)).ToList());
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
                {
                    var ownedEntity = await ExchangeRateFactory.CreateEntityAsync(ownedUpsertDto, cultureCode);
					updatedExchangeRates.Add(ownedEntity);
                }
				else
				{
					var key = Dto.ExchangeRateMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
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
                entity.ExchangeRates.Where(x => !updatedExchangeRates.Exists(upd => upd.Id == x.Id)).ToList());
			entity.UpdateRefToExchangeRates(updatedExchangeRates);
		}
	}
}