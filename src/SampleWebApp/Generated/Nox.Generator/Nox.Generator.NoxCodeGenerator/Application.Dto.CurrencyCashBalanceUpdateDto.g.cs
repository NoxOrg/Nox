// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The cash balance in Store.
/// </summary>
public partial class CurrencyCashBalanceUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// The Operation Limit (Optional).
    /// </summary>
    public System.Decimal? OperationLimit { get; set; }
}