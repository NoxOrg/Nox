// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteCreateDto : IEntityCreateDto <BankNote>
{    
    /// <summary>
    /// Currency's cash bank note identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "CashNote is required")]
    
    public System.String CashNote { get; set; } = default!;    
    /// <summary>
    /// Bank note value (Required).
    /// </summary>
    [Required(ErrorMessage = "Value is required")]
    
    public MoneyDto Value { get; set; } = default!;

    public Cryptocash.Domain.BankNote ToEntity()
    {
        var entity = new Cryptocash.Domain.BankNote();
        entity.CashNote = Cryptocash.Domain.BankNote.CreateCashNote(CashNote);
        entity.Value = Cryptocash.Domain.BankNote.CreateValue(Value);
        return entity;
    }
}