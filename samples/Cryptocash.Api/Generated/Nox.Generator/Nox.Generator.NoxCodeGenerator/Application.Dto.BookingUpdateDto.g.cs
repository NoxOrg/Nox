// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The booking's amount exchanged from (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountFrom is required")]
    
    public MoneyDto AmountFrom { get; set; } = default!;
    /// <summary>
    /// The booking's amount exchanged to (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountTo is required")]
    
    public MoneyDto AmountTo { get; set; } = default!;
    /// <summary>
    /// The booking's requested pick up date (Required).
    /// </summary>
    [Required(ErrorMessage = "RequestedPickUpDate is required")]
    
    public DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;
    /// <summary>
    /// The booking's actual pick up date (Optional).
    /// </summary>
    public DateTimeRangeDto? PickedUpDateTime { get; set; }
    /// <summary>
    /// The booking's expiry date (Required).
    /// </summary>
    [Required(ErrorMessage = "ExpiryDateTime is required")]
    
    public System.DateTimeOffset ExpiryDateTime { get; set; } = default!;
    /// <summary>
    /// The booking's cancelled date (Optional).
    /// </summary>
    public System.DateTimeOffset? CancelledDateTime { get; set; }
    /// <summary>
    /// The booking's related vat number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking The booking's related customer ExactlyOne Customers
    /// </summary>
    public string CustomerId { get; set; } = null!;

    /// <summary>
    /// Booking The booking's related vending machine ExactlyOne VendingMachines
    /// </summary>
    public string VendingMachineId { get; set; } = null!;

    /// <summary>
    /// Booking The booking's related fee ExactlyOne Commissions
    /// </summary>
    public string CommissionId { get; set; } = null!;
}