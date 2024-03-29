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

namespace TestWebApp.Domain;

public partial class TestEntityWithNuid : TestEntityWithNuidBase, IEntityHaveDomainEvents
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
/// Record for TestEntityWithNuid created event.
/// </summary>
public record TestEntityWithNuidCreated(TestEntityWithNuid TestEntityWithNuid) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityWithNuid updated event.
/// </summary>
public record TestEntityWithNuidUpdated(TestEntityWithNuid TestEntityWithNuid) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityWithNuid deleted event.
/// </summary>
public record TestEntityWithNuidDeleted(TestEntityWithNuid TestEntityWithNuid) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public abstract partial class TestEntityWithNuidBase : AuditableEntityBase, IEtag
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nuid Id {get; private set; } = null!;
       
    	public virtual void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("TestEntityWithNuid." + string.Join(".", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("TestEntityWithNuid." + string.Join(".", Name.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityWithNuid testEntityWithNuid)
	{
		InternalDomainEvents.Add(new TestEntityWithNuidCreated(testEntityWithNuid));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityWithNuid testEntityWithNuid)
	{
		InternalDomainEvents.Add(new TestEntityWithNuidUpdated(testEntityWithNuid));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityWithNuid testEntityWithNuid)
	{
		InternalDomainEvents.Add(new TestEntityWithNuidDeleted(testEntityWithNuid));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}