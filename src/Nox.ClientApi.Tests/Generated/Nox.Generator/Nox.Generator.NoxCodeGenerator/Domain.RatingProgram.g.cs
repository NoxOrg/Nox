﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;

internal partial class RatingProgram : RatingProgramBase, IEntityHaveDomainEvents
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
/// Record for RatingProgram created event.
/// </summary>
internal record RatingProgramCreated(RatingProgram RatingProgram) : IDomainEvent;
/// <summary>
/// Record for RatingProgram updated event.
/// </summary>
internal record RatingProgramUpdated(RatingProgram RatingProgram) : IDomainEvent;
/// <summary>
/// Record for RatingProgram deleted event.
/// </summary>
internal record RatingProgramDeleted(RatingProgram RatingProgram) : IDomainEvent;

/// <summary>
/// Rating program for store.
/// </summary>
internal abstract partial class RatingProgramBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Guid StoreId { get; set; } = null!;
    
        public virtual Store Store { get; set; } = null!;
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Rating Program Name (Optional).
    /// </summary>
    public Nox.Types.Text? Name { get; set; } = null!;
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(RatingProgram ratingProgram)
	{
		InternalDomainEvents.Add(new RatingProgramCreated(ratingProgram));
	}
	
	protected virtual void InternalRaiseUpdateEvent(RatingProgram ratingProgram)
	{
		InternalDomainEvents.Add(new RatingProgramUpdated(ratingProgram));
	}
	
	protected virtual void InternalRaiseDeleteEvent(RatingProgram ratingProgram)
	{
		InternalDomainEvents.Add(new RatingProgramDeleted(ratingProgram));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}