﻿// Generated

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

public partial class EmailAddress : EmailAddressBase, IEntityHaveDomainEvents
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
public record EmailAddressCreated(EmailAddress EmailAddress) :  IDomainEvent, INotification;
/// <summary>
/// Record for EmailAddress updated event.
/// </summary>
public record EmailAddressUpdated(EmailAddress EmailAddress) : IDomainEvent, INotification;
/// <summary>
/// Record for EmailAddress deleted event.
/// </summary>
public record EmailAddressDeleted(EmailAddress EmailAddress) : IDomainEvent, INotification;

/// <summary>
/// Verified Email Address.
/// </summary>
public abstract partial class EmailAddressBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid StoreId {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureStoreId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			StoreId = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			StoreId = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    /// Email    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Email? Email { get;  set; } = null!;

    /// <summary>
    /// Verified    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Boolean? IsVerified { get;  set; } = null!;
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