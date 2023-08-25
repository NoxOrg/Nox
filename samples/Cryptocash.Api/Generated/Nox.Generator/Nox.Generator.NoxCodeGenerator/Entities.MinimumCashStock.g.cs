// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Minimum cash stock required for vending machine.
/// </summary>
public partial class MinimumCashStock : AuditableEntityBase
{
    /// <summary>
    /// The vending machine cash stock unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The amount of the cash stock (Required).
    /// </summary>
    public Nox.Types.Money Amount { get; set; } = null!;

    /// <summary>
    /// MinimumCashStock The related vending machine ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine VendingMachine { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.DatabaseGuid VendingMachineId { get; set; } = null!;

    /// <summary>
    /// MinimumCashStock The currency of the cash stock ExactlyOne Currencies
    /// </summary>
    public virtual Currency Currency { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Currency
    /// </summary>
    public Nox.Types.CurrencyCode3 CurrencyId { get; set; } = null!;
}