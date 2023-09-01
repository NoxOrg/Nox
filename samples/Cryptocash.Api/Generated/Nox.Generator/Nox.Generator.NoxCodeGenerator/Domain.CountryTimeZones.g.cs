// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Time zones related to country.
/// </summary>
public partial class CountryTimeZones : AuditableEntityBase
{
    /// <summary>
    /// Country's time zone unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    public Nox.Types.TimeZoneCode TimeZoneCode { get; set; } = null!;

    /// <summary>
    /// CountryTimeZones Country's time zones ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;
}