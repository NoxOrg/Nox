// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOwnedRelationshipZeroOrOne:TestEntityOwnedRelationshipZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne created event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneCreated(TestEntityOwnedRelationshipZeroOrOneBase TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne updated event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneUpdated(TestEntityOwnedRelationshipZeroOrOneBase TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipZeroOrOne deleted event.
/// </summary>
public record TestEntityOwnedRelationshipZeroOrOneDeleted(TestEntityOwnedRelationshipZeroOrOneBase TestEntityOwnedRelationshipZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipZeroOrOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityOwnedRelationshipZeroOrOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityOwnedRelationshipZeroOrOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityOwnedRelationshipZeroOrOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityOwnedRelationshipZeroOrOne Test entity relationship to SecondTestEntityOwnedRelationshipZeroOrOne ZeroOrOne SecondTestEntityOwnedRelationshipZeroOrOnes
    /// </summary>
     public virtual SecondTestEntityOwnedRelationshipZeroOrOne? SecondTestEntityOwnedRelationshipZeroOrOne { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}