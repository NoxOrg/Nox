// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Holiday related info for a country.
/// </summary>
public partial class Holidays : AuditableEntityBase
{
    /// <summary>
    /// The holiday's unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The holiday's related year (Required).
    /// </summary>
    public Nox.Types.Year Year { get; set; } = null!;

    /// <summary>
    /// The holiday's country related week day off (Required).
    /// </summary>
    public Nox.Types.DayOfWeek DayOff { get; set; } = null!;

    /// <summary>
    /// Holidays The related country ExactlyOne Countries
    /// </summary>
    public virtual Country Country { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Country
    /// </summary>
    public Nox.Types.CountryCode2 CountryId { get; set; } = null!;

    /// <summary>
    /// Holidays The related country holidays ZeroOrMany CountryHolidays
    /// </summary>
    public virtual List<CountryHoliday> CountryHolidays { get; set; } = new();
}