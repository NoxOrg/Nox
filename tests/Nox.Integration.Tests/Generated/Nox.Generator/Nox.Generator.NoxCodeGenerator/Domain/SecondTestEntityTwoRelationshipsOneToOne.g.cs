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

internal partial class SecondTestEntityTwoRelationshipsOneToOne : SecondTestEntityTwoRelationshipsOneToOneBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityTwoRelationshipsOneToOne created event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsOneToOneCreated(SecondTestEntityTwoRelationshipsOneToOne SecondTestEntityTwoRelationshipsOneToOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToOne updated event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsOneToOneUpdated(SecondTestEntityTwoRelationshipsOneToOne SecondTestEntityTwoRelationshipsOneToOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityTwoRelationshipsOneToOne deleted event.
/// </summary>
internal record SecondTestEntityTwoRelationshipsOneToOneDeleted(SecondTestEntityTwoRelationshipsOneToOne SecondTestEntityTwoRelationshipsOneToOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityTwoRelationshipsOneToOneBase : EntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityTwoRelationshipsOneToOne secondTestEntityTwoRelationshipsOneToOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsOneToOneCreated(secondTestEntityTwoRelationshipsOneToOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityTwoRelationshipsOneToOne secondTestEntityTwoRelationshipsOneToOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsOneToOneUpdated(secondTestEntityTwoRelationshipsOneToOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityTwoRelationshipsOneToOne secondTestEntityTwoRelationshipsOneToOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityTwoRelationshipsOneToOneDeleted(secondTestEntityTwoRelationshipsOneToOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne First relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToOne? TestRelationshipOneOnOtherSide { get; private set; } = null!;

    public virtual void CreateRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsOneToOne relatedTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipOneOnOtherSide = relatedTestEntityTwoRelationshipsOneToOne;
    }

    public virtual void DeleteRefToTestRelationshipOneOnOtherSide(TestEntityTwoRelationshipsOneToOne relatedTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipOneOnOtherSide = null;
    }

    public virtual void DeleteAllRefToTestRelationshipOneOnOtherSide()
    {
        TestRelationshipOneOnOtherSide = null;
    }

    /// <summary>
    /// SecondTestEntityTwoRelationshipsOneToOne Second relationship to the same entity on the other side ZeroOrOne TestEntityTwoRelationshipsOneToOnes
    /// </summary>
    public virtual TestEntityTwoRelationshipsOneToOne? TestRelationshipTwoOnOtherSide { get; private set; } = null!;

    public virtual void CreateRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToOne relatedTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipTwoOnOtherSide = relatedTestEntityTwoRelationshipsOneToOne;
    }

    public virtual void DeleteRefToTestRelationshipTwoOnOtherSide(TestEntityTwoRelationshipsOneToOne relatedTestEntityTwoRelationshipsOneToOne)
    {
        TestRelationshipTwoOnOtherSide = null;
    }

    public virtual void DeleteAllRefToTestRelationshipTwoOnOtherSide()
    {
        TestRelationshipTwoOnOtherSide = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}