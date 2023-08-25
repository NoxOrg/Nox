// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto; 

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// The currency's iso number id (Required).
    /// </summary>
    [Required(ErrorMessage = "CurrencyIsoNumeric is required")]
    
    public System.Int16 CurrencyIsoNumeric { get; set; } = default!;
    /// <summary>
    /// The currency's symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "Symbol is required")]
    
    public System.String Symbol { get; set; } = default!;
    /// <summary>
    /// The currency's numeric thousands notation separator (Required).
    /// </summary>
    [Required(ErrorMessage = "ThousandsSeperator is required")]
    
    public System.String ThousandsSeperator { get; set; } = default!;
    /// <summary>
    /// The currency's numeric decimal notation separator (Required).
    /// </summary>
    [Required(ErrorMessage = "DecimalSeparator is required")]
    
    public System.String DecimalSeparator { get; set; } = default!;
    /// <summary>
    /// The currency's numeric space between amount and symbol (Required).
    /// </summary>
    [Required(ErrorMessage = "SpaceBetweenAmountAndSymbol is required")]
    
    public System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;
    /// <summary>
    /// The currency's numeric decimal digits (Required).
    /// </summary>
    [Required(ErrorMessage = "DecimalDigits is required")]
    
    public System.Int32 DecimalDigits { get; set; } = default!;
}