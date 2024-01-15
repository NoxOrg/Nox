// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderPartialUpdateDto : CashStockOrderPartialUpdateDtoBase
{

}

/// <summary>
/// Vending machine cash stock order and related data
/// </summary>
public partial class CashStockOrderPartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Order amount
    /// </summary>
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Order requested delivery date
    /// </summary>
    public virtual System.DateTime RequestedDeliveryDate { get; set; } = default!;
    /// <summary>
    /// Order delivery date
    /// </summary>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }
}