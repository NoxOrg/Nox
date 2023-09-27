// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityExactlyOneToOneOrMany:TestEntityExactlyOneToOneOrManyBase
{

}
/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany created event.
/// </summary>
public record TestEntityExactlyOneToOneOrManyCreated(TestEntityExactlyOneToOneOrManyBase TestEntityExactlyOneToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany updated event.
/// </summary>
public record TestEntityExactlyOneToOneOrManyUpdated(TestEntityExactlyOneToOneOrManyBase TestEntityExactlyOneToOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToOneOrMany deleted event.
/// </summary>
public record TestEntityExactlyOneToOneOrManyDeleted(TestEntityExactlyOneToOneOrManyBase TestEntityExactlyOneToOneOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityExactlyOneToOneOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityExactlyOneToOneOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneToOneOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneToOneOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityExactlyOneToOneOrMany Test entity relationship to TestEntityOneOrManyToExactlyOne ExactlyOne TestEntityOneOrManyToExactlyOnes
    /// </summary>
    public virtual TestEntityOneOrManyToExactlyOne TestEntityOneOrManyToExactlyOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityOneOrManyToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityOneOrManyToExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityOneOrManyToExactlyOne(TestEntityOneOrManyToExactlyOne relatedTestEntityOneOrManyToExactlyOne)
    {
        TestEntityOneOrManyToExactlyOne = relatedTestEntityOneOrManyToExactlyOne;
    }

    public virtual void DeleteRefToTestEntityOneOrManyToExactlyOne(TestEntityOneOrManyToExactlyOne relatedTestEntityOneOrManyToExactlyOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityOneOrManyToExactlyOne()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}