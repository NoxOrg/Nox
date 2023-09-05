// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Workplace.
/// </summary>
public partial class Workplace : EntityBase, IConcurrent
{
    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public String? Greeting
    { 
        get { return $"Hello, {Name.Value}!"; }
        private set { }
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}