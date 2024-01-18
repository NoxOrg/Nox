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

namespace Cryptocash.Domain;

public partial class LandLord : LandLordBase, IEntityHaveDomainEvents
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
/// Record for LandLord created event.
/// </summary>
public record LandLordCreated(LandLord LandLord) :  IDomainEvent, INotification;
/// <summary>
/// Record for LandLord updated event.
/// </summary>
public record LandLordUpdated(LandLord LandLord) : IDomainEvent, INotification;
/// <summary>
/// Record for LandLord deleted event.
/// </summary>
public record LandLordDeleted(LandLord LandLord) : IDomainEvent, INotification;

/// <summary>
/// Landlord related data.
/// </summary>
public abstract partial class LandLordBase : AuditableEntityBase, IEtag
{
    /// <summary>
    /// Landlord unique identifier    
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
    /// Landlord name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Landlord's street address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.StreetAddress Address { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(LandLord landLord)
	{
		InternalDomainEvents.Add(new LandLordCreated(landLord));
    }
	
	protected virtual void InternalRaiseUpdateEvent(LandLord landLord)
	{
		InternalDomainEvents.Add(new LandLordUpdated(landLord));
    }
	
	protected virtual void InternalRaiseDeleteEvent(LandLord landLord)
	{
		InternalDomainEvents.Add(new LandLordDeleted(landLord));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// LandLord leases an area to house ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> VendingMachines { get; private set; } = new();

    public virtual void CreateRefToVendingMachines(VendingMachine relatedVendingMachine)
    {
        VendingMachines.Add(relatedVendingMachine);
    }

    public virtual void UpdateRefToVendingMachines(List<VendingMachine> relatedVendingMachine)
    {
        VendingMachines.Clear();
        VendingMachines.AddRange(relatedVendingMachine);
    }

    public virtual void DeleteRefToVendingMachines(VendingMachine relatedVendingMachine)
    {
        VendingMachines.Remove(relatedVendingMachine);
    }

    public virtual void DeleteAllRefToVendingMachines()
    {
        VendingMachines.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}