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
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockCreateDto : MinimumCashStockUpdateDto
{

    public MinimumCashStock ToEntity()
    {
        var entity = new MinimumCashStock();
        entity.Amount = MinimumCashStock.CreateAmount(Amount);
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Currency = Currency.ToEntity();
        return entity;
    }
}