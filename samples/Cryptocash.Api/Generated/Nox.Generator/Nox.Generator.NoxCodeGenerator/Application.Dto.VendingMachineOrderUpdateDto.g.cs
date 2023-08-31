// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Vending machine currency order and related data.
/// </summary>
public partial class VendingMachineOrderUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The order's amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// The order's requested delivery date (Optional).
    /// </summary>
    public System.DateTime? RequestedDeliveryDate { get; set; }
    /// <summary>
    /// The order's delivery date (Optional).
    /// </summary>
    public System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// VendingMachineOrder The order's related vending machine ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "VendingMachine is required")]
    public System.Guid VendingMachineId { get; set; } = default!;
}