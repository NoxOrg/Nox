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

public partial class WorkplaceAddress : WorkplaceAddressBase, IEntityHaveDomainEvents
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
/// Record for WorkplaceAddress created event.
/// </summary>
public record WorkplaceAddressCreated(WorkplaceAddress WorkplaceAddress) :  IDomainEvent, INotification;
/// <summary>
/// Record for WorkplaceAddress updated event.
/// </summary>
public record WorkplaceAddressUpdated(WorkplaceAddress WorkplaceAddress) : IDomainEvent, INotification;
/// <summary>
/// Record for WorkplaceAddress deleted event.
/// </summary>
public record WorkplaceAddressDeleted(WorkplaceAddress WorkplaceAddress) : IDomainEvent, INotification;

/// <summary>
/// Workplace Address.
/// </summary>
public abstract partial class WorkplaceAddressBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid Id {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    /// Address line    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text AddressLine { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(WorkplaceAddress workplaceAddress)
	{
		InternalDomainEvents.Add(new WorkplaceAddressCreated(workplaceAddress));
    }
	
	protected virtual void InternalRaiseUpdateEvent(WorkplaceAddress workplaceAddress)
	{
		InternalDomainEvents.Add(new WorkplaceAddressUpdated(workplaceAddress));
    }
	
	protected virtual void InternalRaiseDeleteEvent(WorkplaceAddress workplaceAddress)
	{
		InternalDomainEvents.Add(new WorkplaceAddressDeleted(workplaceAddress));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

        /// <summary>
        /// WorkplaceAddress localized entities.
        /// </summary>
        public virtual List<WorkplaceAddressLocalized> LocalizedWorkplaceAddresses  { get; private set; } = new();
    
    
    	/// <summary>
    	/// Creates a new WorkplaceAddressLocalized entity.
    	/// </summary>
        public virtual void CreateRefToLocalizedWorkplaceAddresses(WorkplaceAddressLocalized relatedWorkplaceAddressLocalized)
    	{
    		LocalizedWorkplaceAddresses.Add(relatedWorkplaceAddressLocalized);
    	}
        
}