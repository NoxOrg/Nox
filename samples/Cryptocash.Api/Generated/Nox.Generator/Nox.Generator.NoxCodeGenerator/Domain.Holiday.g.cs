// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;

public partial class Holiday : HolidayBase
{

}
/// <summary>
/// Record for Holiday created event.
/// </summary>
public record HolidayCreated(Holiday Holiday) : IDomainEvent;
/// <summary>
/// Record for Holiday updated event.
/// </summary>
public record HolidayUpdated(Holiday Holiday) : IDomainEvent;
/// <summary>
/// Record for Holiday deleted event.
/// </summary>
public record HolidayDeleted(Holiday Holiday) : IDomainEvent;

/// <summary>
/// Holiday related to country.
/// </summary>
public abstract class HolidayBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Country's holiday unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    public Nox.Types.Text Type { get; set; } = null!;

    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    public Nox.Types.Date Date { get; set; } = null!;

}