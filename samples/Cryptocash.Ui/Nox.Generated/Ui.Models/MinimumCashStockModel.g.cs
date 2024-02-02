// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStockModel : MinimumCashStockModelBase
{

}

/// <summary>
/// Minimum cash stock required for vending machine
/// </summary>
public abstract class MinimumCashStockModelBase: EntityDtoBase
{

    /// <summary>
    /// Vending machine cash stock unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Cash stock amount     
    /// </summary>
    public virtual MoneyModel? Amount { get; set; }
}