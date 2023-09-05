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

    public Cryptocash.Domain.MinimumCashStock ToEntity()
    {
        var entity = new Cryptocash.Domain.MinimumCashStock();
        entity.Amount = Cryptocash.Domain.MinimumCashStock.CreateAmount(Amount);
        //entity.VendingMachines = VendingMachines.Select(dto => dto.ToEntity()).ToList();
        //entity.Currency = Currency.ToEntity();
        return entity;
    }
}