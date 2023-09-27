// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;
public partial class SecondTestEntityTwoRelationshipsOneToMany:SecondTestEntityTwoRelationshipsOneToManyBase
{

}
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany created event.
/// </summary>
public record SecondTestEntityTwoRelationshipsOneToManyCreated(SecondTestEntityTwoRelationshipsOneToManyBase SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany updated event.
/// </summary>
public record SecondTestEntityTwoRelationshipsOneToManyUpdated(SecondTestEntityTwoRelationshipsOneToManyBase SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany deleted event.
/// </summary>
public record SecondTestEntityTwoRelationshipsOneToManyDeleted(SecondTestEntityTwoRelationshipsOneToManyBase SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent;

/// <summary>
/// .
/// </summary>
public abstract class SecondTestEntityTwoRelationshipsOneToManyBase : EntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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
		_domainEvents.Add(new SecondTestEntityTwoRelationshipsOneToManyCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new SecondTestEntityTwoRelationshipsOneToManyUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new SecondTestEntityTwoRelationshipsOneToManyDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToMany First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToMany? TestRelationshipOneOnOtherSide { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityTwoRelationshipsOneToMany
    /// </summary>
    public Nox.Types.Text? TestRelationshipOneOnOtherSideId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsOneToMany relatedTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOneOnOtherSide = relatedTestEntityTwoRelationshipsOneToMany;
    }

    public virtual void DeleteRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsOneToMany relatedTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipOneOnOtherSide = null;
    }

    public virtual void DeleteAllRefToTestRelationshipOneOnOtherSide()
    {
        TestRelationshipOneOnOtherSideId = null;
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToMany Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToManies
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToMany? TestRelationshipTwoOnOtherSide { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity TestEntityTwoRelationshipsOneToMany
    /// </summary>
    public Nox.Types.Text? TestRelationshipTwoOnOtherSideId { get; set; } = null!;

    public virtual void CreateRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToMany relatedTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwoOnOtherSide = relatedTestEntityTwoRelationshipsOneToMany;
    }

    public virtual void DeleteRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToMany relatedTestEntityTwoRelationshipsOneToMany)
    {
        TestRelationshipTwoOnOtherSide = null;
    }

    public virtual void DeleteAllRefToTestRelationshipTwoOnOtherSide()
    {
        TestRelationshipTwoOnOtherSideId = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}