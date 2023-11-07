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
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderUpdateDto : IEntityDto<DomainNamespace.CashStockOrder>
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
    [Required(ErrorMessage = "VendingMachine is required")]
    public System.Guid VendingMachineId { get; set; } = default!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    [Required(ErrorMessage = "Employee is required")]
    public System.Int64 EmployeeId { get; set; } = default!;
}