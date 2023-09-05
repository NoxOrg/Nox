// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Booking's amount exchanged from (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountFrom is required")]
    
    public MoneyDto AmountFrom { get; set; } = default!;
    /// <summary>
    /// Booking's amount exchanged to (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountTo is required")]
    
    public MoneyDto AmountTo { get; set; } = default!;
    /// <summary>
    /// Booking's requested pick up date (Required).
    /// </summary>
    [Required(ErrorMessage = "RequestedPickUpDate is required")]
    
    public DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;
    /// <summary>
    /// Booking's actual pick up date (Optional).
    /// </summary>
    public DateTimeRangeDto? PickedUpDateTime { get; set; }
    /// <summary>
    /// Booking's expiry date (Optional).
    /// </summary>
    public System.DateTimeOffset? ExpiryDateTime { get; set; }
    /// <summary>
    /// Booking's cancelled date (Optional).
    /// </summary>
    public System.DateTimeOffset? CancelledDateTime { get; set; }
    /// <summary>
    /// Booking's related vat number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "BookingForCustomer is required")]
    public System.Int64 BookingForCustomerId { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "BookingRelatedVendingMachine is required")]
    public System.Guid BookingRelatedVendingMachineId { get; set; } = default!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    [Required(ErrorMessage = "BookingFeesForCommission is required")]
    public System.Int64 BookingFeesForCommissionId { get; set; } = default!;
}