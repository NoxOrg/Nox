// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Holidays related to country.
/// </summary>
public partial class CountryHoliday : AuditableEntityBase
{
    /// <summary>
    /// Country's holiday unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    public Nox.Types.Text Type { get; set; } = null!;

    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    public Nox.Types.Date Date { get; set; } = null!;

    /// <summary>
    /// CountryHoliday Country's holidays ZeroOrMany Holidays
    /// </summary>
    public virtual List<Holidays> Holidays { get; set; } = new();
}