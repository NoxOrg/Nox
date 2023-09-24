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

    public virtual void UpdateEntity(MinimumCashStock entity, MinimumCashStockUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(MinimumCashStock entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.MinimumCashStock ToEntity(MinimumCashStockCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.MinimumCashStock();
        entity.Amount = Cryptocash.Domain.MinimumCashStock.CreateAmount(createDto.Amount);
        return entity;
    }

    private void UpdateEntityInternal(MinimumCashStock entity, MinimumCashStockUpdateDto updateDto)
    {
        entity.Amount = Cryptocash.Domain.MinimumCashStock.CreateAmount(updateDto.Amount.NonNullValue<MoneyDto>());
    }

    private void PartialUpdateEntityInternal(MinimumCashStock entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("Amount", out var AmountUpdateValue))
        {
            if (AmountUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Amount' can't be null");
            }
            {
                entity.Amount = Cryptocash.Domain.MinimumCashStock.CreateAmount(AmountUpdateValue);
            }
        }
    }
}

public partial class MinimumCashStockFactory : MinimumCashStockFactoryBase
{
}