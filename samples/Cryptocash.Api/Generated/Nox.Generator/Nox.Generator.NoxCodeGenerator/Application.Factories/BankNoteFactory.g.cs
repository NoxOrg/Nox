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

internal abstract class BankNoteFactoryBase : IEntityFactory<BankNoteEntity, BankNoteCreateDto, BankNoteUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public BankNoteFactoryBase
    (
        )
    {
    }

    public virtual BankNoteEntity CreateEntity(BankNoteCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(BankNoteEntity entity, BankNoteUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.BankNote ToEntity(BankNoteCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.BankNote();
        entity.CashNote = Cryptocash.Domain.BankNoteMetadata.CreateCashNote(createDto.CashNote);
        entity.Value = Cryptocash.Domain.BankNoteMetadata.CreateValue(createDto.Value);
        return entity;
    }

    private void UpdateEntityInternal(BankNoteEntity entity, BankNoteUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.CashNote = Cryptocash.Domain.BankNoteMetadata.CreateCashNote(updateDto.CashNote.NonNullValue<System.String>());
        entity.Value = Cryptocash.Domain.BankNoteMetadata.CreateValue(updateDto.Value.NonNullValue<MoneyDto>());
    }

    private void PartialUpdateEntityInternal(BankNoteEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("CashNote", out var CashNoteUpdateValue))
        {
            if (CashNoteUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'CashNote' can't be null");
            }
            {
                entity.CashNote = Cryptocash.Domain.BankNoteMetadata.CreateCashNote(CashNoteUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Value", out var ValueUpdateValue))
        {
            if (ValueUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Value' can't be null");
            }
            {
                entity.Value = Cryptocash.Domain.BankNoteMetadata.CreateValue(ValueUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class BankNoteFactory : BankNoteFactoryBase
{
}