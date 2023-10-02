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

internal partial class ThirdTestEntityExactlyOne : ThirdTestEntityExactlyOneBase, IEntityHaveDomainEvents
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
/// Record for ThirdTestEntityExactlyOne created event.
/// </summary>
internal record ThirdTestEntityExactlyOneCreated(ThirdTestEntityExactlyOne ThirdTestEntityExactlyOne) :  IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityExactlyOne updated event.
/// </summary>
internal record ThirdTestEntityExactlyOneUpdated(ThirdTestEntityExactlyOne ThirdTestEntityExactlyOne) : IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityExactlyOne deleted event.
/// </summary>
internal record ThirdTestEntityExactlyOneDeleted(ThirdTestEntityExactlyOne ThirdTestEntityExactlyOne) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class ThirdTestEntityExactlyOneBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Text TextTestField { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(ThirdTestEntityExactlyOne thirdTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new ThirdTestEntityExactlyOneCreated(thirdTestEntityExactlyOne));
	}
	
	protected virtual void InternalRaiseUpdateEvent(ThirdTestEntityExactlyOne thirdTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new ThirdTestEntityExactlyOneUpdated(thirdTestEntityExactlyOne));
	}
	
	protected virtual void InternalRaiseDeleteEvent(ThirdTestEntityExactlyOne thirdTestEntityExactlyOne)
	{
		InternalDomainEvents.Add(new ThirdTestEntityExactlyOneDeleted(thirdTestEntityExactlyOne));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// ThirdTestEntityExactlyOne Test entity relationship to ThirdTestEntityZeroOrOne ExactlyOne ThirdTestEntityZeroOrOnes
    /// </summary>
    public virtual ThirdTestEntityZeroOrOne ThirdTestEntityZeroOrOneRelationship { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity ThirdTestEntityZeroOrOne
    /// </summary>
    public Nox.Types.Text ThirdTestEntityZeroOrOneRelationshipId { get; set; } = null!;

    public virtual void CreateRefToThirdTestEntityZeroOrOneRelationship(ThirdTestEntityZeroOrOne relatedThirdTestEntityZeroOrOne)
    {
        ThirdTestEntityZeroOrOneRelationship = relatedThirdTestEntityZeroOrOne;
    }

    public virtual void DeleteRefToThirdTestEntityZeroOrOneRelationship(ThirdTestEntityZeroOrOne relatedThirdTestEntityZeroOrOne)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToThirdTestEntityZeroOrOneRelationship()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}