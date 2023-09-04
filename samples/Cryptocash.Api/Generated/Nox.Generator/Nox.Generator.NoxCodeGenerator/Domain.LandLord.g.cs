// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Landlord related data.
/// </summary>
public partial class LandLord : AuditableEntityBase
{
    /// <summary>
    /// Landlord unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Landlord name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Landlord's street address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// LandLord Landlord's area of the vending machine installation ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> VendingMachine { get; set; } = new();
}