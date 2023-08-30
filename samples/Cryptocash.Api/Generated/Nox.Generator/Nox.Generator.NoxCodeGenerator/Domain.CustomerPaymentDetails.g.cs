// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class CustomerPaymentDetails : AuditableEntityBase
{
    /// <summary>
    /// Customer payment account unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Payment account name (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountName { get; set; } = null!;

    /// <summary>
    /// Payment account type (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountType { get; set; } = null!;

    /// <summary>
    /// Payment account reference number (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountNumber { get; set; } = null!;

    /// <summary>
    /// Payment account sort code (Optional).
    /// </summary>
    public Nox.Types.Text? PaymentAccountSortCode { get; set; } = null!;

    /// <summary>
    /// CustomerPaymentDetails Customer's payment account ExactlyOne Customers
    /// </summary>
    public virtual Customer Customer { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.DatabaseNumber CustomerId { get; set; } = null!;
}