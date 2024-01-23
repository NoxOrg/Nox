// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;
using Nox.Exceptions;

namespace Cryptocash.Domain;

public partial class ExchangeRate : ExchangeRateBase, IEntityHaveDomainEvents
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
/// Record for ExchangeRate created event.
/// </summary>
public record ExchangeRateCreated(ExchangeRate ExchangeRate) :  IDomainEvent, INotification;
/// <summary>
/// Record for ExchangeRate updated event.
/// </summary>
public record ExchangeRateUpdated(ExchangeRate ExchangeRate) : IDomainEvent, INotification;
/// <summary>
/// Record for ExchangeRate deleted event.
/// </summary>
public record ExchangeRateDeleted(ExchangeRate ExchangeRate) : IDomainEvent, INotification;

/// <summary>
/// Exchange rate and related data.
/// </summary>
public abstract partial class ExchangeRateBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Exchange rate unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number EffectiveRate { get;  set; } = null!;

    /// <summary>
    /// Exchange rate conversion amount    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.DateTime EffectiveAt { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(ExchangeRate exchangeRate)
	{
		InternalDomainEvents.Add(new ExchangeRateCreated(exchangeRate));
    }
	
	protected virtual void InternalRaiseUpdateEvent(ExchangeRate exchangeRate)
	{
		InternalDomainEvents.Add(new ExchangeRateUpdated(exchangeRate));
    }
	
	protected virtual void InternalRaiseDeleteEvent(ExchangeRate exchangeRate)
	{
		InternalDomainEvents.Add(new ExchangeRateDeleted(exchangeRate));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
}