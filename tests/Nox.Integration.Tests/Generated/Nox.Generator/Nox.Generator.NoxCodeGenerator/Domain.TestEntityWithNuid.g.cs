// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;

internal partial class TestEntityWithNuid : TestEntityWithNuidBase, IEntityHaveDomainEvents
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
internal record TestEntityWithNuidCreated(TestEntityWithNuid TestEntityWithNuid) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityWithNuid updated event.
/// </summary>
internal record TestEntityWithNuidUpdated(TestEntityWithNuid TestEntityWithNuid) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityWithNuid deleted event.
/// </summary>
internal record TestEntityWithNuidDeleted(TestEntityWithNuid TestEntityWithNuid) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
internal abstract partial class TestEntityWithNuidBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nuid Id {get; set;} = null!;
    
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
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;
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