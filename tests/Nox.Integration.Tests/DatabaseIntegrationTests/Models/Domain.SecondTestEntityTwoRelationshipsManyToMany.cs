// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityTwoRelationshipsManyToMany:SecondTestEntityTwoRelationshipsManyToManyBase
{

}
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany created event.
/// </summary>
public record SecondTestEntityTwoRelationshipsManyToManyCreated(SecondTestEntityTwoRelationshipsManyToManyBase SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany updated event.
/// </summary>
public record SecondTestEntityTwoRelationshipsManyToManyUpdated(SecondTestEntityTwoRelationshipsManyToManyBase SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsManyToMany deleted event.
/// </summary>
public record SecondTestEntityTwoRelationshipsManyToManyDeleted(SecondTestEntityTwoRelationshipsManyToManyBase SecondTestEntityTwoRelationshipsManyToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsManyToManyBase : EntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new SecondTestEntityTwoRelationshipsManyToManyCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityTwoRelationshipsManyToManyUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityTwoRelationshipsManyToManyDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany First relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<TestEntityTwoRelationshipsManyToMany> TestRelationshipOneOnOtherSide { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOneOnOtherSide.Add(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipOneOnOtherSide.Remove(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipOneOnOtherSide()
    {
        TestRelationshipOneOnOtherSide.Clear();
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsManyToMany Second relationship to the same entity on the other side ZeroOrMany TestEntityTwoRelationshipsManyToManies
    /// </summary>
    public virtual List<TestEntityTwoRelationshipsManyToMany> TestRelationshipTwoOnOtherSide { get; private set; } = new();

    public virtual void CreateRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwoOnOtherSide.Add(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsManyToMany relatedTestEntityTwoRelationshipsManyToMany)
    {
        TestRelationshipTwoOnOtherSide.Remove(relatedTestEntityTwoRelationshipsManyToMany);
    }

    public virtual void DeleteAllRefToTestRelationshipTwoOnOtherSide()
    {
        TestRelationshipTwoOnOtherSide.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}