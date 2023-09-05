// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CashStockOrderKeyDto(System.Int64 keyId);

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderDto
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
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    public virtual EmployeeDto Employee { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }    
}