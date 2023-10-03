// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class BookingCreateDto : BookingCreateDtoBase
{

}

/// <summary>
/// Exchange booking and related data.
/// </summary>
public abstract class BookingCreateDtoBase : IEntityDto<Booking>
{/// <summary>
    /// Booking unique identifier (Optional).
    /// </summary>
    public System.Guid Id { get; set; } = default!;
    /// <summary>
    /// Booking's amount exchanged from (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountFrom is required")]
    
    public virtual MoneyDto AmountFrom { get; set; } = default!;
    /// <summary>
    /// Booking's amount exchanged to (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountTo is required")]
    
    public virtual MoneyDto AmountTo { get; set; } = default!;
    /// <summary>
    /// Booking's requested pick up date (Required).
    /// </summary>
    [Required(ErrorMessage = "RequestedPickUpDate is required")]
    
    public virtual DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;
    /// <summary>
    /// Booking's actual pick up date (Optional).
    /// </summary>
    public virtual DateTimeRangeDto? PickedUpDateTime { get; set; }
    /// <summary>
    /// Booking's expiry date (Optional).
    /// </summary>
    public virtual System.DateTimeOffset? ExpiryDateTime { get; set; }
    /// <summary>
    /// Booking's cancelled date (Optional).
    /// </summary>
    public virtual System.DateTimeOffset? CancelledDateTime { get; set; }
    /// <summary>
    /// Booking's status (Optional).
    /// </summary>
    public virtual System.String? Status { get; set; }
    /// <summary>
    /// Booking's related vat number (Optional).
    /// </summary>
    public virtual VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    public System.Int64? BookingForCustomerId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual CustomerCreateDto? BookingForCustomer { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    public System.Guid? BookingRelatedVendingMachineId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual VendingMachineCreateDto? BookingRelatedVendingMachine { get; set; } = default!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    public System.Int64? BookingFeesForCommissionId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual CommissionCreateDto? BookingFeesForCommission { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public System.Int64? BookingRelatedTransactionId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual TransactionCreateDto? BookingRelatedTransaction { get; set; } = default!;
}