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
public partial class CashStockOrderUpdateDto : CashStockOrderUpdateDtoBase
{

}

/// <summary>
/// Vending machine cash stock order and related data
/// </summary>
public partial class CashStockOrderUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Order amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto? Amount { get; set; }
    /// <summary>
    /// Order requested delivery date     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "RequestedDeliveryDate is required")]
    
    public virtual System.DateTime? RequestedDeliveryDate { get; set; }
    /// <summary>
    /// Order delivery date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }
}