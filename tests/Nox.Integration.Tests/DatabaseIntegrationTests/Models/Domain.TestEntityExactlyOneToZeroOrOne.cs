// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityExactlyOneToZeroOrOne:TestEntityExactlyOneToZeroOrOneBase
{

}
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne created event.
/// </summary>
public record TestEntityExactlyOneToZeroOrOneCreated(TestEntityExactlyOneToZeroOrOneBase TestEntityExactlyOneToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne updated event.
/// </summary>
public record TestEntityExactlyOneToZeroOrOneUpdated(TestEntityExactlyOneToZeroOrOneBase TestEntityExactlyOneToZeroOrOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityExactlyOneToZeroOrOne deleted event.
/// </summary>
public record TestEntityExactlyOneToZeroOrOneDeleted(TestEntityExactlyOneToZeroOrOneBase TestEntityExactlyOneToZeroOrOne) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityExactlyOneToZeroOrOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneToZeroOrOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneToZeroOrOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityExactlyOneToZeroOrOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityExactlyOneToZeroOrOne Test entity relationship to TestEntityZeroOrOneToExactlyOne ExactlyOne TestEntityZeroOrOneToExactlyOnes
    /// </summary>
    public virtual TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrOneToExactlyOne
    /// </summary>
    public Nox.Types.Text TestEntityZeroOrOneToExactlyOneId { get; set; } = null!;

    public virtual void CreateRefToTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOne relatedTestEntityZeroOrOneToExactlyOne)
    {
        TestEntityZeroOrOneToExactlyOne = relatedTestEntityZeroOrOneToExactlyOne;
    }

    public virtual void DeleteRefToTestEntityZeroOrOneToExactlyOne(TestEntityZeroOrOneToExactlyOne relatedTestEntityZeroOrOneToExactlyOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityZeroOrOneToExactlyOne()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}