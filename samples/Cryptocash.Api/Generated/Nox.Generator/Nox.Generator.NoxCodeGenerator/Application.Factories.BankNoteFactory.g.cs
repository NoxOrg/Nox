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

    public void UpdateEntity(BankNote entity, BankNoteUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private Cryptocash.Domain.BankNote ToEntity(BankNoteCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.BankNote();
        entity.CashNote = Cryptocash.Domain.BankNote.CreateCashNote(createDto.CashNote);
        entity.Value = Cryptocash.Domain.BankNote.CreateValue(createDto.Value);
        return entity;
    }

    private void MapEntity(BankNote entity, BankNoteUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.CashNote = Cryptocash.Domain.BankNote.CreateCashNote(updateDto.CashNote);
        entity.Value = Cryptocash.Domain.BankNote.CreateValue(updateDto.Value);

        // TODO: discuss about keys
    }
}

public partial class BankNoteFactory : BankNoteFactoryBase
{
}