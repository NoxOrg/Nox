// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using Cryptocash.Application.DataTransferObjects;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CustomerTransactionKeyDto(System.Int64 keyId);

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class CustomerTransactionDto
{

    /// <summary>
    /// Customer transaction unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Transaction type (Required).
    /// </summary>
    public System.String TransactionType { get; set; } = default!;

    /// <summary>
    /// Transaction processed datetime (Required).
    /// </summary>
    public System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;

    /// <summary>
    /// Transaction amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// Transaction external reference (Required).
    /// </summary>
    public System.String Reference { get; set; } = default!;

    /// <summary>
    /// CustomerTransaction Transaction's customer ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 CustomerId { get; set; } = default!;
    public virtual CustomerDto Customer { get; set; } = null!;

    /// <summary>
    /// CustomerTransaction Transaction's booking ExactlyOne Bookings
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid BookingId { get; set; } = default!;
    public virtual BookingDto Booking { get; set; } = null!;

    public System.DateTime? DeletedAtUtc { get; set; }
}