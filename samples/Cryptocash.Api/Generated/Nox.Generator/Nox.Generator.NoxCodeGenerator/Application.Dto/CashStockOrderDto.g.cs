// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CashStockOrderKeyDto(System.Int64 keyId);

public partial class CashStockOrderDto : CashStockOrderDtoBase
{

}

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public abstract class CashStockOrderDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.CashStockOrder>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Amount is not null)
            ExecuteActionAndCollectValidationExceptions("Amount", () => DomainNamespace.CashStockOrderMetadata.CreateAmount(this.Amount.NonNullValue<MoneyDto>()), result);
        else
            result.Add("Amount", new [] { "Amount is Required." });
    
        ExecuteActionAndCollectValidationExceptions("RequestedDeliveryDate", () => DomainNamespace.CashStockOrderMetadata.CreateRequestedDeliveryDate(this.RequestedDeliveryDate), result);
    
        if (this.DeliveryDateTime is not null)
            ExecuteActionAndCollectValidationExceptions("DeliveryDateTime", () => DomainNamespace.CashStockOrderMetadata.CreateDeliveryDateTime(this.DeliveryDateTime.NonNullValue<System.DateTimeOffset>()), result); 

        return result;
    }
    #endregion

    /// <summary>
    /// Vending machine's order unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Order amount 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// Order requested delivery date 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.DateTime RequestedDeliveryDate { get; set; } = default!;

    /// <summary>
    /// Order delivery date 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// Order status 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public System.String? Status { get; set; }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto? VendingMachine { get; set; } = null!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    public virtual EmployeeDto? Employee { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}