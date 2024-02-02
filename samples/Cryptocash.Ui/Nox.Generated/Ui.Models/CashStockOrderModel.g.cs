// Generated

#nullable enable
using Nox.Application.Dto;
using Nox.Ui.Blazor.Lib.Models;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderModel : CashStockOrderModelBase
{

}

/// <summary>
/// Vending machine cash stock order and related data
/// </summary>
public abstract class CashStockOrderModelBase: EntityDtoBase
{

    /// <summary>
    /// Vending machine's order unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Order amount     
    /// </summary>
    public virtual MoneyModel? Amount { get; set; }

    /// <summary>
    /// Order requested delivery date     
    /// </summary>
    public virtual System.DateTime? RequestedDeliveryDate { get; set; }

    /// <summary>
    /// Order delivery date     
    /// </summary>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }
    
}