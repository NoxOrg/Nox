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

public partial class Workplace : WorkplaceBase, IEntityHaveDomainEvents
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
public record WorkplaceCreated(Workplace Workplace) :  IDomainEvent, INotification;
/// <summary>
/// Record for Workplace updated event.
/// </summary>
public record WorkplaceUpdated(Workplace Workplace) : IDomainEvent, INotification;
/// <summary>
/// Record for Workplace deleted event.
/// </summary>
public record WorkplaceDeleted(Workplace Workplace) : IDomainEvent, INotification;

/// <summary>
/// Workplace.
/// </summary>
public abstract partial class WorkplaceBase : AuditableEntityBase, IEtag
{
    /// <summary>
    /// Workplace unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// Workplace Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Workplace Code    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.ReferenceNumber ReferenceNumber {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Reference Number is set. This should only be called when creating a new entity, it's immutable property.
        /// </summary>
    	public virtual void EnsureReferenceNumber(System.Int64 number, Nox.Types.ReferenceNumberTypeOptions typeOptions)
    	{
    		ReferenceNumber = Nox.Types.ReferenceNumber.From(number, typeOptions);
    	}

    /// <summary>
    /// Workplace Description    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Text? Description { get;  set; } = null!;

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
    public Nox.Types.Enumeration? Ownership { get;  set; } = null!;

    /// <summary>
    /// Workplace Type    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Enumeration? Type { get;  set; } = null!;
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
    }﻿

    /// <summary>
    /// Workplace Workplace Addresses ZeroOrMany WorkplaceAddresses
    /// </summary>
    public virtual List<WorkplaceAddress> WorkplaceAddresses { get; private set; } = new();
    
    /// <summary>
    /// Creates a new WorkplaceAddress entity.
    /// </summary>
    public virtual void CreateWorkplaceAddresses(WorkplaceAddress relatedWorkplaceAddress)
    {
        WorkplaceAddresses.Add(relatedWorkplaceAddress);
    }
    
    /// <summary>
    /// Updates all owned WorkplaceAddress entities.
    /// </summary>
    public virtual void UpdateWorkplaceAddresses(List<WorkplaceAddress> relatedWorkplaceAddress)
    {
        WorkplaceAddresses.Clear();
        WorkplaceAddresses.AddRange(relatedWorkplaceAddress);
    }
    
    /// <summary>
    /// Deletes owned WorkplaceAddress entity.
    /// </summary>
    public virtual void DeleteWorkplaceAddresses(WorkplaceAddress relatedWorkplaceAddress)
    {
        WorkplaceAddresses.Remove(relatedWorkplaceAddress);
    }
    
    /// <summary>
    /// Deletes all owned WorkplaceAddress entities.
    /// </summary>
    public virtual void DeleteAllWorkplaceAddresses()
    {
        WorkplaceAddresses.Clear();
    }

        /// <summary>
        /// Workplace localized entities.
        /// </summary>
        public virtual List<WorkplaceLocalized> LocalizedWorkplaces  { get; private set; } = new();
    
    
    	/// <summary>
    	/// Creates a new WorkplaceLocalized entity.
    	/// </summary>
        public virtual void CreateRefToLocalizedWorkplaces(WorkplaceLocalized relatedWorkplaceLocalized)
    	{
    		LocalizedWorkplaces.Add(relatedWorkplaceLocalized);
    	}
        
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}