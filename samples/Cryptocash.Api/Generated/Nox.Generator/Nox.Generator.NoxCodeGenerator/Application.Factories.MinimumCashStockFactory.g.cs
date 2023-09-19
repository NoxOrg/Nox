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
using MinimumCashStock = Cryptocash.Domain.MinimumCashStock;

namespace Cryptocash.Application.Factories;

public abstract class MinimumCashStockFactoryBase : IEntityFactory<MinimumCashStock, MinimumCashStockCreateDto, MinimumCashStockUpdateDto>
{

    public MinimumCashStockFactoryBase
    (
        )
    {
    }

    public virtual MinimumCashStock CreateEntity(MinimumCashStockCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public void UpdateEntity(MinimumCashStock entity, MinimumCashStockUpdateDto updateDto)
    {
        MapEntity(entity, updateDto);
    }

    private Cryptocash.Domain.MinimumCashStock ToEntity(MinimumCashStockCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.MinimumCashStock();
        entity.Amount = Cryptocash.Domain.MinimumCashStock.CreateAmount(createDto.Amount);
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        //entity.Currency = Currency.ToEntity();
        return entity;
    }

    private void MapEntity(MinimumCashStock entity, MinimumCashStockUpdateDto updateDto)
    {
        // TODO: discuss about keys
        entity.Amount = Cryptocash.Domain.MinimumCashStock.CreateAmount(updateDto.Amount);

        // TODO: discuss about keys
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        //entity.Currency = Currency.ToEntity();
    }
}

public partial class MinimumCashStockFactory : MinimumCashStockFactoryBase
{
}