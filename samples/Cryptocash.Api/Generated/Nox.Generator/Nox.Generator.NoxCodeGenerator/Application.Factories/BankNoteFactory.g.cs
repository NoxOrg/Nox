
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
using BankNoteEntity = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Factories;

internal partial class BankNoteFactory : BankNoteFactoryBase
{
    public BankNoteFactory
    (
    ) : base()
    {}
}

internal abstract class BankNoteFactoryBase : IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto>
{

    public BankNoteFactoryBase(
        )
    {
    }

    public virtual async Task<BankNoteEntity> CreateEntityAsync(BankNoteUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(BankNoteEntity entity, BankNoteUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
=======
>>>>>>> Merge conflicts have been resolved
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
<<<<<<< main
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
=======
>>>>>>> Merge conflicts have been resolved
    }

    private async Task<Cryptocash.Domain.BankNote> ToEntityAsync(BankNoteUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.BankNote();
        exceptionCollector.Collect("CashNote", () => entity.SetIfNotNull(createDto.CashNote, (entity) => entity.CashNote = 
            Cryptocash.Domain.BankNoteMetadata.CreateCashNote(createDto.CashNote.NonNullValue<System.String>())));
        exceptionCollector.Collect("Value", () => entity.SetIfNotNull(createDto.Value, (entity) => entity.Value = 
            Cryptocash.Domain.BankNoteMetadata.CreateValue(createDto.Value.NonNullValue<MoneyDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(BankNoteEntity entity, BankNoteUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("CashNote",() => entity.CashNote = Cryptocash.Domain.BankNoteMetadata.CreateCashNote(updateDto.CashNote.NonNullValue<System.String>()));
        exceptionCollector.Collect("Value",() => entity.Value = Cryptocash.Domain.BankNoteMetadata.CreateValue(updateDto.Value.NonNullValue<MoneyDto>()));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("CashNote", out var CashNoteUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(CashNoteUpdateValue, "Attribute 'CashNote' can't be null.");
            {
                exceptionCollector.Collect("CashNote",() =>entity.CashNote = Cryptocash.Domain.BankNoteMetadata.CreateCashNote(CashNoteUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Value", out var ValueUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(ValueUpdateValue, "Attribute 'Value' can't be null.");
            {
                var entityToUpdate = entity.Value is null ? new MoneyDto() : entity.Value.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, ValueUpdateValue);
                exceptionCollector.Collect("Value",() =>entity.Value = Cryptocash.Domain.BankNoteMetadata.CreateValue(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}