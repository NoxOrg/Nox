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
    public virtual string VendingMachineId { get; set; } = null!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    /// <summary>
    /// VendingMachineOrder Order payment provider ExactlyOne PaymentProviders
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string PaymentProviderId { get; set; } = null!;
    public virtual PaymentProviderDto PaymentProvider { get; set; } = null!;

    /// <summary>
    /// VendingMachineOrder Order employee ExactlyOne Employees
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string EmployeeId { get; set; } = null!;
    public virtual EmployeeDto Employee { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}