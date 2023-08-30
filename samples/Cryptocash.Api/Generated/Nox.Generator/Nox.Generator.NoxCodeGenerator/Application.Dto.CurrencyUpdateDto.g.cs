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
public partial class CurrencyUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Currency's name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Currency's iso number id (Required).
    /// </summary>
    [Required(ErrorMessage = "CurrencyIsoNumeric is required")]
    
    public System.Int16 CurrencyIsoNumeric { get; set; } = default!;
    /// <summary>
    /// Currency's symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "Symbol is required")]
    
    public System.String Symbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric thousands notation separator (Optional).
    /// </summary>
    public System.String? ThousandsSeparator { get; set; } 
    /// <summary>
    /// Currency's numeric decimal notation separator (Optional).
    /// </summary>
    public System.String? DecimalSeparator { get; set; } 
    /// <summary>
    /// Currency's numeric space between amount and symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "SpaceBetweenAmountAndSymbol is required")]
    
    public System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric decimal digits (Required).
    /// </summary>
    [Required(ErrorMessage = "DecimalDigits is required")]
    
    public System.Int32 DecimalDigits { get; set; } = default!;
}