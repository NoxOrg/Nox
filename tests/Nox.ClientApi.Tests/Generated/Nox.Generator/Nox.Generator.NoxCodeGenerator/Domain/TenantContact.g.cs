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

namespace ClientApi.Domain;

public partial class TenantContact : TenantContactBase, IEntityHaveDomainEvents
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
/// Record for TenantContact created event.
/// </summary>
public record TenantContactCreated(TenantContact TenantContact) :  IDomainEvent, INotification;
/// <summary>
/// Record for TenantContact updated event.
/// </summary>
public record TenantContactUpdated(TenantContact TenantContact) : IDomainEvent, INotification;
/// <summary>
/// Record for TenantContact deleted event.
/// </summary>
public record TenantContactDeleted(TenantContact TenantContact) : IDomainEvent, INotification;

/// <summary>
/// Tenant Contact.
/// </summary>
public abstract partial class TenantContactBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nuid TenantId {get; private set; } = null!;
       
    	public virtual void EnsureTenantId()
    	{
    		if(TenantId is null)
    		{
    			TenantId = Nuid.From("TenantContact-" + string.Join("-", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("TenantContact-" + string.Join("-", Name.Value.ToString()));
    			if(TenantId != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property TenantId value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// Teanant Brand Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get;  set; } = null!;

    /// <summary>
    /// Teanant Brand Description    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Description { get;  set; } = null!;

    /// <summary>
    /// Teanant Brand Email    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Email Email { get;  set; } = null!;

    /// <summary>
    /// Tenant Contact Status    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Enumeration? Status { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TenantContact tenantContact)
	{
		InternalDomainEvents.Add(new TenantContactCreated(tenantContact));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TenantContact tenantContact)
	{
		InternalDomainEvents.Add(new TenantContactUpdated(tenantContact));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TenantContact tenantContact)
	{
		InternalDomainEvents.Add(new TenantContactDeleted(tenantContact));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

        /// <summary>
        /// TenantContact localized entities.
        /// </summary>
        public virtual List<TenantContactLocalized> LocalizedTenantContacts  { get; private set; } = new();
    
    
    	/// <summary>
    	/// Creates a new TenantContactLocalized entity.
    	/// </summary>
        public virtual void CreateRefToLocalizedTenantContacts(TenantContactLocalized relatedTenantContactLocalized)
    	{
    		LocalizedTenantContacts.Add(relatedTenantContactLocalized);
    	}
        
}