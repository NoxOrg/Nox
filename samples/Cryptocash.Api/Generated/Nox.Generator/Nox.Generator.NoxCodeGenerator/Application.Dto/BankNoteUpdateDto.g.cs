﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNoteUpdateDto : BankNoteUpdateDtoBase
{

}

/// <summary>
/// Currencies related frequent and rare bank notes
/// </summary>
public partial class BankNoteUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.BankNote>
{
    /// <summary>
    /// Currency's cash bank note identifier     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "CashNote is required")]
    
    public virtual System.String CashNote { get; set; } = default!;
    /// <summary>
    /// Bank note value     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Value is required")]
    
    public virtual MoneyDto Value { get; set; } = default!;
}