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

internal partial class SecondTestEntityExactlyOne : SecondTestEntityExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for SecondTestEntityExactlyOne created event.
/// </summary>
internal record SecondTestEntityExactlyOneCreated(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityExactlyOne updated event.
/// </summary>
internal record SecondTestEntityExactlyOneUpdated(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for SecondTestEntityExactlyOne deleted event.
/// </summary>
internal record SecondTestEntityExactlyOneDeleted(SecondTestEntityExactlyOne SecondTestEntityExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// .
/// </summary>
internal abstract partial class SecondTestEntityExactlyOneBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField2 { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(SecondTestEntityExactlyOne secondTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityExactlyOneCreated(secondTestEntityExactlyOne));
    }
	
	protected virtual void InternalRaiseUpdateEvent(SecondTestEntityExactlyOne secondTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityExactlyOneUpdated(secondTestEntityExactlyOne));
    }
	
	protected virtual void InternalRaiseDeleteEvent(SecondTestEntityExactlyOne secondTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new SecondTestEntityExactlyOneDeleted(secondTestEntityExactlyOne));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// SecondTestEntityExactlyOne Test entity relationship to TestEntityExactlyOneRelationship ExactlyOne TestEntityExactlyOnes
    /// </summary>
    public virtual TestEntityExactlyOne TestEntityExactlyOneRelationship { get; private set; } = null!;

    public virtual void CreateRefToTestEntityExactlyOneRelationship(TestEntityExactlyOne relatedTestEntityExactlyOne)
    {
        TestEntityExactlyOneRelationship = relatedTestEntityExactlyOne;
    }

    public virtual void DeleteRefToTestEntityExactlyOneRelationship(TestEntityExactlyOne relatedTestEntityExactlyOne)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToTestEntityExactlyOneRelationship()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}