// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProvider : AuditableEntityBase
{
    /// <summary>
    /// Payment provider unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Payment provider name (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderName { get; set; } = null!;

    /// <summary>
    /// Payment provider account type (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderType { get; set; } = null!;

    /// <summary>
    /// PaymentProvider Payment provider ExactlyOne CustomerPaymentDetails
    /// </summary>
    public virtual CustomerPaymentDetails CustomerPaymentDetails { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity CustomerPaymentDetails
    /// </summary>
    public Nox.Types.DatabaseNumber CustomerPaymentDetailsId { get; set; } = null!;
}