// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Entity.
/// </summary>
public partial class CountryUpdateDto
{
    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Population (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }
    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public MoneyDto? CountryDebt { get; set; }
    /// <summary>
    /// First Official Language (Optional).
    /// </summary>
    public System.String? FirstLanguageCode { get; set; }
}