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
using Nox.Exceptions;

namespace CryptocashIntegration.Domain;

public partial class CountryQueryToCustomTable : CountryQueryToCustomTableBase, IEntityHaveDomainEvents
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
/// Record for CountryQueryToCustomTable created event.
/// </summary>
public record CountryQueryToCustomTableCreated(CountryQueryToCustomTable CountryQueryToCustomTable) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryQueryToCustomTable updated event.
/// </summary>
public record CountryQueryToCustomTableUpdated(CountryQueryToCustomTable CountryQueryToCustomTable) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryQueryToCustomTable deleted event.
/// </summary>
public record CountryQueryToCustomTableDeleted(CountryQueryToCustomTable CountryQueryToCustomTable) : IDomainEvent, INotification;

/// <summary>
/// Country and related data.
/// </summary>
public abstract partial class CountryQueryToCustomTableBase : EntityBase, IEtag
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
    /// The date on which the country record was created    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.DateTime CreateDate { get;  set; } = null!;

    /// <summary>
    /// The date on which the country record was last updated    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.DateTime? EditDate { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(CountryQueryToCustomTable countryQueryToCustomTable)
	{
		InternalDomainEvents.Add(new CountryQueryToCustomTableCreated(countryQueryToCustomTable));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CountryQueryToCustomTable countryQueryToCustomTable)
	{
		InternalDomainEvents.Add(new CountryQueryToCustomTableUpdated(countryQueryToCustomTable));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CountryQueryToCustomTable countryQueryToCustomTable)
	{
		InternalDomainEvents.Add(new CountryQueryToCustomTableDeleted(countryQueryToCustomTable));
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