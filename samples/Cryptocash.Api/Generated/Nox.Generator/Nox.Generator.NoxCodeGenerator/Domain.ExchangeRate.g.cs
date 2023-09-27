// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class ExchangeRate:ExchangeRateBase
{

}
/// <summary>
/// Record for ExchangeRate created event.
/// </summary>
internal record ExchangeRateCreated(ExchangeRate ExchangeRate) : IDomainEvent;
/// <summary>
/// Record for ExchangeRate updated event.
/// </summary>
internal record ExchangeRateUpdated(ExchangeRate ExchangeRate) : IDomainEvent;
/// <summary>
/// Record for ExchangeRate deleted event.
/// </summary>
internal record ExchangeRateDeleted(ExchangeRate ExchangeRate) : IDomainEvent;

/// <summary>
/// Exchange rate and related data.
/// </summary>
internal abstract class ExchangeRateBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Exchange rate unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.Number EffectiveRate { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.DateTime EffectiveAt { get; set; } = null!;

}