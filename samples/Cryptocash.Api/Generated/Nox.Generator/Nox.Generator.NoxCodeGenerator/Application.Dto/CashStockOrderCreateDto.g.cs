// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderCreateDto : CashStockOrderCreateDtoBase
{

}

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public abstract class CashStockOrderCreateDtoBase : IEntityDto<DomainNamespace.CashStockOrder>
{
    /// <summary>
    /// Order amount     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto? Amount { get; set; }
    /// <summary>
    /// Order requested delivery date     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "RequestedDeliveryDate is required")]
    
    public virtual System.DateTime? RequestedDeliveryDate { get; set; }
    /// <summary>
    /// Order delivery date     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    public System.Guid? VendingMachineId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual VendingMachineCreateDto? VendingMachine { get; set; } = default!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    public System.Guid? EmployeeId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual EmployeeCreateDto? Employee { get; set; } = default!;
}