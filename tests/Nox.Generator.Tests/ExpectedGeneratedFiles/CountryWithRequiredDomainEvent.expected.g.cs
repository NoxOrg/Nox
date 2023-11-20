// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace SampleWebApp.Domain;

internal partial class Country : CountryBase, IEntityHaveDomainEvents
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
/// Record for Country created event.
/// </summary>
internal record CountryCreated(Country Country) :  IDomainEvent, INotification;
/// <summary>
/// Record for Country updated event.
/// </summary>
internal record CountryUpdated(Country Country) : IDomainEvent, INotification;

/// <summary>
/// The list of countries.
/// </summary>
internal abstract partial class CountryBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get; set; } = null!;

    /// <summary>
    /// The country's common name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The country's official name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text FormalName { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text AlphaCode3 { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-2 code    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text AlphaCode2 { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number NumericCode { get; set; } = null!;

    /// <summary>
    /// The country's phone dialing codes (comma-delimited)    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? DialingCodes { get; set; } = null!;

    /// <summary>
    /// The capital city of the country    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? Capital { get; set; } = null!;

    /// <summary>
    /// Noun denoting the natives of the country    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? Demonym { get; set; } = null!;

    /// <summary>
    /// Country area in square kilometers    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number AreaInSquareKilometres { get; set; } = null!;

    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.LatLong? GeoCoord { get; set; } = null!;

    /// <summary>
    /// The region the country is in    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text GeoRegion { get; set; } = null!;

    /// <summary>
    /// The sub-region the country is in    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text GeoSubRegion { get; set; } = null!;

    /// <summary>
    /// The world region the country is in    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text GeoWorldRegion { get; set; } = null!;

    /// <summary>
    /// The estimated population of the country    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Number? Population { get; set; } = null!;

    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited)    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? TopLevelDomains { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Country country)
	{
		InternalDomainEvents.Add(new CountryCreated(country));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Country country)
	{
		InternalDomainEvents.Add(new CountryUpdated(country));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Country country)
	{
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