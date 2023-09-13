// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace TestWebApp.Domain;

/// <summary>
/// Record for TestEntityWithNuid created event.
/// </summary>
public record TestEntityWithNuidCreated(TestEntityWithNuid TestEntityWithNuid) : IDomainEvent;

/// <summary>
/// Record for TestEntityWithNuid updated event.
/// </summary>
public record TestEntityWithNuidUpdated(TestEntityWithNuid TestEntityWithNuid) : IDomainEvent;

/// <summary>
/// Record for TestEntityWithNuid deleted event.
/// </summary>
public record TestEntityWithNuidDeleted(TestEntityWithNuid TestEntityWithNuid) : IDomainEvent;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuid : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nuid Id {get; set;} = null!;
    
    	public void EnsureId()
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
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}