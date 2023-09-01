﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class CurrencyBankNotesUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The currency's bank note identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "BankNote is required")]
    
    public System.String BankNote { get; set; } = default!;
    /// <summary>
    /// Is bank note rare or frequent (Required).
    /// </summary>
    [Required(ErrorMessage = "IsRare is required")]
    
    public System.Boolean IsRare { get; set; } = default!;
}