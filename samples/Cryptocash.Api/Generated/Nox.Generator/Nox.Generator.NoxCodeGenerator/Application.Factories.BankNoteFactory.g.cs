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
using BankNote = Cryptocash.Domain.BankNote;

namespace Cryptocash.Application.Factories;

public abstract class BankNoteFactoryBase : IEntityFactory<BankNote, BankNoteCreateDto, BankNoteUpdateDto>
{

    public BankNoteFactoryBase
    (
        )
    {
    }

    public virtual BankNote CreateEntity(BankNoteCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(BankNote entity, BankNoteUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private Cryptocash.Domain.BankNote ToEntity(BankNoteCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.BankNote();
        entity.CashNote = Cryptocash.Domain.BankNote.CreateCashNote(createDto.CashNote);
        entity.Value = Cryptocash.Domain.BankNote.CreateValue(createDto.Value);
        return entity;
    }

    private void UpdateEntityInternal(BankNote entity, BankNoteUpdateDto updateDto)
    {
        entity.CashNote = Cryptocash.Domain.BankNote.CreateCashNote(updateDto.CashNote.NonNullValue<System.String>());
        entity.Value = Cryptocash.Domain.BankNote.CreateValue(updateDto.Value.NonNullValue<MoneyDto>());
    }
}

public partial class BankNoteFactory : BankNoteFactoryBase
{
}