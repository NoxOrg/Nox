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
    /// Customer Customer's payment details ZeroOrMany CustomerPaymentDetails
    /// </summary>
    public virtual List<CustomerPaymentDetails> CustomerPaymentDetails { get; set; } = new();

    /// <summary>
    /// Customer Customer's booking ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; set; } = new();

    public List<Booking> Booking => Bookings;

    /// <summary>
    /// Customer Customer's transaction ZeroOrMany CustomerTransactions
    /// </summary>
    public virtual List<CustomerTransaction> CustomerTransactions { get; set; } = new();

    public List<CustomerTransaction> CustomerTransaction => CustomerTransactions;

    /// <summary>
    /// Customer Customer's country ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;
}