// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

using BankNoteEntity = Cryptocash.Domain.BankNote;
namespace Cryptocash.Application.Dto;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteUpdateDto : IEntityDto<BankNoteEntity>
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
}