// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Country Entity.
/// </summary>
public partial class Country : AuditableEntityBase
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Population (Optional).
    /// </summary>
    public Nox.Types.Number? Population { get; set; } = null!;

    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public Nox.Types.Money? AmmountMoney { get; set; } = null!;

    /// <summary>
    /// Country is also know as ZeroOrMany OwnedEntities
    /// </summary>
    public virtual List<OwnedEntity> OwnedEntities { get; set; } = new();

    public List<OwnedEntity> OwnedEntity => OwnedEntities;
}