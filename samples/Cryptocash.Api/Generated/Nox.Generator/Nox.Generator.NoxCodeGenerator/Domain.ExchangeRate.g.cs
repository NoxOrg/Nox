// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;
public partial class ExchangeRate:ExchangeRateBase
{

}
/// <summary>
/// Exchange rate and related data.
/// </summary>
public abstract class ExchangeRateBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Exchange rate unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.Number EffectiveRate { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.DateTime EffectiveAt { get; set; } = null!;

}