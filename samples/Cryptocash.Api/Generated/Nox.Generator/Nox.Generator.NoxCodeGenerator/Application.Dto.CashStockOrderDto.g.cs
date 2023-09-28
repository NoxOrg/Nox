// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CashStockOrderKeyDto(System.Int64 keyId);

public partial class CashStockOrderDto : CashStockOrderDtoBase
{

}

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public abstract class CashStockOrderDtoBase : EntityDtoBase, IEntityDto<CashStockOrder>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Amount is not null)
            TryGetValidationExceptions("Amount", () => Cryptocash.Domain.CashStockOrderMetadata.CreateAmount(this.Amount.NonNullValue<MoneyDto>()), result);
        else
            result.Add("Amount", new [] { "Amount is Required." });
    
        TryGetValidationExceptions("RequestedDeliveryDate", () => Cryptocash.Domain.CashStockOrderMetadata.CreateRequestedDeliveryDate(this.RequestedDeliveryDate), result);
    
        if (this.DeliveryDateTime is not null)
            TryGetValidationExceptions("DeliveryDateTime", () => Cryptocash.Domain.CashStockOrderMetadata.CreateDeliveryDateTime(this.DeliveryDateTime.NonNullValue<System.DateTimeOffset>()), result); 

        return result;
    }
    #endregion

    /// <summary>
    /// Vending machine's order unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Order amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// Order requested delivery date (Required).
    /// </summary>
    public System.DateTime RequestedDeliveryDate { get; set; } = default!;

    /// <summary>
    /// Order delivery date (Optional).
    /// </summary>
    public System.DateTimeOffset? DeliveryDateTime { get; set; }

    /// <summary>
    /// Order status (Optional).
    /// </summary>
    public System.String? Status { get; set; }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? CashStockOrderForVendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto? CashStockOrderForVendingMachine { get; set; } = null!;

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    public virtual EmployeeDto? CashStockOrderReviewedByEmployee { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}