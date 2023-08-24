// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Client DatabaseGuid Key.
/// </summary>
public partial class ClientDatabaseGuid : EntityBase
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// The Text (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;
}