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

public abstract class BankNoteFactoryBase: IEntityFactory<BankNote,BankNoteCreateDto>
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
    private Cryptocash.Domain.BankNote ToEntity(BankNoteCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.BankNote();
        entity.CashNote = Cryptocash.Domain.BankNote.CreateCashNote(createDto.CashNote);
        entity.Value = Cryptocash.Domain.BankNote.CreateValue(createDto.Value);
        return entity;
    }
}

public partial class BankNoteFactory : BankNoteFactoryBase
{
}