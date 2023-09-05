// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderCreateDto : CashStockOrderUpdateDto
{

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