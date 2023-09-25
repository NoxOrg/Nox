// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrMany:TestEntityZeroOrManyBase
{

}
/// <summary>
/// Record for TestEntityZeroOrMany created event.
/// </summary>
public record TestEntityZeroOrManyCreated(TestEntityZeroOrManyBase TestEntityZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrMany updated event.
/// </summary>
public record TestEntityZeroOrManyUpdated(TestEntityZeroOrManyBase TestEntityZeroOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityZeroOrMany deleted event.
/// </summary>
public record TestEntityZeroOrManyDeleted(TestEntityZeroOrManyBase TestEntityZeroOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityZeroOrManyCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityZeroOrManyDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityZeroOrMany Test entity relationship to SecondTestEntityZeroOrMany ZeroOrMany SecondTestEntityZeroOrManies
    /// </summary>
    public virtual List<SecondTestEntityZeroOrMany> SecondTestEntityZeroOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToSecondTestEntityZeroOrManyRelationship(SecondTestEntityZeroOrMany relatedSecondTestEntityZeroOrMany)
    {
        SecondTestEntityZeroOrManyRelationship.Add(relatedSecondTestEntityZeroOrMany);
    }

    public virtual void DeleteRefToSecondTestEntityZeroOrManyRelationship(SecondTestEntityZeroOrMany relatedSecondTestEntityZeroOrMany)
    {
        SecondTestEntityZeroOrManyRelationship.Remove(relatedSecondTestEntityZeroOrMany);
    }

    public virtual void DeleteAllRefToSecondTestEntityZeroOrManyRelationship()
    {
        SecondTestEntityZeroOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}