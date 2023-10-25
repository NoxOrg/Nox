// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class BankNoteCreateDto : BankNoteCreateDtoBase
{

}

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public abstract class BankNoteCreateDtoBase : IEntityDto<DomainNamespace.BankNote>
{
    /// <summary>
    /// Currency's cash bank note identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "CashNote is required")]
    
    public virtual System.String CashNote { get; set; } = default!;
    /// <summary>
    /// Bank note value (Required).
    /// </summary>
    [Required(ErrorMessage = "Value is required")]
    
    public virtual MoneyDto Value { get; set; } = default!;
}