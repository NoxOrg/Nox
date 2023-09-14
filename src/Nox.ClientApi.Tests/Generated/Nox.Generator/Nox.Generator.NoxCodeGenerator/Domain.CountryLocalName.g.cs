// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;
public partial class CountryLocalName:CountryLocalNameBase
{

}
/// <summary>
/// Record for CountryLocalName created event.
/// </summary>
public record CountryLocalNameCreated(CountryLocalName CountryLocalName) : IDomainEvent;

/// <summary>
/// Record for CountryLocalName updated event.
/// </summary>
public record CountryLocalNameUpdated(CountryLocalName CountryLocalName) : IDomainEvent;

/// <summary>
/// Record for CountryLocalName deleted event.
/// </summary>
public record CountryLocalNameDeleted(CountryLocalName CountryLocalName) : IDomainEvent;

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