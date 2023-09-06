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

public record CustomerKeyDto(System.Int64 keyId);

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerDto
{

    /// <summary>
    /// Customer's unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Customer's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// Customer's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Customer's email address (Required).
    /// </summary>
    public System.String EmailAddress { get; set; } = default!;

    /// <summary>
    /// Customer's street address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Customer's mobile number (Optional).
    /// </summary>
    public System.String? MobileNumber { get; set; }

    /// <summary>
    /// Customer related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetailDto> CustomerRelatedPaymentDetails { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> CustomerRelatedBookings { get; set; } = new();

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<TransactionDto> CustomerRelatedTransactions { get; set; } = new();

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String CustomerBaseCountryId { get; set; } = default!;
    public virtual CountryDto CustomerBaseCountry { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }    
}