// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto;

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameUpdateDto
{
    /// <summary>
    /// Local name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Local name in native tongue (Optional).
    /// </summary>
    public System.String? NativeName { get; set; }
}