// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOwnedRelationshipExactlyOne:TestEntityOwnedRelationshipExactlyOneBase
{

}
/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne created event.
/// </summary>
public record TestEntityOwnedRelationshipExactlyOneCreated(TestEntityOwnedRelationshipExactlyOneBase TestEntityOwnedRelationshipExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne updated event.
/// </summary>
public record TestEntityOwnedRelationshipExactlyOneUpdated(TestEntityOwnedRelationshipExactlyOneBase TestEntityOwnedRelationshipExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipExactlyOne deleted event.
/// </summary>
public record TestEntityOwnedRelationshipExactlyOneDeleted(TestEntityOwnedRelationshipExactlyOneBase TestEntityOwnedRelationshipExactlyOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipExactlyOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new TestEntityOwnedRelationshipExactlyOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityOwnedRelationshipExactlyOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityOwnedRelationshipExactlyOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityOwnedRelationshipExactlyOne Test entity relationship to SecondTestEntityOwnedRelationshipExactlyOne ExactlyOne SecondTestEntityOwnedRelationshipExactlyOnes
    /// </summary>
     public virtual SecondTestEntityOwnedRelationshipExactlyOne SecondTestEntityOwnedRelationshipExactlyOne { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}