// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class LandLord:LandLordBase
{

}
/// <summary>
/// Record for LandLord created event.
/// </summary>
public record LandLordCreated(LandLordBase LandLord) : IDomainEvent;
/// <summary>
/// Record for LandLord updated event.
/// </summary>
public record LandLordUpdated(LandLordBase LandLord) : IDomainEvent;
/// <summary>
/// Record for LandLord deleted event.
/// </summary>
public record LandLordDeleted(LandLordBase LandLord) : IDomainEvent;

/// <summary>
/// Landlord related data.
/// </summary>
public abstract class LandLordBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new LandLordCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new LandLordUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new LandLordDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
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