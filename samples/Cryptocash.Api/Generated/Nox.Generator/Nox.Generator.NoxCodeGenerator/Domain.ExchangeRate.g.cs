// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;

/// <summary>
/// Record for ExchangeRate created event.
/// </summary>
public record ExchangeRateCreated(ExchangeRate ExchangeRate) : IDomainEvent;

/// <summary>
/// Record for ExchangeRate updated event.
/// </summary>
public record ExchangeRateUpdated(ExchangeRate ExchangeRate) : IDomainEvent;

/// <summary>
/// Record for ExchangeRate deleted event.
/// </summary>
public record ExchangeRateDeleted(ExchangeRate ExchangeRate) : IDomainEvent;

/// <summary>
/// Exchange rate and related data.
/// </summary>
public partial class ExchangeRate : EntityBase, IOwnedEntity
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