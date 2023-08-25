// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Holidays related to country.
/// </summary>
public partial class CountryHoliday : AuditableEntityBase
{
    /// <summary>
    /// The country's holiday unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The country holiday name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The country holiday type (Required).
    /// </summary>
    public Nox.Types.Text Type { get; set; } = null!;

    /// <summary>
    /// The country holiday date (Required).
    /// </summary>
    public Nox.Types.Date Date { get; set; } = null!;

    /// <summary>
    /// CountryHoliday The related country holidays ZeroOrMany Holidays
    /// </summary>
    public virtual List<Holidays> Holidays { get; set; } = new();
}