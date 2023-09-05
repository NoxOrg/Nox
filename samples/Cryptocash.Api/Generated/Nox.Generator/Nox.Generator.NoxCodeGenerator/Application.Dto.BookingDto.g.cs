// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record BookingKeyDto(System.Guid keyId);

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingDto
{

    /// <summary>
    /// Booking unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Booking's amount exchanged from (Required).
    /// </summary>
    public MoneyDto AmountFrom { get; set; } = default!;

    /// <summary>
    /// Booking's amount exchanged to (Required).
    /// </summary>
    public MoneyDto AmountTo { get; set; } = default!;

    /// <summary>
    /// Booking's requested pick up date (Required).
    /// </summary>
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
    /// Booking's status (Optional).
    /// </summary>
    public System.String? Status { get; set; }

    /// <summary>
    /// Booking's related vat number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 CustomerId { get; set; } = default!;
    public virtual CustomerDto Customer { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 CommissionId { get; set; } = default!;
    public virtual CommissionDto Commission { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public virtual TransactionDto Transaction { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }    
}