// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNotesUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Currency's bank note identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "BankNote is required")]
    
    public System.String BankNote { get; set; } = default!;
    /// <summary>
    /// Is bank note rare or frequent (Required).
    /// </summary>
    [Required(ErrorMessage = "IsRare is required")]
    
    public System.Boolean IsRare { get; set; } = default!;

    /// <summary>
    /// BankNotes Currency's bank notes ExactlyOne Currencies
    /// </summary>
    [Required(ErrorMessage = "Currency is required")]
    public System.String CurrencyId { get; set; } = default!;
}