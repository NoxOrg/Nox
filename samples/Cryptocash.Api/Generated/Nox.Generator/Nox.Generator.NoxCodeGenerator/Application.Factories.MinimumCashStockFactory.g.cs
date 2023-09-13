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

public abstract class MinimumCashStockFactoryBase: IEntityFactory<MinimumCashStock,MinimumCashStockCreateDto>
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
    private Cryptocash.Domain.MinimumCashStock ToEntity(MinimumCashStockCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.MinimumCashStock();
        entity.Amount = Cryptocash.Domain.MinimumCashStock.CreateAmount(createDto.Amount);
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        //entity.Currency = Currency.ToEntity();
        return entity;
    }
}

public partial class MinimumCashStockFactory : MinimumCashStockFactoryBase
{
}