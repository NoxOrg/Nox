// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;

internal partial class CountryLocalName : CountryLocalNameBase
{

}
/// <summary>
/// Record for CountryLocalName created event.
/// </summary>
internal record CountryLocalNameCreated(CountryLocalName CountryLocalName) : IDomainEvent;
/// <summary>
/// Record for CountryLocalName updated event.
/// </summary>
internal record CountryLocalNameUpdated(CountryLocalName CountryLocalName) : IDomainEvent;
/// <summary>
/// Record for CountryLocalName deleted event.
/// </summary>
internal record CountryLocalNameDeleted(CountryLocalName CountryLocalName) : IDomainEvent;

/// <summary>
/// Local names for countries.
/// </summary>
internal abstract class CountryLocalNameBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Local name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Local name in native tongue (Optional).
    /// </summary>
    public Nox.Types.Text? NativeName { get; set; } = null!;

}