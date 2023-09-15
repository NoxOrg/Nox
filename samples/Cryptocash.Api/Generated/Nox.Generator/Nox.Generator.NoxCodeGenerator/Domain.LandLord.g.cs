// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class LandLord:LandLordBase
{

}
/// <summary>
/// Record for LandLord created event.
/// </summary>
public record LandLordCreated(LandLord LandLord) : IDomainEvent;
/// <summary>
/// Record for LandLord updated event.
/// </summary>
public record LandLordUpdated(LandLord LandLord) : IDomainEvent;
/// <summary>
/// Record for LandLord deleted event.
/// </summary>
public record LandLordDeleted(LandLord LandLord) : IDomainEvent;

/// <summary>
/// Landlord related data.
/// </summary>
public abstract class LandLordBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Landlord unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Landlord name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Landlord's street address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// LandLord leases an area to house ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> ContractedAreasForVendingMachines { get; set; } = new();

    public virtual void CreateRefToVendingMachineContractedAreasForVendingMachines(VendingMachine relatedVendingMachine)
    {
        ContractedAreasForVendingMachines.Add(relatedVendingMachine);
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}