// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Time zones related to country.
/// </summary>
public partial class CountryTimeZones : AuditableEntityBase
{
    /// <summary>
    /// The country's timezone unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The country's related timezone code (Required).
    /// </summary>
    public Nox.Types.TimeZoneCode TimeZoneCode { get; set; } = null!;

    /// <summary>
    /// CountryTimeZones The country's related timezones ZeroOrMany Countries
    /// </summary>
    public virtual List<Country> Countries { get; set; } = new();

    public List<Country> Country => Countries;
}