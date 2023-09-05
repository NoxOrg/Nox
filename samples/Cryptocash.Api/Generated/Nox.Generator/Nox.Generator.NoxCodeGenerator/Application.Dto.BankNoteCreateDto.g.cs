// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteCreateDto : BankNoteUpdateDto
{

    public BankNote ToEntity()
    {
        var entity = new BankNote();
        entity.CashNote = BankNote.CreateCashNote(CashNote);
        entity.Value = BankNote.CreateValue(Value);
        return entity;
    }
}