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

namespace ClientApi.Domain;

public partial class UserContactSelection : UserContactSelectionBase, IEntityHaveDomainEvents
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
/// Record for UserContactSelection created event.
/// </summary>
public record UserContactSelectionCreated(UserContactSelection UserContactSelection) :  IDomainEvent, INotification;
/// <summary>
/// Record for UserContactSelection updated event.
/// </summary>
public record UserContactSelectionUpdated(UserContactSelection UserContactSelection) : IDomainEvent, INotification;
/// <summary>
/// Record for UserContactSelection deleted event.
/// </summary>
public record UserContactSelectionDeleted(UserContactSelection UserContactSelection) : IDomainEvent, INotification;

/// <summary>
/// User Contacts.
/// </summary>
public abstract partial class UserContactSelectionBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// The person unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid PersonId {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsurePersonId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			PersonId = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			PersonId = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    /// Contact Id that user switched to    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid ContactId { get;  set; } = null!;

    /// <summary>
    /// Account Id that user switched to    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid AccountId { get;  set; } = null!;

    /// <summary>
    /// selected date    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.DateTime SelectedDate { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(UserContactSelection userContactSelection)
	{
		InternalDomainEvents.Add(new UserContactSelectionCreated(userContactSelection));
    }
	
	protected virtual void InternalRaiseUpdateEvent(UserContactSelection userContactSelection)
	{
		InternalDomainEvents.Add(new UserContactSelectionUpdated(userContactSelection));
    }
	
	protected virtual void InternalRaiseDeleteEvent(UserContactSelection userContactSelection)
	{
		InternalDomainEvents.Add(new UserContactSelectionDeleted(userContactSelection));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
}