// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;

internal partial class EmailAddress : EmailAddressBase, IEntityHaveDomainEvents
{
    ///<inheritdoc/>
    public void RaiseCreateEvent()
    {
        InternalRaiseCreateEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseDeleteEvent()
    {
        InternalRaiseDeleteEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseUpdateEvent()
    {
        InternalRaiseUpdateEvent(this);
    }
}
/// <summary>
/// Record for EmailAddress created event.
/// </summary>
internal record EmailAddressCreated(EmailAddress EmailAddress) :  IDomainEvent, INotification;
/// <summary>
/// Record for EmailAddress updated event.
/// </summary>
internal record EmailAddressUpdated(EmailAddress EmailAddress) : IDomainEvent, INotification;
/// <summary>
/// Record for EmailAddress deleted event.
/// </summary>
internal record EmailAddressDeleted(EmailAddress EmailAddress) : IDomainEvent, INotification;

/// <summary>
/// Verified Email Address.
/// </summary>
internal abstract partial class EmailAddressBase : EntityBase, IOwnedEntity
{

    /// <summary>
    /// Email (Optional).
    /// </summary>
    public Nox.Types.Email? Email { get; set; } = null!;

    /// <summary>
    /// Verified (Optional).
    /// </summary>
    public Nox.Types.Boolean? IsVerified { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

    protected virtual void InternalRaiseCreateEvent(EmailAddress emailAddress)
    {
        InternalDomainEvents.Add(new EmailAddressCreated(emailAddress));
    }
	
    protected virtual void InternalRaiseUpdateEvent(EmailAddress emailAddress)
    {
        InternalDomainEvents.Add(new EmailAddressUpdated(emailAddress));
    }
	
    protected virtual void InternalRaiseDeleteEvent(EmailAddress emailAddress)
    {
        InternalDomainEvents.Add(new EmailAddressDeleted(emailAddress));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

}