// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class CountryLocalName:CountryLocalNameBase
{

}
/// <summary>
/// Record for CountryLocalName created event.
/// </summary>
internal record CountryLocalNameCreated(CountryLocalNameBase CountryLocalName) : IDomainEvent;
/// <summary>
/// Record for CountryLocalName updated event.
/// </summary>
internal record CountryLocalNameUpdated(CountryLocalNameBase CountryLocalName) : IDomainEvent;
/// <summary>
/// Record for CountryLocalName deleted event.
/// </summary>
internal record CountryLocalNameDeleted(CountryLocalNameBase CountryLocalName) : IDomainEvent;

/// <summary>
/// Local names for countries.
/// </summary>
internal abstract class CountryLocalNameBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	protected readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new CountryLocalNameCreated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new CountryLocalNameUpdated(this));
	}
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new CountryLocalNameDeleted(this));
	}
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}