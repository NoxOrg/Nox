// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace IamApi.Domain;

/// <summary>
/// User Role.
/// </summary>
public partial class Role : AuditableEntityBase
{
    /// <summary>
    /// Role identifier (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// Role Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Role Role belongs to many users ZeroOrMany UserIams
    /// </summary>
    public virtual List<UserIam> UserIams { get; set; } = new();

    public List<UserIam> UsersWith => UserIams;
}