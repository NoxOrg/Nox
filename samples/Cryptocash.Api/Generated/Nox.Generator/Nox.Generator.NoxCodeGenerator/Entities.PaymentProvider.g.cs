// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProvider : AuditableEntityBase
{
    /// <summary>
    /// The payment provider unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The payment provider name (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderName { get; set; } = null!;

    /// <summary>
    /// The payment account type (Required).
    /// </summary>
    public Nox.Types.Text PaymentProviderType { get; set; } = null!;
}