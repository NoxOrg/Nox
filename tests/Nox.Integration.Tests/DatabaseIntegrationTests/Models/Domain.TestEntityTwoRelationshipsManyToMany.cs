// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class TestEntityTwoRelationshipsManyToMany:TestEntityTwoRelationshipsManyToManyBase
{

}
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany created event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyCreated(TestEntityTwoRelationshipsManyToManyBase TestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany updated event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyUpdated(TestEntityTwoRelationshipsManyToManyBase TestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for TestEntityTwoRelationshipsManyToMany deleted event.
/// </summary>
public record TestEntityTwoRelationshipsManyToManyDeleted(TestEntityTwoRelationshipsManyToManyBase TestEntityTwoRelationshipsManyToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class TestEntityTwoRelationshipsManyToManyBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new TestEntityTwoRelationshipsManyToManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new TestEntityTwoRelationshipsManyToManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new TestEntityTwoRelationshipsManyToManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany First relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsManyToMany> TestRelationshipOne { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOne.Add(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipOne(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(TestRelationshipOne.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestRelationshipOne.Remove(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOne()
    {
        if(TestRelationshipOne.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestRelationshipOne.Clear();
    }

    /// <summary>
    /// TestEntityTwoRelationshipsManyToMany Second relationship to the same entity OneOrMany SecondTestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<SecondTestEntityTwoRelationshipsManyToMany> TestRelationshipTwo { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwo.Add(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwo(SecondTestEntityTwoRelationshipsManyToMany relatedSecondTestEntityTwoRelationshipsManyToMany)
    {
        if(TestRelationshipTwo.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestRelationshipTwo.Remove(relatedSecondTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwo()
    {
        if(TestRelationshipTwo.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        TestRelationshipTwo.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}