// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingCreateDto : BookingCreateDtoBase
{

}

/// <summary>
/// Exchange booking and related data.
/// </summary>
public abstract class BookingCreateDtoBase 
{/// <summary>
    /// Booking unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Guid? Id { get; set; }
    /// <summary>
    /// Booking's amount exchanged from     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "AmountFrom is required")]
    
    public virtual MoneyDto? AmountFrom { get; set; }
    /// <summary>
    /// Booking's amount exchanged to     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "AmountTo is required")]
    
    public virtual MoneyDto? AmountTo { get; set; }
    /// <summary>
    /// Booking's requested pick up date     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "RequestedPickUpDate is required")]
    
    public virtual DateTimeRangeDto? RequestedPickUpDate { get; set; }
    /// <summary>
    /// Booking's actual pick up date     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual DateTimeRangeDto? PickedUpDateTime { get; set; }
    /// <summary>
    /// Booking's expiry date     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.DateTimeOffset? ExpiryDateTime { get; set; }
    /// <summary>
    /// Booking's cancelled date     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.DateTimeOffset? CancelledDateTime { get; set; }
    /// <summary>
    /// Booking's related vat number     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    public System.Guid? CustomerId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CustomerCreateDto? Customer { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    public System.Guid? VendingMachineId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual VendingMachineCreateDto? VendingMachine { get; set; } = default!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    public System.Guid? CommissionId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CommissionCreateDto? Commission { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public System.Guid? TransactionId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual TransactionCreateDto? Transaction { get; set; } = default!;
}