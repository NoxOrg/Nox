// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;
public partial class EmailAddress:EmailAddressBase
{

}
/// <summary>
/// Verified Email Address.
/// </summary>
public abstract class EmailAddressBase : EntityBase, IOwnedEntity
{

    /// <summary>
    /// Email (Optional).
    /// </summary>
    public Nox.Types.Email? Email { get; set; } = null!;

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public Nox.Types.Boolean? IsVerified { get; set; } = null!;

}