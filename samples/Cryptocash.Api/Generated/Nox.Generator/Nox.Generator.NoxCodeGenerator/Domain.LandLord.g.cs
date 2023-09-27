
// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class LandLord:LandLordBase, IEntityHaveDomainEvents
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
internal record LandLordCreated(LandLord LandLord) : IDomainEvent;
/// <summary>
/// Record for LandLord updated event.
/// </summary>
internal record LandLordUpdated(LandLord LandLord) : IDomainEvent;
/// <summary>
/// Record for LandLord deleted event.
/// </summary>
internal record LandLordDeleted(LandLord LandLord) : IDomainEvent;

/// <summary>
/// Landlord related data.
/// </summary>
internal abstract class LandLordBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Landlord unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Landlord name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Landlord's street address (Required).
    /// </summary>
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
    public virtual List<VendingMachine> ContractedAreasForVendingMachines { get; private set; } = new();

    public virtual void CreateRefToContractedAreasForVendingMachines(VendingMachine relatedVendingMachine)
    {
        ContractedAreasForVendingMachines.Add(relatedVendingMachine);
    }

    public virtual void DeleteRefToContractedAreasForVendingMachines(VendingMachine relatedVendingMachine)
    {
        ContractedAreasForVendingMachines.Remove(relatedVendingMachine);
    }

    public virtual void DeleteAllRefToContractedAreasForVendingMachines()
    {
        ContractedAreasForVendingMachines.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}