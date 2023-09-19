// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application.Factories;

public abstract class CashStockOrderFactoryBase : IEntityFactory<CashStockOrder, CashStockOrderCreateDto, CashStockOrderUpdateDto>
{

    public CashStockOrderFactoryBase
    (
        )
    {
    }

    public virtual CashStockOrder CreateEntity(CashStockOrderCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public void UpdateEntity(CashStockOrder entity, CashStockOrderUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private Cryptocash.Domain.CashStockOrder ToEntity(CashStockOrderCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.CashStockOrder();
        entity.Amount = Cryptocash.Domain.CashStockOrder.CreateAmount(createDto.Amount);
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrder.CreateRequestedDeliveryDate(createDto.RequestedDeliveryDate);
        if (createDto.DeliveryDateTime is not null)entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrder.CreateDeliveryDateTime(createDto.DeliveryDateTime.NonNullValue<System.DateTimeOffset>());
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Employee = Employee.ToEntity();
        return entity;
    }

    private void MapEntity(CashStockOrder entity, CashStockOrderUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.Amount = Cryptocash.Domain.CashStockOrder.CreateAmount(updateDto.Amount);
        entity.RequestedDeliveryDate = Cryptocash.Domain.CashStockOrder.CreateRequestedDeliveryDate(updateDto.RequestedDeliveryDate);
        if (updateDto.DeliveryDateTime is not null)entity.DeliveryDateTime = Cryptocash.Domain.CashStockOrder.CreateDeliveryDateTime(updateDto.DeliveryDateTime.NonNullValue<System.DateTimeOffset>());

        // TODO: discuss about keys
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Employee = Employee.ToEntity();
    }
}

public partial class CashStockOrderFactory : CashStockOrderFactoryBase
{
}