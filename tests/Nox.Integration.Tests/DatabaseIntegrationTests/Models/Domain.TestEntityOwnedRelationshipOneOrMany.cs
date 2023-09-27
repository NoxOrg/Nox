// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOwnedRelationshipOneOrMany:TestEntityOwnedRelationshipOneOrManyBase
{

}
/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany created event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyCreated(TestEntityOwnedRelationshipOneOrManyBase TestEntityOwnedRelationshipOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany updated event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyUpdated(TestEntityOwnedRelationshipOneOrManyBase TestEntityOwnedRelationshipOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOwnedRelationshipOneOrMany deleted event.
/// </summary>
public record TestEntityOwnedRelationshipOneOrManyDeleted(TestEntityOwnedRelationshipOneOrManyBase TestEntityOwnedRelationshipOneOrMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityOwnedRelationshipOneOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityOwnedRelationshipOneOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityOwnedRelationshipOneOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityOwnedRelationshipOneOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityOwnedRelationshipOneOrMany Test entity relationship to SecondTestEntityOwnedRelationshipOneOrMany OneOrMany SecondTestEntityOwnedRelationshipOneOrManies
    /// </summary>
    public virtual List<SecondTestEntityOwnedRelationshipOneOrMany> SecondTestEntityOwnedRelationshipOneOrMany { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}