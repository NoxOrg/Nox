// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;
public partial class CountryLocalName:CountryLocalNameBase
{

}
/// <summary>
/// Local names for countries.
/// </summary>
public abstract class CountryLocalNameBase : EntityBase, IOwnedEntity
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