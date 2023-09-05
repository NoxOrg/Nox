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
public partial class BankNotesCreateDto : BankNotesUpdateDto
{

    public BankNotes ToEntity()
    {
        var entity = new BankNotes();
        entity.BankNote = BankNotes.CreateBankNote(BankNote);
        entity.IsRare = BankNotes.CreateIsRare(IsRare);
        //entity.Currency = Currency.ToEntity();
        return entity;
    }
}