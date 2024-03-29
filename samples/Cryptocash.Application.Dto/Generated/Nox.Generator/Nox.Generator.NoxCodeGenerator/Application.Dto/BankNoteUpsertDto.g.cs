﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteUpsertDto : BankNoteUpsertDtoBase
{

}

/// <summary>
/// Currencies related frequent and rare bank notes
/// </summary>
public abstract class BankNoteUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// Currency bank note unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Currency's cash bank note identifier     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "CashNote is required")]
    public virtual System.String? CashNote { get; set; }

    /// <summary>
    /// Bank note value     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Value is required")]
    public virtual MoneyDto? Value { get; set; }
}