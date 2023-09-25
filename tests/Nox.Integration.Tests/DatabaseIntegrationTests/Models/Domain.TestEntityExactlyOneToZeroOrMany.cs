// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityExactlyOneToZeroOrMany:TestEntityExactlyOneToZeroOrManyBase
{

}
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany created event.
/// </summary>
public record TestEntityExactlyOneToZeroOrManyCreated(TestEntityExactlyOneToZeroOrManyBase TestEntityExactlyOneToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany updated event.
/// </summary>
public record TestEntityExactlyOneToZeroOrManyUpdated(TestEntityExactlyOneToZeroOrManyBase TestEntityExactlyOneToZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrMany deleted event.
/// </summary>
public record TestEntityExactlyOneToZeroOrManyDeleted(TestEntityExactlyOneToZeroOrManyBase TestEntityExactlyOneToZeroOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityExactlyOneToZeroOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityExactlyOneToZeroOrManyCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneToZeroOrManyUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneToZeroOrManyDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityExactlyOneToZeroOrMany Test entity relationship to TestEntityZeroOrManyToExactlyOne ExactlyOne TestEntityZeroOrManyToExactlyOnes
    /// </summary>
    public virtual TestEntityZeroOrManyToExactlyOne TestEntityZeroOrManyToExactlyOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrManyToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityZeroOrManyToExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrManyToExactlyOne(TestEntityZeroOrManyToExactlyOne relatedTestEntityZeroOrManyToExactlyOne)
    {
        TestEntityZeroOrManyToExactlyOne = relatedTestEntityZeroOrManyToExactlyOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrManyToExactlyOne(TestEntityZeroOrManyToExactlyOne relatedTestEntityZeroOrManyToExactlyOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityZeroOrManyToExactlyOne()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}