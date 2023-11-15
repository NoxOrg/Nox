// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

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
public partial class CashStockOrderUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CashStockOrder>
{
    /// <summary>
    /// Order amount 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Order requested delivery date 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "RequestedDeliveryDate is required")]
    
    public virtual System.DateTime RequestedDeliveryDate { get; set; } = default!;
    /// <summary>
    /// Order delivery date 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }
}