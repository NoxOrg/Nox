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

internal partial class SecEntityOwnedRelZeroOrMany : SecEntityOwnedRelZeroOrManyBase, IEntityHaveDomainEvents
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
/// Record for SecEntityOwnedRelZeroOrMany created event.
/// </summary>
internal record SecEntityOwnedRelZeroOrManyCreated(SecEntityOwnedRelZeroOrMany SecEntityOwnedRelZeroOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecEntityOwnedRelZeroOrMany updated event.
/// </summary>
internal record SecEntityOwnedRelZeroOrManyUpdated(SecEntityOwnedRelZeroOrMany SecEntityOwnedRelZeroOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecEntityOwnedRelZeroOrMany deleted event.
/// </summary>
internal record SecEntityOwnedRelZeroOrManyDeleted(SecEntityOwnedRelZeroOrMany SecEntityOwnedRelZeroOrMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecEntityOwnedRelZeroOrManyBase : EntityBase, IOwnedEntity
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

	protected virtual void InternalRaiseCreateEvent(SecEntityOwnedRelZeroOrMany secEntityOwnedRelZeroOrMany)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelZeroOrManyCreated(secEntityOwnedRelZeroOrMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecEntityOwnedRelZeroOrMany secEntityOwnedRelZeroOrMany)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelZeroOrManyUpdated(secEntityOwnedRelZeroOrMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecEntityOwnedRelZeroOrMany secEntityOwnedRelZeroOrMany)
	{
		InternalDomainEvents.Add(new SecEntityOwnedRelZeroOrManyDeleted(secEntityOwnedRelZeroOrMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
}