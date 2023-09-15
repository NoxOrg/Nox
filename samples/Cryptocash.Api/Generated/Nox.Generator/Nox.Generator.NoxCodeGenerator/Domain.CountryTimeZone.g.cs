// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class CountryTimeZone:CountryTimeZoneBase
{

}
/// <summary>
/// Record for CountryTimeZone created event.
/// </summary>
public record CountryTimeZoneCreated(CountryTimeZone CountryTimeZone) : IDomainEvent;
/// <summary>
/// Record for CountryTimeZone updated event.
/// </summary>
public record CountryTimeZoneUpdated(CountryTimeZone CountryTimeZone) : IDomainEvent;
/// <summary>
/// Record for CountryTimeZone deleted event.
/// </summary>
public record CountryTimeZoneDeleted(CountryTimeZone CountryTimeZone) : IDomainEvent;

/// <summary>
/// Time zone related to country.
/// </summary>
public abstract class CountryTimeZoneBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Country's time zone unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    public Nox.Types.TimeZoneCode TimeZoneCode { get; set; } = null!;

}