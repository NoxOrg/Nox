// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public partial class Commission : AuditableEntityBase
{
    /// <summary>
    /// Commission unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Commission rate (Required).
    /// </summary>
    public Nox.Types.Percentage Rate { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.DateTime EffectiveAt { get; set; } = null!;

    /// <summary>
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    public virtual Country? CommissionFeesForCountry { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2? CommissionFeesForCountryId { get; set; } = null!;

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    public virtual List<Booking> CommissionFeesForBooking { get; set; } = new();
}