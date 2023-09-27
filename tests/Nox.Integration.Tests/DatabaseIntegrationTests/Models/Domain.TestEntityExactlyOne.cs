// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityExactlyOne:TestEntityExactlyOneBase
{

}
/// <summary>
/// Record for TestEntityExactlyOne created event.
/// </summary>
public record TestEntityExactlyOneCreated(TestEntityExactlyOneBase TestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOne updated event.
/// </summary>
public record TestEntityExactlyOneUpdated(TestEntityExactlyOneBase TestEntityExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOne deleted event.
/// </summary>
public record TestEntityExactlyOneDeleted(TestEntityExactlyOneBase TestEntityExactlyOne) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityExactlyOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityExactlyOneCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityExactlyOne Test entity relationship to SecondTestEntityExactlyOneRelationship ExactlyOne SecondTestEntityExactlyOnes
    /// </summary>
    public virtual SecondTestEntityExactlyOne SecondTestEntityExactlyOneRelationship { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity SecondTestEntityExactlyOne
    /// </summary>
    public Nox.Types.Text SecondTestEntityExactlyOneRelationshipId { get; set; } = null!;

    public virtual void CreateRefToSecondTestEntityExactlyOneRelationship(SecondTestEntityExactlyOne relatedSecondTestEntityExactlyOne)
    {
        SecondTestEntityExactlyOneRelationship = relatedSecondTestEntityExactlyOne;
    }

    public virtual void DeleteRefToSecondTestEntityExactlyOneRelationship(SecondTestEntityExactlyOne relatedSecondTestEntityExactlyOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToSecondTestEntityExactlyOneRelationship()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}