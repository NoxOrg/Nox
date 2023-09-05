// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class Customer : AuditableEntityBase
{
    /// <summary>
    /// Customer's unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Customer's first name (Required).
    /// </summary>
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// Customer's last name (Required).
    /// </summary>
    public Nox.Types.Text LastName { get; set; } = null!;

    /// <summary>
    /// Customer's email address (Required).
    /// </summary>
    public Nox.Types.Email EmailAddress { get; set; } = null!;

    /// <summary>
    /// Customer's street address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Customer's mobile number (Optional).
    /// </summary>
    public Nox.Types.PhoneNumber? MobileNumber { get; set; } = null!;

    /// <summary>
    /// Customer related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetail> PaymentDetails { get; set; } = new();

    public List<PaymentDetail> CustomerRelatedPaymentDetails => PaymentDetails;

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; set; } = new();

    public List<Booking> CustomerRelatedBookings => Bookings;

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<Transaction> Transactions { get; set; } = new();

    public List<Transaction> CustomerRelatedTransactions => Transactions;

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    public Country CustomerBaseCountry => Country;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;
}