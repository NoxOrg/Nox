// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityWithNuid:TestEntityWithNuidBase
{

}
/// <summary>
/// Record for TestEntityWithNuid created event.
/// </summary>
public record TestEntityWithNuidCreated(TestEntityWithNuidBase TestEntityWithNuid) : IDomainEvent;
/// <summary>
/// Record for TestEntityWithNuid updated event.
/// </summary>
public record TestEntityWithNuidUpdated(TestEntityWithNuidBase TestEntityWithNuid) : IDomainEvent;
/// <summary>
/// Record for TestEntityWithNuid deleted event.
/// </summary>
public record TestEntityWithNuidDeleted(TestEntityWithNuidBase TestEntityWithNuid) : IDomainEvent;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public abstract class TestEntityWithNuidBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new TestEntityWithNuidCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityWithNuidUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityWithNuidDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}