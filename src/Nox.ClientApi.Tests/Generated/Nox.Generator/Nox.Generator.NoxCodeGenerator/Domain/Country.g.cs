// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace ClientApi.Domain;

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
/// Record for Country deleted event.
/// </summary>
internal record CountryDeleted(Country Country) : IDomainEvent, INotification;

/// <summary>
/// Country Entity Country representation for the Client API tests.
/// </summary>
internal abstract partial class CountryBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// The unique identifier
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// The Country Name     Set a unique name for the country Do not use abbreviations
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Population Number of People living in the country
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.Number? Population { get; set; } = null!;

    /// <summary>
    /// The Money
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.Money? CountryDebt { get; set; } = null!;

    /// <summary>
    /// First Official Language
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.LanguageCode? FirstLanguageCode { get; set; } = null!;

    /// <summary>
    /// The Formula
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public string? ShortDescription
    { 
        get { return $"{Name} has a population of {Population} people."; }
        private set { }
    }

    /// <summary>
    /// Country's iso number id
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.CountryNumber? CountryIsoNumeric { get; set; } = null!;

    /// <summary>
    /// Country's iso alpha3 id
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.CountryCode3? CountryIsoAlpha3 { get; set; } = null!;

    /// <summary>
    /// Country's map via google maps
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.Url? GoogleMapsUrl { get; set; } = null!;

    /// <summary>
    /// Country's start of week day
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.DayOfWeek? StartOfWeek { get; set; } = null!;

    /// <summary>
    /// Country Continent
    /// <remarks>Optional.</remarks>   
    /// </summary>
    public Nox.Types.Enumeration? Continent { get; set; } = null!;
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
		InternalDomainEvents.Add(new CountryDeleted(country));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<Workplace> Workplaces { get; private set; } = new();

    public virtual void CreateRefToWorkplaces(Workplace relatedWorkplace)
    {
        Workplaces.Add(relatedWorkplace);
    }

    public virtual void UpdateRefToWorkplaces(List<Workplace> relatedWorkplace)
    {
        Workplaces.Clear();
        Workplaces.AddRange(relatedWorkplace);
    }

    public virtual void DeleteRefToWorkplaces(Workplace relatedWorkplace)
    {
        Workplaces.Remove(relatedWorkplace);
    }

    public virtual void DeleteAllRefToWorkplaces()
    {
        Workplaces.Clear();
    }

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalName> CountryShortNames { get; private set; } = new();
    
    /// <summary>
    /// Creates a new CountryLocalName entity.
    /// </summary>
    public virtual void CreateRefToCountryShortNames(CountryLocalName relatedCountryLocalName)
    {
        CountryShortNames.Add(relatedCountryLocalName);
    }
    
    /// <summary>
    /// Deletes owned CountryLocalName entity.
    /// </summary>
    public virtual void DeleteRefToCountryShortNames(CountryLocalName relatedCountryLocalName)
    {
        CountryShortNames.Remove(relatedCountryLocalName);
    }
    
    /// <summary>
    /// Deletes all owned CountryLocalName entities.
    /// </summary>
    public virtual void DeleteAllRefToCountryShortNames()
    {
        CountryShortNames.Clear();
    }

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCode? CountryBarCode { get; private set; }
    
    /// <summary>
    /// Creates a new CountryBarCode entity.
    /// </summary>
    public virtual void CreateRefToCountryBarCode(CountryBarCode relatedCountryBarCode)
    {
        CountryBarCode = relatedCountryBarCode;
    }
    
    /// <summary>
    /// Deletes owned CountryBarCode entity.
    /// </summary>
    public virtual void DeleteRefToCountryBarCode(CountryBarCode relatedCountryBarCode)
    {
        CountryBarCode = null;
    }
    
    /// <summary>
    /// Deletes all owned CountryBarCode entities.
    /// </summary>
    public virtual void DeleteAllRefToCountryBarCode()
    {
        CountryBarCode = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}