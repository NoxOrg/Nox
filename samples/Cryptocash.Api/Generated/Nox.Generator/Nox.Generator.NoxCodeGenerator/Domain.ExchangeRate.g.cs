// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class ExchangeRate:ExchangeRateBase
{

}
/// <summary>
/// Record for ExchangeRate created event.
/// </summary>
public record ExchangeRateCreated(ExchangeRateBase ExchangeRate) : IDomainEvent;
/// <summary>
/// Record for ExchangeRate updated event.
/// </summary>
public record ExchangeRateUpdated(ExchangeRateBase ExchangeRate) : IDomainEvent;
/// <summary>
/// Record for ExchangeRate deleted event.
/// </summary>
public record ExchangeRateDeleted(ExchangeRateBase ExchangeRate) : IDomainEvent;

/// <summary>
/// Exchange rate and related data.
/// </summary>
public abstract class ExchangeRateBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{
    /// <summary>
    /// Exchange rate unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.Number EffectiveRate { get; set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public Nox.Types.DateTime EffectiveAt { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new ExchangeRateCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new ExchangeRateUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new ExchangeRateDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}