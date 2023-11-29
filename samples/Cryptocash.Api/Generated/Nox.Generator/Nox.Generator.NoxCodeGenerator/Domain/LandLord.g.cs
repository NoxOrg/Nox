// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class LandLord : LandLordBase, IEntityHaveDomainEvents
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
internal record LandLordCreated(LandLord LandLord) :  IDomainEvent, INotification;
/// <summary>
/// Record for LandLord updated event.
/// </summary>
internal record LandLordUpdated(LandLord LandLord) : IDomainEvent, INotification;
/// <summary>
/// Record for LandLord deleted event.
/// </summary>
internal record LandLordDeleted(LandLord LandLord) : IDomainEvent, INotification;

/// <summary>
/// Landlord related data.
/// </summary>
internal abstract partial class LandLordBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Landlord unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid Id {get; set;} = null!;
         /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid guid)
    	{
    		if(System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid);
    		}
    	}

    /// <summary>
    /// Landlord name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Landlord's street address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.StreetAddress Address { get; set; } = null!;
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