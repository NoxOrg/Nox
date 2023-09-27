// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrOne:TestEntityZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityZeroOrOne created event.
/// </summary>
public record TestEntityZeroOrOneCreated(TestEntityZeroOrOneBase TestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOne updated event.
/// </summary>
public record TestEntityZeroOrOneUpdated(TestEntityZeroOrOneBase TestEntityZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOne deleted event.
/// </summary>
public record TestEntityZeroOrOneDeleted(TestEntityZeroOrOneBase TestEntityZeroOrOne) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityZeroOrOneCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrOneUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrOneDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityZeroOrOne Test entity relationship to SecondTestEntity ZeroOrOne SecondTestEntityZeroOrOnes
    /// </summary>
    public virtual SecondTestEntityZeroOrOne? SecondTestEntityZeroOrOneRelationship { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity SecondTestEntityZeroOrOne
    /// </summary>
    public Nox.Types.Text? SecondTestEntityZeroOrOneRelationshipId { get; set; } = null!;

    public virtual void CreateRefToSecondTestEntityZeroOrOneRelationship(SecondTestEntityZeroOrOne relatedSecondTestEntityZeroOrOne)
    {
        SecondTestEntityZeroOrOneRelationship = relatedSecondTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToSecondTestEntityZeroOrOneRelationship(SecondTestEntityZeroOrOne relatedSecondTestEntityZeroOrOne)
    {
        SecondTestEntityZeroOrOneRelationship = null;
    }

    public virtual void DeleteAllRefToSecondTestEntityZeroOrOneRelationship()
    {
        SecondTestEntityZeroOrOneRelationshipId = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}