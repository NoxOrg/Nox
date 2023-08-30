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
    /// CountryTimeZones Country's time zones ZeroOrMany Countries
    /// </summary>
    public virtual List<Country> Countries { get; set; } = new();

    public List<Country> Country => Countries;
}