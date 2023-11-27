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
/// Patch entity CashStockOrder: Vending machine cash stock order and related data.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class CashStockOrderPatchDto: { { className} }
{

}

/// <summary>
/// Vending machine cash stock order and related data
/// </summary>
public partial class CashStockOrderUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CashStockOrder>
{
    /// <summary>
    /// Order amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto Amount { get; set; } = default!;
    /// <summary>
    /// Order requested delivery date     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "RequestedDeliveryDate is required")]
    
    public virtual System.DateTime RequestedDeliveryDate { get; set; } = default!;
    /// <summary>
    /// Order delivery date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }
}