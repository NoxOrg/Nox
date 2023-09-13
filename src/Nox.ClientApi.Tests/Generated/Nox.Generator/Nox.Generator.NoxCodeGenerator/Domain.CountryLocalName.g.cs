// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalName : EntityBase, IOwnedEntity
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Local name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Local name in native tongue (Optional).
    /// </summary>
    public Nox.Types.Text? NativeName { get; set; } = null!;

}