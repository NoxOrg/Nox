// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record VendingMachineOrderKeyDto(System.Int64 keyId);

/// <summary>
/// Vending machine currency order and related data.
/// </summary>
public partial class VendingMachineOrderDto
{

    /// <summary>
    /// The vending machine's order unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The order's amount (Required).
    /// </summary>
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
    //EF maps ForeignKey Automatically
    public System.Guid VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}