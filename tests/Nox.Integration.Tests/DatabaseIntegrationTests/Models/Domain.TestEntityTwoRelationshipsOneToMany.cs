// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityTwoRelationshipsOneToMany:TestEntityTwoRelationshipsOneToManyBase
{

}
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany created event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyCreated(TestEntityTwoRelationshipsOneToManyBase TestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany updated event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyUpdated(TestEntityTwoRelationshipsOneToManyBase TestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsOneToMany deleted event.
/// </summary>
public record TestEntityTwoRelationshipsOneToManyDeleted(TestEntityTwoRelationshipsOneToManyBase TestEntityTwoRelationshipsOneToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsOneToManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityTwoRelationshipsOneToManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityTwoRelationshipsOneToManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityTwoRelationshipsOneToManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany First relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipOne { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOne.Add(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOne.Remove(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOne()
    {
        TestRelationshipOne.Clear();
    }

    /// <summary>
    /// TestEntityTwoRelationshipsOneToMany Second relationship to the same entity ZeroOrMany SecondTestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsOneToMany> TestRelationshipTwo { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwo.Add(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsOneToMany relatedSecondTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwo.Remove(relatedSecondTestEntityTwoRelationshipsOneToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwo()
    {
        TestRelationshipTwo.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}