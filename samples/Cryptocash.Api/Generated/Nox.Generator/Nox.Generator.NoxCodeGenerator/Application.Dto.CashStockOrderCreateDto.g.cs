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

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderCreateDto : IEntityCreateDto <CashStockOrder>
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
    /// Order status (Optional).
    /// </summary>
    public System.String? Status { get; set; }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "CashStockOrderForVendingMachine is required")]
    public System.Guid CashStockOrderForVendingMachineId { get; set; } = default!;

    public Cryptocash.Domain.CashStockOrder ToEntity()
    {
        var entity = new Cryptocash.Domain.CashStockOrder();
        entity.Amount = Cryptocash.Domain.CashStockOrder.CreateAmount(Amount);
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrder.CreateRequestedDeliveryDate(RequestedDeliveryDate);
        if (DeliveryDateTime is not null)entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrder.CreateDeliveryDateTime(DeliveryDateTime.NonNullValue<System.DateTimeOffset>());
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Employee = Employee.ToEntity();
        return entity;
    }
}