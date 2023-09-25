// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
public partial class CountryLocalName:CountryLocalNameBase
{

}
/// <summary>
/// Record for CountryLocalName created event.
/// </summary>
public record CountryLocalNameCreated(CountryLocalNameBase CountryLocalName) : IDomainEvent;
/// <summary>
/// Record for CountryLocalName updated event.
/// </summary>
public record CountryLocalNameUpdated(CountryLocalNameBase CountryLocalName) : IDomainEvent;
/// <summary>
/// Record for CountryLocalName deleted event.
/// </summary>
public record CountryLocalNameDeleted(CountryLocalNameBase CountryLocalName) : IDomainEvent;

/// <summary>
/// Local names for countries.
/// </summary>
public abstract class CountryLocalNameBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
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

	private readonly List<IDomainEvent> _domainEvents = new();
	
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