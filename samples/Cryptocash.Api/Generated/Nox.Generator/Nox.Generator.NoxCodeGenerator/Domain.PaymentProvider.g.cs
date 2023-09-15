// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class PaymentProvider:PaymentProviderBase
{

}
/// <summary>
/// Record for PaymentProvider created event.
/// </summary>
public record PaymentProviderCreated(PaymentProvider PaymentProvider) : IDomainEvent;
/// <summary>
/// Record for PaymentProvider updated event.
/// </summary>
public record PaymentProviderUpdated(PaymentProvider PaymentProvider) : IDomainEvent;
/// <summary>
/// Record for PaymentProvider deleted event.
/// </summary>
public record PaymentProviderDeleted(PaymentProvider PaymentProvider) : IDomainEvent;

/// <summary>
/// Payment provider related data.
/// </summary>
public abstract class PaymentProviderBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Payment provider unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Payment provider name (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderName { get; set; } = null!;

    /// <summary>
    /// Payment provider account type (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderType { get; set; } = null!;

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetail> PaymentProviderRelatedPaymentDetails { get; set; } = new();

    public virtual void CreateRefToPaymentDetailPaymentProviderRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        PaymentProviderRelatedPaymentDetails.Add(relatedPaymentDetail);
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}