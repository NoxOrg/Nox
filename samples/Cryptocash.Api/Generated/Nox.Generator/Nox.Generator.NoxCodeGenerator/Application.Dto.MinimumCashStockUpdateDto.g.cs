// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock Vending machine's minimum cash stock ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "VendingMachine is required")]
    public System.Guid VendingMachineId { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock Cash stock's currency ExactlyOne Currencies
    /// </summary>
    [Required(ErrorMessage = "Currency is required")]
    public System.String CurrencyId { get; set; } = default!;
}