// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace IamApi.Domain;

/// <summary>
/// Verified Email Address.
/// </summary>
public partial class EmailAddress:IOwnedEntity
{
    /// <summary>
    /// Email (Required).
    /// </summary>
    public Email Email { get; set; } = null!;

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public Nox.Types.Boolean? IsVerified { get; set; } = null!;
}