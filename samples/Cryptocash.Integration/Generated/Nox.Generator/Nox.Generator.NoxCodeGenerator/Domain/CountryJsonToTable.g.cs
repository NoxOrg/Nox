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

internal partial class CountryJsonToTable : CountryJsonToTableBase, IEntityHaveDomainEvents
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
/// Record for CountryJsonToTable created event.
/// </summary>
internal record CountryJsonToTableCreated(CountryJsonToTable CountryJsonToTable) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryJsonToTable updated event.
/// </summary>
internal record CountryJsonToTableUpdated(CountryJsonToTable CountryJsonToTable) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryJsonToTable deleted event.
/// </summary>
internal record CountryJsonToTableDeleted(CountryJsonToTable CountryJsonToTable) : IDomainEvent, INotification;

/// <summary>
/// Country and related data for Json file integration.
/// </summary>
internal abstract partial class CountryJsonToTableBase : EntityBase, IEntityConcurrent
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

	protected virtual void InternalRaiseCreateEvent(CountryJsonToTable countryJsonToTable)
	{
		InternalDomainEvents.Add(new CountryJsonToTableCreated(countryJsonToTable));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CountryJsonToTable countryJsonToTable)
	{
		InternalDomainEvents.Add(new CountryJsonToTableUpdated(countryJsonToTable));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CountryJsonToTable countryJsonToTable)
	{
		InternalDomainEvents.Add(new CountryJsonToTableDeleted(countryJsonToTable));
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