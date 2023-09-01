// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyCreateDto : CurrencyUpdateDto
{
    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
}