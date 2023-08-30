// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto; 

/// <summary>
/// Currencies related units major and minor.
/// </summary>
public partial class CurrencyUnitsUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Currency's major name (Required).
    /// </summary>
    [Required(ErrorMessage = "MajorName is required")]
    
    public System.String MajorName { get; set; } = default!;
    /// <summary>
    /// Currency's major display symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "MajorSymbol is required")]
    
    public System.String MajorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor name (Required).
    /// </summary>
    [Required(ErrorMessage = "MinorName is required")]
    
    public System.String MinorName { get; set; } = default!;
    /// <summary>
    /// Currency's minor display symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "MinorSymbol is required")]
    
    public System.String MinorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor value when converted to major (Required).
    /// </summary>
    [Required(ErrorMessage = "MinorToMajorValue is required")]
    
    public MoneyDto MinorToMajorValue { get; set; } = default!;
}