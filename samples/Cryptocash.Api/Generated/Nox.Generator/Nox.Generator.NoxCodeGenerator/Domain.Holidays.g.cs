// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Holiday related info for a country.
/// </summary>
public partial class Holidays : AuditableEntityBase
{
    /// <summary>
    /// Holiday's unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Holiday's associated year (Required).
    /// </summary>
    public Nox.Types.Year Year { get; set; } = null!;

    /// <summary>
    /// Week day off associated with holiday's country (Required).
    /// </summary>
    public Nox.Types.DayOfWeek DayOff { get; set; } = null!;

    /// <summary>
    /// Holidays Holiday's country ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    /// <summary>
    /// Holidays Country's holidays ZeroOrMany CountryHolidays
    /// </summary>
    public virtual List<CountryHoliday> CountryHolidays { get; set; } = new();
}