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

public partial class CountryProcToTable : CountryProcToTableBase, IEntityHaveDomainEvents
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
/// Record for CountryProcToTable created event.
/// </summary>
public record CountryProcToTableCreated(CountryProcToTable CountryProcToTable) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryProcToTable updated event.
/// </summary>
public record CountryProcToTableUpdated(CountryProcToTable CountryProcToTable) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryProcToTable deleted event.
/// </summary>
public record CountryProcToTableDeleted(CountryProcToTable CountryProcToTable) : IDomainEvent, INotification;

/// <summary>
/// Country and related data.
/// </summary>
public abstract partial class CountryProcToTableBase : EntityBase, IEtag
{
    /// <summary>
    /// Country unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number CountryId { get;  set; } = null!;

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

	protected virtual void InternalRaiseCreateEvent(CountryProcToTable countryProcToTable)
	{
		InternalDomainEvents.Add(new CountryProcToTableCreated(countryProcToTable));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CountryProcToTable countryProcToTable)
	{
		InternalDomainEvents.Add(new CountryProcToTableUpdated(countryProcToTable));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CountryProcToTable countryProcToTable)
	{
		InternalDomainEvents.Add(new CountryProcToTableDeleted(countryProcToTable));
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