// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class CountryTimeZone:CountryTimeZoneBase
{

}
/// <summary>
/// Record for CountryTimeZone created event.
/// </summary>
internal record CountryTimeZoneCreated(CountryTimeZone CountryTimeZone) : IDomainEvent;
/// <summary>
/// Record for CountryTimeZone updated event.
/// </summary>
internal record CountryTimeZoneUpdated(CountryTimeZone CountryTimeZone) : IDomainEvent;
/// <summary>
/// Record for CountryTimeZone deleted event.
/// </summary>
internal record CountryTimeZoneDeleted(CountryTimeZone CountryTimeZone) : IDomainEvent;

/// <summary>
/// Time zone related to country.
/// </summary>
internal abstract class CountryTimeZoneBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Country's time zone unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Country's related time zone code (Required).
    /// </summary>
    public Nox.Types.TimeZoneCode TimeZoneCode { get; set; } = null!;

}