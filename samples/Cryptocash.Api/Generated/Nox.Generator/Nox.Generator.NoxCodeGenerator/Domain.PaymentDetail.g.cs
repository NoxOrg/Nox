// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class PaymentDetail:PaymentDetailBase
{

}
/// <summary>
/// Record for PaymentDetail created event.
/// </summary>
public record PaymentDetailCreated(PaymentDetail PaymentDetail) : IDomainEvent;
/// <summary>
/// Record for PaymentDetail updated event.
/// </summary>
public record PaymentDetailUpdated(PaymentDetail PaymentDetail) : IDomainEvent;
/// <summary>
/// Record for PaymentDetail deleted event.
/// </summary>
public record PaymentDetailDeleted(PaymentDetail PaymentDetail) : IDomainEvent;

/// <summary>
/// Customer payment account related data.
/// </summary>
public abstract class PaymentDetailBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Customer payment account unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Payment account name (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountName { get; set; } = null!;

    /// <summary>
    /// Payment account reference number (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountNumber { get; set; } = null!;

    /// <summary>
    /// Payment account sort code (Optional).
    /// </summary>
    public Nox.Types.Text? PaymentAccountSortCode { get; set; } = null!;

    /// <summary>
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    public virtual Customer PaymentDetailsUsedByCustomer { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.AutoNumber PaymentDetailsUsedByCustomerId { get; set; } = null!;

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    public virtual PaymentProvider PaymentDetailsRelatedPaymentProvider { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity PaymentProvider
    /// </summary>
    public Nox.Types.AutoNumber PaymentDetailsRelatedPaymentProviderId { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}