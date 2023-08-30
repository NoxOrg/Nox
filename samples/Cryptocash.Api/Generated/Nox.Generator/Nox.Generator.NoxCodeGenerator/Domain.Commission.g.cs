// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class Commission : AuditableEntityBase
{
    /// <summary>
    /// The commission unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The commission rate (Required).
    /// </summary>
    public Nox.Types.Percentage Rate { get; set; } = null!;

    /// <summary>
    /// The exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.DateTime EffectiveAt { get; set; } = null!;

    /// <summary>
    /// Commission The commission related country ZeroOrOne Countries
    /// </summary>
    public virtual Country? Country { get; set; } = null!;

    /// <summary>
    /// Commission The booking's related fee ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> Bookings { get; set; } = new();

    public List<Booking> Booking => Bookings;
}