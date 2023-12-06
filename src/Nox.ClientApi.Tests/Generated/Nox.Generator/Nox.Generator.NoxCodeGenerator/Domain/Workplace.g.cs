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

namespace ClientApi.Domain;

internal partial class Workplace : WorkplaceBase, IEntityHaveDomainEvents
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
/// Record for Workplace created event.
/// </summary>
internal record WorkplaceCreated(Workplace Workplace) :  IDomainEvent, INotification;
/// <summary>
/// Record for Workplace updated event.
/// </summary>
internal record WorkplaceUpdated(Workplace Workplace) : IDomainEvent, INotification;
/// <summary>
/// Record for Workplace deleted event.
/// </summary>
internal record WorkplaceDeleted(Workplace Workplace) : IDomainEvent, INotification;

/// <summary>
/// Workplace.
/// </summary>
internal abstract partial class WorkplaceBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    /// Workplace unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Workplace Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Workplace Code    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.ReferenceNumber? ReferenceNumber { get; set; } = null!;

    /// <summary>
    /// Workplace Description    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? Description { get; set; } = null!;

    /// <summary>
    /// The Formula    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public string? Greeting
    { 
        get { return $"Hello, {Name.Value}!"; }
        private set { }
    }

    /// <summary>
    /// Workplace Ownership    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Enumeration? Ownership { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Workplace workplace)
	{
		InternalDomainEvents.Add(new WorkplaceCreated(workplace));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Workplace workplace)
	{
		InternalDomainEvents.Add(new WorkplaceUpdated(workplace));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Workplace workplace)
	{
		InternalDomainEvents.Add(new WorkplaceDeleted(workplace));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    public virtual Country? Country { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Country
    /// </summary>
    public Nox.Types.AutoNumber? CountryId { get; set; } = null!;

    public virtual void CreateRefToCountry(Country relatedCountry)
    {
        Country = relatedCountry;
    }

    public virtual void DeleteRefToCountry(Country relatedCountry)
    {
        Country = null;
    }

    public virtual void DeleteAllRefToCountry()
    {
        CountryId = null;
    }

    /// <summary>
    /// Workplace Actve Tenants in the workplace ZeroOrMany Tenants
    /// </summary>
    public virtual List<Tenant> Tenants { get; private set; } = new();

    public virtual void CreateRefToTenants(Tenant relatedTenant)
    {
        Tenants.Add(relatedTenant);
    }

    public virtual void UpdateRefToTenants(List<Tenant> relatedTenant)
    {
        Tenants.Clear();
        Tenants.AddRange(relatedTenant);
    }

    public virtual void DeleteRefToTenants(Tenant relatedTenant)
    {
        Tenants.Remove(relatedTenant);
    }

    public virtual void DeleteAllRefToTenants()
    {
        Tenants.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}