// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public partial class BankNote : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Currency bank note unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// Currency's cash bank note identifier (Required).
    /// </summary>
    public Nox.Types.Text CashNote { get; set; } = null!;

    /// <summary>
    /// Bank note value (Required).
    /// </summary>
    public Nox.Types.Money Value { get; set; } = null!;
}