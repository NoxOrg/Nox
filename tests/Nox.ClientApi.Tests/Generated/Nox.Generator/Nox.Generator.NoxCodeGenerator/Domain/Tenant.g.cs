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

public partial class Tenant : TenantBase, IEntityHaveDomainEvents
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
/// Record for Tenant created event.
/// </summary>
public record TenantCreated(Tenant Tenant) :  IDomainEvent, INotification;
/// <summary>
/// Record for Tenant updated event.
/// </summary>
public record TenantUpdated(Tenant Tenant) : IDomainEvent, INotification;
/// <summary>
/// Record for Tenant deleted event.
/// </summary>
public record TenantDeleted(Tenant Tenant) : IDomainEvent, INotification;

/// <summary>
/// Tenant.
/// </summary>
public abstract partial class TenantBase : EntityBase, IEtag
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nuid Id {get; private set; } = null!;
       
    	public virtual void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("Tenant-" + string.Join("-", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("Tenant-" + string.Join("-", Name.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// Teanant Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Tenant Status    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Enumeration? Status { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Tenant tenant)
	{
		InternalDomainEvents.Add(new TenantCreated(tenant));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Tenant tenant)
	{
		InternalDomainEvents.Add(new TenantUpdated(tenant));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Tenant tenant)
	{
		InternalDomainEvents.Add(new TenantDeleted(tenant));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Tenant Workplaces where the tenant is active ZeroOrMany Workplaces
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
    }﻿

    /// <summary>
    /// Tenant Brands owned by the tenant ZeroOrMany TenantBrands
    /// </summary>
    public virtual List<TenantBrand> TenantBrands { get; private set; } = new();
    
    /// <summary>
    /// Creates a new TenantBrand entity.
    /// </summary>
    public virtual void CreateTenantBrands(TenantBrand relatedTenantBrand)
    {
        TenantBrands.Add(relatedTenantBrand);
    }
    
    /// <summary>
    /// Updates all owned TenantBrand entities.
    /// </summary>
    public virtual void UpdateTenantBrands(List<TenantBrand> relatedTenantBrand)
    {
        TenantBrands.Clear();
        TenantBrands.AddRange(relatedTenantBrand);
    }
    
    /// <summary>
    /// Deletes owned TenantBrand entity.
    /// </summary>
    public virtual void DeleteTenantBrands(TenantBrand relatedTenantBrand)
    {
        TenantBrands.Remove(relatedTenantBrand);
    }
    
    /// <summary>
    /// Deletes all owned TenantBrand entities.
    /// </summary>
    public virtual void DeleteAllTenantBrands()
    {
        TenantBrands.Clear();
    }﻿

    /// <summary>
    /// Tenant Contact information for the tenant ZeroOrOne TenantContacts
    /// </summary>
    public virtual TenantContact? TenantContact { get; private set; }
    
    /// <summary>
    /// Creates a new TenantContact entity.
    /// </summary>
    public virtual void CreateTenantContact(TenantContact relatedTenantContact)
    {
        TenantContact = relatedTenantContact;
    }
    
    /// <summary>
    /// Deletes owned TenantContact entity.
    /// </summary>
    public virtual void DeleteTenantContact(TenantContact relatedTenantContact)
    {
        TenantContact = null;
    }
    
    /// <summary>
    /// Deletes all owned TenantContact entities.
    /// </summary>
    public virtual void DeleteAllTenantContact()
    {
        TenantContact = null;
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}