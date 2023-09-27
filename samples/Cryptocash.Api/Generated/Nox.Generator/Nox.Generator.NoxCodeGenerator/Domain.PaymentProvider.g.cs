// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class PaymentProvider:PaymentProviderBase
{

}
/// <summary>
/// Record for PaymentProvider created event.
/// </summary>
internal record PaymentProviderCreated(PaymentProvider PaymentProvider) : IDomainEvent;
/// <summary>
/// Record for PaymentProvider updated event.
/// </summary>
internal record PaymentProviderUpdated(PaymentProvider PaymentProvider) : IDomainEvent;
/// <summary>
/// Record for PaymentProvider deleted event.
/// </summary>
internal record PaymentProviderDeleted(PaymentProvider PaymentProvider) : IDomainEvent;

/// <summary>
/// Payment provider related data.
/// </summary>
internal abstract class PaymentProviderBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Payment provider unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

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
    public virtual List<PaymentDetail> PaymentProviderRelatedPaymentDetails { get; private set; } = new();

    public virtual void CreateRefToPaymentProviderRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        PaymentProviderRelatedPaymentDetails.Add(relatedPaymentDetail);
    }

    public virtual void DeleteRefToPaymentProviderRelatedPaymentDetails(PaymentDetail relatedPaymentDetail)
    {
        PaymentProviderRelatedPaymentDetails.Remove(relatedPaymentDetail);
    }

    public virtual void DeleteAllRefToPaymentProviderRelatedPaymentDetails()
    {
        PaymentProviderRelatedPaymentDetails.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}