// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class CashStockOrderCreateDto : CashStockOrderCreateDtoBase
{

}

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public abstract class CashStockOrderCreateDtoBase : IEntityDto<CashStockOrder>
{
    /// <summary>
    /// Order amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Order requested delivery date (Required).
    /// </summary>
    [Required(ErrorMessage = "RequestedDeliveryDate is required")]
    
    public virtual System.DateTime RequestedDeliveryDate { get; set; } = default!;
    /// <summary>
    /// Order delivery date (Optional).
    /// </summary>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }
    /// <summary>
    /// Order status (Optional).
    /// </summary>
    public virtual System.String? Status { get; set; }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    public System.Guid? CashStockOrderForVendingMachineId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual VendingMachineCreateDto? CashStockOrderForVendingMachine { get; set; } = default!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    public System.Int64? CashStockOrderReviewedByEmployeeId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual EmployeeCreateDto? CashStockOrderReviewedByEmployee { get; set; } = default!;
}