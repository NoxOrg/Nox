// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Vending machines.
/// </summary>
public partial class VendingMachine : AuditableEntityBase
{
    /// <summary>
    /// Vending machine Primary Key (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Vending machine Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Vending machine's address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Vending machine' location coordinates (Required).
    /// </summary>
    public Nox.Types.LatLong LatLong { get; set; } = null!;

    /// <summary>
    /// Vending machine's support number (Required).
    /// </summary>
    public Nox.Types.Text SupportNumber { get; set; } = null!;
}