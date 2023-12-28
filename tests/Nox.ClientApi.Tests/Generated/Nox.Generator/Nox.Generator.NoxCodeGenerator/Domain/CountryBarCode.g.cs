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

namespace ClientApi.Domain;

internal partial class CountryBarCode : CountryBarCodeBase, IEntityHaveDomainEvents
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
/// Record for CountryBarCode created event.
/// </summary>
internal record CountryBarCodeCreated(CountryBarCode CountryBarCode) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryBarCode updated event.
/// </summary>
internal record CountryBarCodeUpdated(CountryBarCode CountryBarCode) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryBarCode deleted event.
/// </summary>
internal record CountryBarCodeDeleted(CountryBarCode CountryBarCode) : IDomainEvent, INotification;

/// <summary>
/// Bar code for country.
/// </summary>
internal abstract partial class CountryBarCodeBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// The unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber CountryId { get; private set; } = null!;

    /// <summary>
    /// Bar code name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text BarCodeName { get;  set; } = null!;

    /// <summary>
    /// Bar code number    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Number? BarCodeNumber { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(CountryBarCode countryBarCode)
	{
		InternalDomainEvents.Add(new CountryBarCodeCreated(countryBarCode));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CountryBarCode countryBarCode)
	{
		InternalDomainEvents.Add(new CountryBarCodeUpdated(countryBarCode));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CountryBarCode countryBarCode)
	{
		InternalDomainEvents.Add(new CountryBarCodeDeleted(countryBarCode));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    
}