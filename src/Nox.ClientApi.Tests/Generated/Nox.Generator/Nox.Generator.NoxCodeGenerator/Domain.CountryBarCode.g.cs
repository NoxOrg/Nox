// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;
public partial class CountryBarCode:CountryBarCodeBase
{

}
/// <summary>
/// Bar code for country.
/// </summary>
public abstract class CountryBarCodeBase : EntityBase, IOwnedEntity
{

    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    public Nox.Types.Text BarCodeName { get; set; } = null!;

    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public Nox.Types.Number? BarCodeNumber { get; set; } = null!;

}