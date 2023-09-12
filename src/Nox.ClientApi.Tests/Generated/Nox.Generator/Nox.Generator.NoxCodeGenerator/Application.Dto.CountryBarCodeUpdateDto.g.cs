// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto;

/// <summary>
/// Bar code for country.
/// </summary>
public partial class CountryBarCodeUpdateDto
{
    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    [Required(ErrorMessage = "BarCodeName is required")]
    
    public System.String BarCodeName { get; set; } = default!;
    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public System.Int32? BarCodeNumber { get; set; }
}