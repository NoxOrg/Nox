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

public partial class MinimumCashStockCreateDto: MinimumCashStockCreateDtoBase
{

}

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public abstract class MinimumCashStockCreateDtoBase : IEntityCreateDto<MinimumCashStock>
{    
    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    [Required(ErrorMessage = "MinimumCashStockRelatedCurrency is required")]
    public System.String MinimumCashStockRelatedCurrencyId { get; set; } = default!;
}