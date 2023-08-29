// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The amount of the cash stock (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock The related vending machine ExactlyOne VendingMachines
    /// </summary>
    public string VendingMachineId { get; set; } = null!;

    /// <summary>
    /// MinimumCashStock The currency of the cash stock ExactlyOne Currencies
    /// </summary>
    public string CurrencyId { get; set; } = null!;
}