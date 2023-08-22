// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class Employee : AuditableEntityBase
{
    /// <summary>
    /// The employee unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The employee's first name (Required).
    /// </summary>
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// The employee's last name (Required).
    /// </summary>
    public Nox.Types.Text LastName { get; set; } = null!;

    /// <summary>
    /// The employee's email (Required).
    /// </summary>
    public Nox.Types.Email Email { get; set; } = null!;

    /// <summary>
    /// The employee's address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// The employee's first working day (Required).
    /// </summary>
    public Nox.Types.Date FirstWorkingDay { get; set; } = null!;

    /// <summary>
    /// The employee's last working day (Optional).
    /// </summary>
    public Nox.Types.Date? LastWorkingDay { get; set; } = null!;
}