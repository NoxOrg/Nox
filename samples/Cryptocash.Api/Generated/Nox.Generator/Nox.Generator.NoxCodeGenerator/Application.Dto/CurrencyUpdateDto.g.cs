// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Currency and related data
/// </summary>
public partial class CurrencyUpdateDto : IEntityDto<DomainNamespace.Currency>
{
    /// <summary>
    /// Currency's name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Currency's iso number id 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "CurrencyIsoNumeric is required")]
    
    public System.Int16 CurrencyIsoNumeric { get; set; } = default!;
    /// <summary>
    /// Currency's symbol 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Symbol is required")]
    
    public System.String Symbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric thousands notation separator 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? ThousandsSeparator { get; set; }
    /// <summary>
    /// Currency's numeric decimal notation separator 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? DecimalSeparator { get; set; }
    /// <summary>
    /// Currency's numeric space between amount and symbol 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "SpaceBetweenAmountAndSymbol is required")]
    
    public System.Boolean SpaceBetweenAmountAndSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's numeric decimal digits 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "DecimalDigits is required")]
    
    public System.Int32 DecimalDigits { get; set; } = default!;
    /// <summary>
    /// Currency's major name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MajorName is required")]
    
    public System.String MajorName { get; set; } = default!;
    /// <summary>
    /// Currency's major display symbol 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MajorSymbol is required")]
    
    public System.String MajorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MinorName is required")]
    
    public System.String MinorName { get; set; } = default!;
    /// <summary>
    /// Currency's minor display symbol 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MinorSymbol is required")]
    
    public System.String MinorSymbol { get; set; } = default!;
    /// <summary>
    /// Currency's minor value when converted to major 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "MinorToMajorValue is required")]
    
    public MoneyDto MinorToMajorValue { get; set; } = default!;
}