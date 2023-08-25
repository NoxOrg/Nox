// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class Customer : AuditableEntityBase
{
    /// <summary>
    /// The Customer unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The customer's first name (Required).
    /// </summary>
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// The customer's last name (Required).
    /// </summary>
    public Nox.Types.Text LastName { get; set; } = null!;

    /// <summary>
    /// The customer's email (Required).
    /// </summary>
    public Nox.Types.Email Email { get; set; } = null!;

    /// <summary>
    /// The customer's address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// The customer's mobile number (Optional).
    /// </summary>
    public Nox.Types.PhoneNumber? MobileNumber { get; set; } = null!;
}