// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityOneOrMany:TestEntityOneOrManyBase
{

}
/// <summary>
/// Record for TestEntityOneOrMany created event.
/// </summary>
public record TestEntityOneOrManyCreated(TestEntityOneOrManyBase TestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrMany updated event.
/// </summary>
public record TestEntityOneOrManyUpdated(TestEntityOneOrManyBase TestEntityOneOrMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityOneOrMany deleted event.
/// </summary>
public record TestEntityOneOrManyDeleted(TestEntityOneOrManyBase TestEntityOneOrMany) : IDomainEvent;

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityOneOrManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityOneOrManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityOneOrManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityOneOrMany Test entity relationship to SecondTestEntityOneOrMany OneOrMany SecondTestEntityOneOrManies
    /// </summary>
    public virtual List<SecondTestEntityOneOrMany> SecondTestEntityOneOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToSecondTestEntityOneOrManyRelationship(SecondTestEntityOneOrMany relatedSecondTestEntityOneOrMany)
    {
        SecondTestEntityOneOrManyRelationship.Add(relatedSecondTestEntityOneOrMany);
    }

    public virtual void DeleteRefToSecondTestEntityOneOrManyRelationship(SecondTestEntityOneOrMany relatedSecondTestEntityOneOrMany)
    {
        if(SecondTestEntityOneOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        SecondTestEntityOneOrManyRelationship.Remove(relatedSecondTestEntityOneOrMany);
    }

    public virtual void DeleteAllRefToSecondTestEntityOneOrManyRelationship()
    {
        if(SecondTestEntityOneOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        SecondTestEntityOneOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}