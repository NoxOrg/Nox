// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace TestWebApp.Domain;

internal partial class SecondTestEntityTwoRelationshipsOneToMany : SecondTestEntityTwoRelationshipsOneToManyBase, IEntityHaveDomainEvents
{
    ///<inheritdoc/>
    public void RaiseCreateEvent()
    {
        InternalRaiseCreateEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseDeleteEvent()
    {
        InternalRaiseDeleteEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseUpdateEvent()
    {
        InternalRaiseUpdateEvent(this);
    }
}
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany created event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsOneToManyCreated(SecondTestEntityTwoRelationshipsOneToMany SecondTestEntityTwoRelationshipsOneToMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany updated event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsOneToManyUpdated(SecondTestEntityTwoRelationshipsOneToMany SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToMany deleted event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsOneToManyDeleted(SecondTestEntityTwoRelationshipsOneToMany SecondTestEntityTwoRelationshipsOneToMany) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityTwoRelationshipsOneToManyBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityTwoRelationshipsOneToMany secondTestEntityTwoRelationshipsOneToMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsOneToManyCreated(secondTestEntityTwoRelationshipsOneToMany));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityTwoRelationshipsOneToMany secondTestEntityTwoRelationshipsOneToMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsOneToManyUpdated(secondTestEntityTwoRelationshipsOneToMany));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityTwoRelationshipsOneToMany secondTestEntityTwoRelationshipsOneToMany)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsOneToManyDeleted(secondTestEntityTwoRelationshipsOneToMany));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
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