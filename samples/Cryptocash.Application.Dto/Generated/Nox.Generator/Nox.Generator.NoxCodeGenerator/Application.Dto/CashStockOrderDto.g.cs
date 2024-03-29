﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record CashStockOrderKeyDto(System.Int64 keyId);

/// <summary>
/// Update CashStockOrder
/// Vending machine cash stock order and related data.
/// </summary>
public partial class CashStockOrderDto : CashStockOrderDtoBase
{

}

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public abstract class CashStockOrderDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Amount is not null)
            CollectValidationExceptions("Amount", () => CashStockOrderMetadata.CreateAmount(this.Amount.NonNullValue<MoneyDto>()), result);
        else
            result.Add("Amount", new [] { "Amount is Required." });
    
        CollectValidationExceptions("RequestedDeliveryDate", () => CashStockOrderMetadata.CreateRequestedDeliveryDate(this.RequestedDeliveryDate), result);
    
        if (this.DeliveryDateTime is not null)
            CollectValidationExceptions("DeliveryDateTime", () => CashStockOrderMetadata.CreateDeliveryDateTime(this.DeliveryDateTime.NonNullValue<System.DateTimeOffset>()), result); 

        return result;
    }
    #endregion

    /// <summary>
    /// Vending machine's order unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Order amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// Order requested delivery date     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.DateTime RequestedDeliveryDate { get; set; } = default!;

    /// <summary>
    /// Order delivery date     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// Order status     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public string? Status { get; set; }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto? VendingMachine { get; set; } = null!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? EmployeeId { get; set; } = default!;
    public virtual EmployeeDto? Employee { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}