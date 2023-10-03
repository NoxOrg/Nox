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

public partial class MinimumCashStockCreateDto : MinimumCashStockCreateDtoBase
{

}

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public abstract class MinimumCashStockCreateDtoBase : IEntityDto<MinimumCashStock>
{
    /// <summary>
    /// Cash stock amount (Required).
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// MinimumCashStock required by ZeroOrMany VendingMachines
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<VendingMachineCreateDto> MinimumCashStocksRequiredByVendingMachines { get; set; } = new();

    /// <summary>
    /// MinimumCashStock related to ExactlyOne Currencies
    /// </summary>
    public System.String? MinimumCashStockRelatedCurrencyId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual CurrencyCreateDto? MinimumCashStockRelatedCurrency { get; set; } = default!;
}