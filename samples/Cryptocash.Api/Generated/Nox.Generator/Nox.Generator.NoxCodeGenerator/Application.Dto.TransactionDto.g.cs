// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record TransactionKeyDto(System.Int64 keyId);

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionDto
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
    /// Transaction for ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 TransactionForCustomerId { get; set; } = default!;
    public virtual CustomerDto TransactionForCustomer { get; set; } = null!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid TransactionForBookingId { get; set; } = default!;
    public virtual BookingDto TransactionForBooking { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }
}