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

internal partial class ThirdTestEntityOneOrMany : ThirdTestEntityOneOrManyBase, IEntityHaveDomainEvents
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
/// Record for ThirdTestEntityOneOrMany created event.
/// </summary>
internal record ThirdTestEntityOneOrManyCreated(ThirdTestEntityOneOrMany ThirdTestEntityOneOrMany) :  IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityOneOrMany updated event.
/// </summary>
internal record ThirdTestEntityOneOrManyUpdated(ThirdTestEntityOneOrMany ThirdTestEntityOneOrMany) : IDomainEvent, INotification;
/// <summary>
/// Record for ThirdTestEntityOneOrMany deleted event.
/// </summary>
internal record ThirdTestEntityOneOrManyDeleted(ThirdTestEntityOneOrMany ThirdTestEntityOneOrMany) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing database.
/// </summary>
internal abstract partial class ThirdTestEntityOneOrManyBase : AuditableEntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(ThirdTestEntityOneOrMany thirdTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new ThirdTestEntityOneOrManyCreated(thirdTestEntityOneOrMany));
	}
	
	protected virtual void InternalRaiseUpdateEvent(ThirdTestEntityOneOrMany thirdTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new ThirdTestEntityOneOrManyUpdated(thirdTestEntityOneOrMany));
	}
	
	protected virtual void InternalRaiseDeleteEvent(ThirdTestEntityOneOrMany thirdTestEntityOneOrMany)
	{
		InternalDomainEvents.Add(new ThirdTestEntityOneOrManyDeleted(thirdTestEntityOneOrMany));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// ThirdTestEntityOneOrMany Test entity relationship to ThirdTestEntityZeroOrMany OneOrMany ThirdTestEntityZeroOrManies
    /// </summary>
    public virtual List<ThirdTestEntityZeroOrMany> ThirdTestEntityZeroOrManyRelationship { get; private set; } = new();

    public virtual void CreateRefToThirdTestEntityZeroOrManyRelationship(ThirdTestEntityZeroOrMany relatedThirdTestEntityZeroOrMany)
    {
        ThirdTestEntityZeroOrManyRelationship.Add(relatedThirdTestEntityZeroOrMany);
    }

    public virtual void DeleteRefToThirdTestEntityZeroOrManyRelationship(ThirdTestEntityZeroOrMany relatedThirdTestEntityZeroOrMany)
    {
        if(ThirdTestEntityZeroOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        ThirdTestEntityZeroOrManyRelationship.Remove(relatedThirdTestEntityZeroOrMany);
    }

    public virtual void DeleteAllRefToThirdTestEntityZeroOrManyRelationship()
    {
        if(ThirdTestEntityZeroOrManyRelationship.Count() < 2)
            throw new Exception($"The relationship cannot be deleted.");
        ThirdTestEntityZeroOrManyRelationship.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}