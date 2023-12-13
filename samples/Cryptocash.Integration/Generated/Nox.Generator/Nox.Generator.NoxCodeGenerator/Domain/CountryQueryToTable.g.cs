﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;

namespace CryptocashIntegration.Domain;

internal partial class CountryQueryToTable : CountryQueryToTableBase, IEntityHaveDomainEvents
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
internal record CountryQueryToTableCreated(CountryQueryToTable CountryQueryToTable) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryQueryToTable updated event.
/// </summary>
internal record CountryQueryToTableUpdated(CountryQueryToTable CountryQueryToTable) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryQueryToTable deleted event.
/// </summary>
internal record CountryQueryToTableDeleted(CountryQueryToTable CountryQueryToTable) : IDomainEvent, INotification;

/// <summary>
/// Country and related data.
/// </summary>
internal abstract partial class CountryQueryToTableBase : EntityBase, IEntityConcurrent
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