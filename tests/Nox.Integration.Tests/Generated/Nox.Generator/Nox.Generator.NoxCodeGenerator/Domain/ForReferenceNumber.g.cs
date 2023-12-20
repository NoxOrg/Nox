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

namespace TestWebApp.Domain;

internal partial class ForReferenceNumber : ForReferenceNumberBase, IEntityHaveDomainEvents
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
/// Record for ForReferenceNumber created event.
/// </summary>
internal record ForReferenceNumberCreated(ForReferenceNumber ForReferenceNumber) :  IDomainEvent, INotification;
/// <summary>
/// Record for ForReferenceNumber updated event.
/// </summary>
internal record ForReferenceNumberUpdated(ForReferenceNumber ForReferenceNumber) : IDomainEvent, INotification;
/// <summary>
/// Record for ForReferenceNumber deleted event.
/// </summary>
internal record ForReferenceNumberDeleted(ForReferenceNumber ForReferenceNumber) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing auto number usages.
/// </summary>
internal abstract partial class ForReferenceNumberBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    /// Workplace Id    
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
    /// Workplace Number    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.ReferenceNumber WorkplaceNumber {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Reference Number is set. This should only be called when creating a new entity, it's immutable property.
        /// </summary>
    	public virtual void EnsureWorkplaceNumber(System.Int64 number, Nox.Types.ReferenceNumberTypeOptions typeOptions)
    	{
    		WorkplaceNumber = Nox.Types.ReferenceNumber.From(number, typeOptions);
    	}
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(ForReferenceNumber forReferenceNumber)
	{
		InternalDomainEvents.Add(new ForReferenceNumberCreated(forReferenceNumber));
    }
	
	protected virtual void InternalRaiseUpdateEvent(ForReferenceNumber forReferenceNumber)
	{
		InternalDomainEvents.Add(new ForReferenceNumberUpdated(forReferenceNumber));
    }
	
	protected virtual void InternalRaiseDeleteEvent(ForReferenceNumber forReferenceNumber)
	{
		InternalDomainEvents.Add(new ForReferenceNumberDeleted(forReferenceNumber));
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