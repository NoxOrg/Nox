// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Land Lord related data.
/// </summary>
public partial class LandLord : AuditableEntityBase
{
    /// <summary>
    /// The Land Lord unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The Land Lord name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The Land Lord's address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// LandLord The Land Lord related to the area of the vending machine installation ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<VendingMachine> VendingMachines { get; set; } = new();

    public List<VendingMachine> VendingMachine => VendingMachines;
}