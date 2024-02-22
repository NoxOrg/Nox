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

public partial class CountryLocalName : CountryLocalNameBase, IEntityHaveDomainEvents
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
/// Record for CountryLocalName created event.
/// </summary>
public record CountryLocalNameCreated(CountryLocalName CountryLocalName) :  IDomainEvent, INotification;
/// <summary>
/// Record for CountryLocalName updated event.
/// </summary>
public record CountryLocalNameUpdated(CountryLocalName CountryLocalName) : IDomainEvent, INotification;
/// <summary>
/// Record for CountryLocalName deleted event.
/// </summary>
public record CountryLocalNameDeleted(CountryLocalName CountryLocalName) : IDomainEvent, INotification;

/// <summary>
/// Local names for countries.
/// </summary>
public abstract partial class CountryLocalNameBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// The unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// Local name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Local name in native tongue    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? NativeName { get;  set; } = null!;

    /// <summary>
    /// Description    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? Description { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(CountryLocalName countryLocalName)
	{
		InternalDomainEvents.Add(new CountryLocalNameCreated(countryLocalName));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CountryLocalName countryLocalName)
	{
		InternalDomainEvents.Add(new CountryLocalNameUpdated(countryLocalName));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CountryLocalName countryLocalName)
	{
		InternalDomainEvents.Add(new CountryLocalNameDeleted(countryLocalName));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

        /// <summary>
        /// CountryLocalName localized entities.
        /// </summary>
        public virtual List<CountryLocalNameLocalized> LocalizedCountryLocalNames  { get; private set; } = new();
    
    
    	/// <summary>
    	/// Creates a new CountryLocalNameLocalized entity.
    	/// </summary>
        public virtual void CreateRefToLocalizedCountryLocalNames(CountryLocalNameLocalized relatedCountryLocalNameLocalized)
    	{
    		LocalizedCountryLocalNames.Add(relatedCountryLocalNameLocalized);
    	}
        
}