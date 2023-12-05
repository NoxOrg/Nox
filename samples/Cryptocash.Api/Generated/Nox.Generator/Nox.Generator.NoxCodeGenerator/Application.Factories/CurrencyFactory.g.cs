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

internal abstract class CurrencyFactoryBase : IEntityFactory<CurrencyEntity, CurrencyCreateDto, CurrencyUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;
    protected IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> BankNoteFactory {get;}
    protected IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> ExchangeRateFactory {get;}

    public CurrencyFactoryBase
    (
        IEntityFactory<Cryptocash.Domain.BankNote, BankNoteUpsertDto, BankNoteUpsertDto> banknotefactory,
        IEntityFactory<Cryptocash.Domain.ExchangeRate, ExchangeRateUpsertDto, ExchangeRateUpsertDto> exchangeratefactory,
        IRepository repository
        )
    {
        BankNoteFactory = banknotefactory;
        ExchangeRateFactory = exchangeratefactory;
        _repository = repository;
    }

    public virtual CurrencyEntity CreateEntity(CurrencyCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.Currency ToEntity(CurrencyCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Currency();
        entity.Id = CurrencyMetadata.CreateId(createDto.Id);
        entity.Name = Cryptocash.Domain.CurrencyMetadata.CreateName(createDto.Name);
        entity.CurrencyIsoNumeric = Cryptocash.Domain.CurrencyMetadata.CreateCurrencyIsoNumeric(createDto.CurrencyIsoNumeric);
        entity.Symbol = Cryptocash.Domain.CurrencyMetadata.CreateSymbol(createDto.Symbol);
        entity.SetIfNotNull(createDto.ThousandsSeparator, (entity) => entity.ThousandsSeparator =Cryptocash.Domain.CurrencyMetadata.CreateThousandsSeparator(createDto.ThousandsSeparator.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.DecimalSeparator, (entity) => entity.DecimalSeparator =Cryptocash.Domain.CurrencyMetadata.CreateDecimalSeparator(createDto.DecimalSeparator.NonNullValue<System.String>()));
        entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(createDto.SpaceBetweenAmountAndSymbol);
        entity.SymbolOnLeft = Cryptocash.Domain.CurrencyMetadata.CreateSymbolOnLeft(createDto.SymbolOnLeft);
        entity.DecimalDigits = Cryptocash.Domain.CurrencyMetadata.CreateDecimalDigits(createDto.DecimalDigits);
        entity.MajorName = Cryptocash.Domain.CurrencyMetadata.CreateMajorName(createDto.MajorName);
        entity.MajorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMajorSymbol(createDto.MajorSymbol);
        entity.MinorName = Cryptocash.Domain.CurrencyMetadata.CreateMinorName(createDto.MinorName);
        entity.MinorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMinorSymbol(createDto.MinorSymbol);
        entity.MinorToMajorValue = Cryptocash.Domain.CurrencyMetadata.CreateMinorToMajorValue(createDto.MinorToMajorValue);
        createDto.BankNotes.ForEach(dto => entity.CreateRefToBankNotes(BankNoteFactory.CreateEntity(dto)));
        createDto.ExchangeRates.ForEach(dto => entity.CreateRefToExchangeRates(ExchangeRateFactory.CreateEntity(dto)));
        return entity;
    }

    private void UpdateEntityInternal(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.Name = Cryptocash.Domain.CurrencyMetadata.CreateName(updateDto.Name.NonNullValue<System.String>());
        entity.CurrencyIsoNumeric = Cryptocash.Domain.CurrencyMetadata.CreateCurrencyIsoNumeric(updateDto.CurrencyIsoNumeric.NonNullValue<System.Int16>());
        entity.Symbol = Cryptocash.Domain.CurrencyMetadata.CreateSymbol(updateDto.Symbol.NonNullValue<System.String>());
        if(updateDto.ThousandsSeparator is null)
        {
             entity.ThousandsSeparator = null;
        }
        else
        {
            entity.ThousandsSeparator = Cryptocash.Domain.CurrencyMetadata.CreateThousandsSeparator(updateDto.ThousandsSeparator.ToValueFromNonNull<System.String>());
        }
        if(updateDto.DecimalSeparator is null)
        {
             entity.DecimalSeparator = null;
        }
        else
        {
            entity.DecimalSeparator = Cryptocash.Domain.CurrencyMetadata.CreateDecimalSeparator(updateDto.DecimalSeparator.ToValueFromNonNull<System.String>());
        }
        entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(updateDto.SpaceBetweenAmountAndSymbol.NonNullValue<System.Boolean>());
        entity.SymbolOnLeft = Cryptocash.Domain.CurrencyMetadata.CreateSymbolOnLeft(updateDto.SymbolOnLeft.NonNullValue<System.Boolean>());
        entity.DecimalDigits = Cryptocash.Domain.CurrencyMetadata.CreateDecimalDigits(updateDto.DecimalDigits.NonNullValue<System.Int32>());
        entity.MajorName = Cryptocash.Domain.CurrencyMetadata.CreateMajorName(updateDto.MajorName.NonNullValue<System.String>());
        entity.MajorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMajorSymbol(updateDto.MajorSymbol.NonNullValue<System.String>());
        entity.MinorName = Cryptocash.Domain.CurrencyMetadata.CreateMinorName(updateDto.MinorName.NonNullValue<System.String>());
        entity.MinorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMinorSymbol(updateDto.MinorSymbol.NonNullValue<System.String>());
        entity.MinorToMajorValue = Cryptocash.Domain.CurrencyMetadata.CreateMinorToMajorValue(updateDto.MinorToMajorValue.NonNullValue<MoneyDto>());
	    UpdateOwnedEntities(entity, updateDto, cultureCode);
    }

    private void PartialUpdateEntityInternal(CurrencyEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("Name", out var NameUpdateValue))
        {
            if (NameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Name' can't be null");
            }
            {
                entity.Name = Cryptocash.Domain.CurrencyMetadata.CreateName(NameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CurrencyIsoNumeric", out var CurrencyIsoNumericUpdateValue))
        {
            if (CurrencyIsoNumericUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'CurrencyIsoNumeric' can't be null");
            }
            {
                entity.CurrencyIsoNumeric = Cryptocash.Domain.CurrencyMetadata.CreateCurrencyIsoNumeric(CurrencyIsoNumericUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Symbol", out var SymbolUpdateValue))
        {
            if (SymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Symbol' can't be null");
            }
            {
                entity.Symbol = Cryptocash.Domain.CurrencyMetadata.CreateSymbol(SymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("ThousandsSeparator", out var ThousandsSeparatorUpdateValue))
        {
            if (ThousandsSeparatorUpdateValue == null) { entity.ThousandsSeparator = null; }
            else
            {
                entity.ThousandsSeparator = Cryptocash.Domain.CurrencyMetadata.CreateThousandsSeparator(ThousandsSeparatorUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DecimalSeparator", out var DecimalSeparatorUpdateValue))
        {
            if (DecimalSeparatorUpdateValue == null) { entity.DecimalSeparator = null; }
            else
            {
                entity.DecimalSeparator = Cryptocash.Domain.CurrencyMetadata.CreateDecimalSeparator(DecimalSeparatorUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("SpaceBetweenAmountAndSymbol", out var SpaceBetweenAmountAndSymbolUpdateValue))
        {
            if (SpaceBetweenAmountAndSymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'SpaceBetweenAmountAndSymbol' can't be null");
            }
            {
                entity.SpaceBetweenAmountAndSymbol = Cryptocash.Domain.CurrencyMetadata.CreateSpaceBetweenAmountAndSymbol(SpaceBetweenAmountAndSymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("SymbolOnLeft", out var SymbolOnLeftUpdateValue))
        {
            if (SymbolOnLeftUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'SymbolOnLeft' can't be null");
            }
            {
                entity.SymbolOnLeft = Cryptocash.Domain.CurrencyMetadata.CreateSymbolOnLeft(SymbolOnLeftUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DecimalDigits", out var DecimalDigitsUpdateValue))
        {
            if (DecimalDigitsUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'DecimalDigits' can't be null");
            }
            {
                entity.DecimalDigits = Cryptocash.Domain.CurrencyMetadata.CreateDecimalDigits(DecimalDigitsUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MajorName", out var MajorNameUpdateValue))
        {
            if (MajorNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MajorName' can't be null");
            }
            {
                entity.MajorName = Cryptocash.Domain.CurrencyMetadata.CreateMajorName(MajorNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MajorSymbol", out var MajorSymbolUpdateValue))
        {
            if (MajorSymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MajorSymbol' can't be null");
            }
            {
                entity.MajorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMajorSymbol(MajorSymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MinorName", out var MinorNameUpdateValue))
        {
            if (MinorNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MinorName' can't be null");
            }
            {
                entity.MinorName = Cryptocash.Domain.CurrencyMetadata.CreateMinorName(MinorNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MinorSymbol", out var MinorSymbolUpdateValue))
        {
            if (MinorSymbolUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MinorSymbol' can't be null");
            }
            {
                entity.MinorSymbol = Cryptocash.Domain.CurrencyMetadata.CreateMinorSymbol(MinorSymbolUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MinorToMajorValue", out var MinorToMajorValueUpdateValue))
        {
            if (MinorToMajorValueUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'MinorToMajorValue' can't be null");
            }
            {
                var entityToUpdate = entity.MinorToMajorValue is null ? new MoneyDto() : entity.MinorToMajorValue.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, MinorToMajorValueUpdateValue);
                entity.MinorToMajorValue = Cryptocash.Domain.CurrencyMetadata.CreateMinorToMajorValue(entityToUpdate);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;

	private void UpdateOwnedEntities(CurrencyEntity entity, CurrencyUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
					updatedBankNotes.Add(BankNoteFactory.CreateEntity(ownedUpsertDto));
				else
				{
					var key = Cryptocash.Domain.BankNoteMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.BankNotes.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("BankNotes.Id", key.ToString());
					else
					{
						BankNoteFactory.UpdateEntity(ownedEntity, ownedUpsertDto, cultureCode);
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
					updatedExchangeRates.Add(ExchangeRateFactory.CreateEntity(ownedUpsertDto));
				else
				{
					var key = Cryptocash.Domain.ExchangeRateMetadata.CreateId(ownedUpsertDto.Id.NonNullValue<System.Int64>());
					var ownedEntity = entity.ExchangeRates.FirstOrDefault(x => x.Id == key);
					if(ownedEntity is null)
						throw new RelatedEntityNotFoundException("ExchangeRates.Id", key.ToString());
					else
					{
						ExchangeRateFactory.UpdateEntity(ownedEntity, ownedUpsertDto, cultureCode);
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