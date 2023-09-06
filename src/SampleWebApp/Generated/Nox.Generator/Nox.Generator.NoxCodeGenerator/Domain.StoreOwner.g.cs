// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace SampleWebApp.Domain;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwner : AuditableEntityBase, IConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<Store> StoreRel { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}