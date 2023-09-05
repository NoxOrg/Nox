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
/// Vending machine currency order and related data.
/// </summary>
public partial class VendingMachineOrderCreateDto : VendingMachineOrderUpdateDto
{

    public VendingMachineOrder ToEntity()
    {
        var entity = new VendingMachineOrder();
        entity.Amount = VendingMachineOrder.CreateAmount(Amount);
        entity.RequestedDeliveryDate = VendingMachineOrder.CreateRequestedDeliveryDate(RequestedDeliveryDate);
        if (DeliveryDateTime is not null)entity.DeliveryDateTime = VendingMachineOrder.CreateDeliveryDateTime(DeliveryDateTime.NonNullValue<System.DateTimeOffset>());
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Employee = Employee.ToEntity();
        return entity;
    }
}