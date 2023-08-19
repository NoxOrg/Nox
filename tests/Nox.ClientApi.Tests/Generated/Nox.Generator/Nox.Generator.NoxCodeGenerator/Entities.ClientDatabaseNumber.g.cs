// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Client DatabaseNumber Key.
/// </summary>
public partial class ClientDatabaseNumber : AuditableEntityBase
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;
}