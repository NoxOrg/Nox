// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class Customer:CustomerBase
{

}
/// <summary>
/// Record for Customer created event.
/// </summary>
public record CustomerCreated(Customer Customer) : IDomainEvent;
/// <summary>
/// Record for Customer updated event.
/// </summary>
public record CustomerUpdated(Customer Customer) : IDomainEvent;
/// <summary>
/// Record for Customer deleted event.
/// </summary>
public record CustomerDeleted(Customer Customer) : IDomainEvent;

/// <summary>
/// Customer definition and related data.
/// </summary>
public abstract class CustomerBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer's unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

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
    public virtual List<PaymentDetail> CustomerRelatedPaymentDetails { get; set; } = new();

    public virtual void CreateRefToCustomerRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        CustomerRelatedPaymentDetails.Add(relatedPaymentDetail);
    }

    /// <summary>
    /// Customer related to ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> CustomerRelatedBookings { get; set; } = new();

    public virtual void CreateRefToCustomerRelatedBookings(Booking relatedBooking)
    {
        CustomerRelatedBookings.Add(relatedBooking);
    }

    /// <summary>
    /// Customer related to ZeroOrMany Transactions
    /// </summary>
    public virtual List<Transaction> CustomerRelatedTransactions { get; set; } = new();

    public virtual void CreateRefToCustomerRelatedTransactions(Transaction relatedTransaction)
    {
        CustomerRelatedTransactions.Add(relatedTransaction);
    }

    /// <summary>
    /// Customer based in ExactlyOne Countries
    /// </summary>
    public virtual Country CustomerBaseCountry { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CustomerBaseCountryId { get; set; } = null!;

    public virtual void CreateRefToCustomerBaseCountry(Country relatedCountry)
    {
        CustomerBaseCountry = relatedCountry;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}