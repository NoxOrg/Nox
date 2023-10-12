// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

using MinimumCashStockEntity = Cryptocash.Domain.MinimumCashStock;
namespace Cryptocash.Application.Dto;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockUpdateDto : IEntityDto<MinimumCashStockEntity>
{
    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    [Required(ErrorMessage = "MinimumCashStockRelatedCurrency is required")]
    public System.String MinimumCashStockRelatedCurrencyId { get; set; } = default!;
}