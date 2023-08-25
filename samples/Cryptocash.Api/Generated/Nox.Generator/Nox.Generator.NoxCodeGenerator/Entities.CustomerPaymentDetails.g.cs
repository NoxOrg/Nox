// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class CustomerPaymentDetails : AuditableEntityBase
{
    /// <summary>
    /// The customer payment account unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The payment account name (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountName { get; set; } = null!;

    /// <summary>
    /// The payment account type (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountType { get; set; } = null!;

    /// <summary>
    /// The payment account reference number (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountNumber { get; set; } = null!;

    /// <summary>
    /// The payment account sort code (Required).
    /// </summary>
    public Nox.Types.Text PaymentAccountSortCode { get; set; } = null!;

    /// <summary>
    /// CustomerPaymentDetails The payment account related customer ExactlyOne Customers
    /// </summary>
    public virtual Customer Customer { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Customer
    /// </summary>
    public Nox.Types.DatabaseNumber CustomerId { get; set; } = null!;
}