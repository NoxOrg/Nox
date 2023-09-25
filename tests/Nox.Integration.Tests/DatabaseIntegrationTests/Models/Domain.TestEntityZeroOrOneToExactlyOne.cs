// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrOneToExactlyOne:TestEntityZeroOrOneToExactlyOneBase
{

}
/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne created event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneCreated(TestEntityZeroOrOneToExactlyOneBase TestEntityZeroOrOneToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne updated event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneUpdated(TestEntityZeroOrOneToExactlyOneBase TestEntityZeroOrOneToExactlyOne) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrOneToExactlyOne deleted event.
/// </summary>
public record TestEntityZeroOrOneToExactlyOneDeleted(TestEntityZeroOrOneToExactlyOneBase TestEntityZeroOrOneToExactlyOne) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToExactlyOneBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityZeroOrOneToExactlyOneCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrOneToExactlyOneUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrOneToExactlyOneDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityZeroOrOneToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrOne ZeroOrOne TestEntityExactlyOneToZeroOrOnes
    /// </summary>
    public virtual TestEntityExactlyOneToZeroOrOne? TestEntityExactlyOneToZeroOrOne { get; private set; } = null!;

    public virtual void CreateRefToTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOne relatedTestEntityExactlyOneToZeroOrOne)
    {
        TestEntityExactlyOneToZeroOrOne = relatedTestEntityExactlyOneToZeroOrOne;
    }

    public virtual void DeleteRefToTestEntityExactlyOneToZeroOrOne(TestEntityExactlyOneToZeroOrOne relatedTestEntityExactlyOneToZeroOrOne)
    {
        TestEntityExactlyOneToZeroOrOne = null;
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneToZeroOrOne()
    {
        TestEntityExactlyOneToZeroOrOne = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}