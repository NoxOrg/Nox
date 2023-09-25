// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;
public partial class CountryBarCode:CountryBarCodeBase
{

}
/// <summary>
/// Record for CountryBarCode created event.
/// </summary>
public record CountryBarCodeCreated(CountryBarCodeBase CountryBarCode) : IDomainEvent;
/// <summary>
/// Record for CountryBarCode updated event.
/// </summary>
public record CountryBarCodeUpdated(CountryBarCodeBase CountryBarCode) : IDomainEvent;
/// <summary>
/// Record for CountryBarCode deleted event.
/// </summary>
public record CountryBarCodeDeleted(CountryBarCodeBase CountryBarCode) : IDomainEvent;

/// <summary>
/// Bar code for country.
/// </summary>
public abstract class CountryBarCodeBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{

    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    public Nox.Types.Text BarCodeName { get; set; } = null!;

    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public Nox.Types.Number? BarCodeNumber { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new CountryBarCodeCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new CountryBarCodeUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new CountryBarCodeDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}