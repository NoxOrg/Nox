
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
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(BankNoteEntity));
        }        
    }

    public virtual async Task UpdateEntityAsync(BankNoteEntity entity, BankNoteUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(BankNoteEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(BankNoteEntity));
        }   
    }

    private async Task<Cryptocash.Domain.BankNote> ToEntityAsync(BankNoteUpsertDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.BankNote();
        exceptionCollector.Collect("CashNote", () => entity.SetIfNotNull(createDto.CashNote, (entity) => entity.CashNote = 
            Dto.BankNoteMetadata.CreateCashNote(createDto.CashNote.NonNullValue<System.String>())));
        exceptionCollector.Collect("Value", () => entity.SetIfNotNull(createDto.Value, (entity) => entity.Value = 
            Dto.BankNoteMetadata.CreateValue(createDto.Value.NonNullValue<MoneyDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(BankNoteEntity entity, BankNoteUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("CashNote",() => entity.CashNote = Dto.BankNoteMetadata.CreateCashNote(updateDto.CashNote.NonNullValue<System.String>()));
        exceptionCollector.Collect("Value",() => entity.Value = Dto.BankNoteMetadata.CreateValue(updateDto.Value.NonNullValue<MoneyDto>()));

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
                exceptionCollector.Collect("CashNote",() =>entity.CashNote = Dto.BankNoteMetadata.CreateCashNote(CashNoteUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Value", out var ValueUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(ValueUpdateValue, "Attribute 'Value' can't be null.");
            {
                var entityToUpdate = entity.Value is null ? new MoneyDto() : entity.Value.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, ValueUpdateValue);
                exceptionCollector.Collect("Value",() =>entity.Value = Dto.BankNoteMetadata.CreateValue(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}