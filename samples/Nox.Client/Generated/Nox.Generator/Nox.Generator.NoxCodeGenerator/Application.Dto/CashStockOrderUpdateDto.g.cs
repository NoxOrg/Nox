// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

using CashStockOrderEntity = Cryptocash.Domain.CashStockOrder;
namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderUpdateDto : IEntityDto<CashStockOrderEntity>
{
    /// <summary>
    /// Order amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Order requested delivery date (Required).
    /// </summary>
    [Required(ErrorMessage = "RequestedDeliveryDate is required")]
    
    public System.DateTime RequestedDeliveryDate { get; set; } = default!;
    /// <summary>
    /// Order delivery date (Optional).
    /// </summary>
    public System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "CashStockOrderForVendingMachine is required")]
    public System.Guid CashStockOrderForVendingMachineId { get; set; } = default!;
}