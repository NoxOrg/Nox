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
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class BankNoteFactoryBase : IEntityFactory<BankNoteEntity, BankNoteUpsertDto, BankNoteUpsertDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public BankNoteFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<BankNoteEntity> CreateEntityAsync(BankNoteUpsertDto createDto)
    {
        return await ToEntityAsync(createDto);
    }

    public virtual async Task UpdateEntityAsync(BankNoteEntity entity, BankNoteUpsertDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private async Task<Cryptocash.Domain.BankNote> ToEntityAsync(BankNoteUpsertDto createDto)
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}