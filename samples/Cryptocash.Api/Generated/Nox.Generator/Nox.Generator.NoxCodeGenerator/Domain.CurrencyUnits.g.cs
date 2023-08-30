// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Currencies related units major and minor.
/// </summary>
public partial class CurrencyUnits : AuditableEntityBase
{
    /// <summary>
    /// Currency unit unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Currency's major name (Required).
    /// </summary>
    public Nox.Types.Text MajorName { get; set; } = null!;

    /// <summary>
    /// Currency's major display symbol (Required).
    /// </summary>
    public Nox.Types.Text MajorSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's minor name (Required).
    /// </summary>
    public Nox.Types.Text MinorName { get; set; } = null!;

    /// <summary>
    /// Currency's minor display symbol (Required).
    /// </summary>
    public Nox.Types.Text MinorSymbol { get; set; } = null!;

    /// <summary>
    /// Currency's minor value when converted to major (Required).
    /// </summary>
    public Nox.Types.Money MinorToMajorValue { get; set; } = null!;

    /// <summary>
    /// CurrencyUnits Currency's units ZeroOrMany Currencies
    /// </summary>
    public virtual List<Currency> Currencies { get; set; } = new();

    public List<Currency> Currency => Currencies;
}