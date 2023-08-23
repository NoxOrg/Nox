// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace IamApi.Domain;

/// <summary>
/// User.
/// </summary>
public partial class UserIam : AuditableEntityBase
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
}