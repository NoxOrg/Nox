// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine currency order and related data.
/// </summary>
public partial class VendingMachineOrderUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
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
    /// VendingMachineOrder Vending machine's orders ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "VendingMachine is required")]
    public System.Guid VendingMachineId { get; set; } = default!;

    /// <summary>
    /// VendingMachineOrder Reviewed by employee ExactlyOne Employees
    /// </summary>
    [Required(ErrorMessage = "Employee is required")]
    public System.Int64 EmployeeId { get; set; } = default!;
}