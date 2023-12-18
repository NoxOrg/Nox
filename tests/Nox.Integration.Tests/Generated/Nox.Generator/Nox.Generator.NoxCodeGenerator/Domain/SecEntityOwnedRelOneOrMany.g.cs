// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Exceptions;

namespace TestWebApp.Domain;

internal partial class SecEntityOwnedRelOneOrMany : SecEntityOwnedRelOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for SecEntityOwnedRelOneOrMany created event.
/// </summary>
internal record SecEntityOwnedRelOneOrManyCreated(SecEntityOwnedRelOneOrMany SecEntityOwnedRelOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecEntityOwnedRelOneOrMany updated event.
/// </summary>
internal record SecEntityOwnedRelOneOrManyUpdated(SecEntityOwnedRelOneOrMany SecEntityOwnedRelOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecEntityOwnedRelOneOrMany deleted event.
/// </summary>
internal record SecEntityOwnedRelOneOrManyDeleted(SecEntityOwnedRelOneOrMany SecEntityOwnedRelOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecEntityOwnedRelOneOrManyBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField2 { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecEntityOwnedRelOneOrMany secEntityOwnedRelOneOrMany)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelOneOrManyCreated(secEntityOwnedRelOneOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecEntityOwnedRelOneOrMany secEntityOwnedRelOneOrMany)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelOneOrManyUpdated(secEntityOwnedRelOneOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecEntityOwnedRelOneOrMany secEntityOwnedRelOneOrMany)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelOneOrManyDeleted(secEntityOwnedRelOneOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

}