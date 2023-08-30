// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Employee phone numbers and related data.
/// </summary>
public partial class EmployeePhoneNumber:EntityBase, IOwnedEntity
{
    /// <summary>
    /// Employee's phone number identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    public Nox.Types.Text PhoneNumberType { get; set; } = null!;

    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    public Nox.Types.PhoneNumber PhoneNumber { get; set; } = null!;
}