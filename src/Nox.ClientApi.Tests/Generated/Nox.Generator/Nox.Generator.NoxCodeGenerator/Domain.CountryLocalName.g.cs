// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;

internal partial class CountryLocalName : CountryLocalNameBase, IEntityHaveDomainEvents
{
	///<inheritdoc/>
	public void RaiseCreateEvent()
	{
		InternalRaiseCreateEvent(this);
	}
	///<inheritdoc/>
	public void RaiseDeleteEvent()
	{
		InternalRaiseDeleteEvent(this);
	}
	///<inheritdoc/>
	public void RaiseUpdateEvent()
	{
		InternalRaiseUpdateEvent(this);
	}
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
internal abstract partial class CountryLocalNameBase : EntityBase, IOwnedEntity
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
	/// <summary>
	/// Domain events raised by this entity.
	/// </summary>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
	protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(CountryLocalName countryLocalName)
	{
		InternalDomainEvents.Add(new CountryLocalNameCreated(countryLocalName));
	}
	
	protected virtual void InternalRaiseUpdateEvent(CountryLocalName countryLocalName)
	{
		InternalDomainEvents.Add(new CountryLocalNameUpdated(countryLocalName));
	}
	
	protected virtual void InternalRaiseDeleteEvent(CountryLocalName countryLocalName)
	{
		InternalDomainEvents.Add(new CountryLocalNameDeleted(countryLocalName));
	}
	/// <summary>
	/// Clears all domain events associated with the entity.
	/// </summary>
    public virtual void ClearDomainEvents()
	{
		InternalDomainEvents.Clear();
	}

}