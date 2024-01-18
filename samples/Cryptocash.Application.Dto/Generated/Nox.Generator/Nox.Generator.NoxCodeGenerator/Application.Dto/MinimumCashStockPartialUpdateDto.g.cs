// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockPartialUpdateDto : MinimumCashStockPartialUpdateDtoBase
{

}

/// <summary>
/// Minimum cash stock required for vending machine
/// </summary>
public partial class MinimumCashStockPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Cash stock amount
    /// </summary>
    public virtual MoneyDto Amount { get; set; } = default!;
}