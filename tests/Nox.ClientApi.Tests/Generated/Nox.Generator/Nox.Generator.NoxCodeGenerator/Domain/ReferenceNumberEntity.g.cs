// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Exceptions;

namespace ClientApi.Domain;

internal partial class ReferenceNumberEntity : ReferenceNumberEntityBase, IEntityHaveDomainEvents
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
/// Record for ReferenceNumberEntity created event.
/// </summary>
internal record ReferenceNumberEntityCreated(ReferenceNumberEntity ReferenceNumberEntity) :  IDomainEvent, INotification;
/// <summary>
/// Record for ReferenceNumberEntity updated event.
/// </summary>
internal record ReferenceNumberEntityUpdated(ReferenceNumberEntity ReferenceNumberEntity) : IDomainEvent, INotification;
/// <summary>
/// Record for ReferenceNumberEntity deleted event.
/// </summary>
internal record ReferenceNumberEntityDeleted(ReferenceNumberEntity ReferenceNumberEntity) : IDomainEvent, INotification;

/// <summary>
/// ReferenceNumberEntity.
/// </summary>
internal abstract partial class ReferenceNumberEntityBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.ReferenceNumber Id {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Reference Number is set. This should only be called when creating a new entity, it's immutable property.
        /// </summary>
    	public virtual void EnsureId(System.Int64 number, Nox.Types.ReferenceNumberTypeOptions typeOptions)
    	{
    		Id = Nox.Types.ReferenceNumber.From(number, typeOptions);
    	}

    /// <summary>
    /// ReferenceNumber    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.ReferenceNumber ReferenceNumber {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Reference Number is set. This should only be called when creating a new entity, it's immutable property.
        /// </summary>
    	public virtual void EnsureReferenceNumber(System.Int64 number, Nox.Types.ReferenceNumberTypeOptions typeOptions)
    	{
    		ReferenceNumber = Nox.Types.ReferenceNumber.From(number, typeOptions);
    	}
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(ReferenceNumberEntity referenceNumberEntity)
	{
		InternalDomainEvents.Add(new ReferenceNumberEntityCreated(referenceNumberEntity));
    }
	
	protected virtual void InternalRaiseUpdateEvent(ReferenceNumberEntity referenceNumberEntity)
	{
		InternalDomainEvents.Add(new ReferenceNumberEntityUpdated(referenceNumberEntity));
    }
	
	protected virtual void InternalRaiseDeleteEvent(ReferenceNumberEntity referenceNumberEntity)
	{
		InternalDomainEvents.Add(new ReferenceNumberEntityDeleted(referenceNumberEntity));
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