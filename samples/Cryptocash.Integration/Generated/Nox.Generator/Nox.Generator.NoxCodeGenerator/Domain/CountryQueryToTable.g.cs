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

namespace CryptocashIntegration.Domain;

public partial class CountryQueryToTable : CountryQueryToTableBase, IEntityHaveDomainEvents
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
/// Record for CountryQueryToTable created event.
/// </summary>
public record CountryQueryToTableCreated(CountryQueryToTable CountryQueryToTable) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryQueryToTable updated event.
/// </summary>
public record CountryQueryToTableUpdated(CountryQueryToTable CountryQueryToTable) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryQueryToTable deleted event.
/// </summary>
public record CountryQueryToTableDeleted(CountryQueryToTable CountryQueryToTable) : IDomainEvent, INotification;

/// <summary>
/// Country and related data.
/// </summary>
public abstract partial class CountryQueryToTableBase : EntityBase, IEtag
{
    /// <summary>
    /// Country unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number Id { get;  set; } = null!;

    /// <summary>
    /// Country's name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Country's population    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number Population { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(CountryQueryToTable countryQueryToTable)
	{
		InternalDomainEvents.Add(new CountryQueryToTableCreated(countryQueryToTable));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CountryQueryToTable countryQueryToTable)
	{
		InternalDomainEvents.Add(new CountryQueryToTableUpdated(countryQueryToTable));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CountryQueryToTable countryQueryToTable)
	{
		InternalDomainEvents.Add(new CountryQueryToTableDeleted(countryQueryToTable));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}