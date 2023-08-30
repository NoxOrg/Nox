// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
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
    //EF maps ForeignKey Automatically...
    public virtual string VendingMachineId { get; set; } = null!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public VendingMachineOrder ToEntity()
    {
        var entity = new VendingMachineOrder();
        entity.Id = VendingMachineOrder.CreateId(Id);
        entity.Amount = VendingMachineOrder.CreateAmount(Amount);
        if (RequestedDeliveryDate is not null)entity.RequestedDeliveryDate = VendingMachineOrder.CreateRequestedDeliveryDate(RequestedDeliveryDate.NonNullValue<System.DateTime>());
        if (DeliveryDateTime is not null)entity.DeliveryDateTime = VendingMachineOrder.CreateDeliveryDateTime(DeliveryDateTime.NonNullValue<System.DateTimeOffset>());
        entity.VendingMachine = VendingMachine.ToEntity();
        return entity;
    }

}