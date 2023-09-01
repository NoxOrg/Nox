// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using Cryptocash.Application.DataTransferObjects;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record VendingMachineOrderKeyDto(System.Int64 keyId);

/// <summary>
/// Vending machine currency order and related data.
/// </summary>
public partial class VendingMachineOrderDto
{

    /// <summary>
    /// Vending machine's order unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Order amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// Order requested delivery date (Required).
    /// </summary>
    public System.DateTime RequestedDeliveryDate { get; set; } = default!;

    /// <summary>
    /// Order delivery date (Optional).
    /// </summary>
    public System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// Order status (Optional).
    /// </summary>
    public System.String? Status { get; set; }

    /// <summary>
    /// VendingMachineOrder Vending machine's orders ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    /// <summary>
    /// VendingMachineOrder Reviewed by employee ExactlyOne Employees
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 EmployeeId { get; set; } = default!;
    public virtual EmployeeDto Employee { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}