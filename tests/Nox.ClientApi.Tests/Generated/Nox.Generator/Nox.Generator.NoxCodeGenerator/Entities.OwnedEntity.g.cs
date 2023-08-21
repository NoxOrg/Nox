// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// OwnedEntity.
/// </summary>
public partial class OwnedEntity : AuditableEntityBase
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The Text (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;
}