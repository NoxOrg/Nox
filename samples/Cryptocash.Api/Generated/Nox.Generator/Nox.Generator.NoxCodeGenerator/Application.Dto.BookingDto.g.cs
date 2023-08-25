// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record BookingKeyDto(System.Guid keyId);

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingDto
{

    /// <summary>
    /// The booking unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// The booking's amount exchanged from (Required).
    /// </summary>
    public MoneyDto AmountFrom { get; set; } = default!;

    /// <summary>
    /// The booking's amount exchanged to (Required).
    /// </summary>
    public MoneyDto AmountTo { get; set; } = default!;

    /// <summary>
    /// The booking's requested pick up date (Required).
    /// </summary>
    public DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;

    /// <summary>
    /// The booking's actual pick up date (Optional).
    /// </summary>
    public DateTimeRangeDto? PickedUpDateTime { get; set; }

    /// <summary>
    /// The booking's expiry date (Required).
    /// </summary>
    public System.DateTimeOffset ExpiryDateTime { get; set; } = default!;

    /// <summary>
    /// The booking's cancelled date (Optional).
    /// </summary>
    public System.DateTimeOffset? CancelledDateTime { get; set; }

    /// <summary>
    /// The booking's status (Required).
    /// </summary>
    public System.String Status { get; set; } = default!;

    /// <summary>
    /// The booking's related vat number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking The booking's related customer ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CustomerId { get; set; } = null!;
    public virtual CustomerDto Customer { get; set; } = null!;

    /// <summary>
    /// Booking The booking's related vending machine ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string VendingMachineId { get; set; } = null!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    /// <summary>
    /// Booking The booking's related fee ExactlyOne Commissions
    /// </summary>
    //EF maps ForeignKey Automatically
    public virtual string CommissionId { get; set; } = null!;
    public virtual CommissionDto Commission { get; set; } = null!;

    /// <summary>
    /// Booking The transaction's related booking OneOrMany CustomerTransactions
    /// </summary>
    public virtual List<CustomerTransactionDto> CustomerTransactions { get; set; } = new();

    public System.DateTime? DeletedAtUtc { get; set; }
}