// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class EmailAddress:EmailAddressBase
{

}
/// <summary>
/// Record for EmailAddress created event.
/// </summary>
internal record EmailAddressCreated(EmailAddress EmailAddress) : IDomainEvent;
/// <summary>
/// Record for EmailAddress updated event.
/// </summary>
internal record EmailAddressUpdated(EmailAddress EmailAddress) : IDomainEvent;
/// <summary>
/// Record for EmailAddress deleted event.
/// </summary>
internal record EmailAddressDeleted(EmailAddress EmailAddress) : IDomainEvent;

/// <summary>
/// Verified Email Address.
/// </summary>
internal abstract class EmailAddressBase : EntityBase, IOwnedEntity
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