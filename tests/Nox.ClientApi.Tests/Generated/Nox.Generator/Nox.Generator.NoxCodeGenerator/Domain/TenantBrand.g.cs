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

public partial class TenantBrand : TenantBrandBase, IEntityHaveDomainEvents
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
/// Record for TenantBrand created event.
/// </summary>
public record TenantBrandCreated(TenantBrand TenantBrand) :  IDomainEvent, INotification;
/// <summary>
/// Record for TenantBrand updated event.
/// </summary>
public record TenantBrandUpdated(TenantBrand TenantBrand) : IDomainEvent, INotification;
/// <summary>
/// Record for TenantBrand deleted event.
/// </summary>
public record TenantBrandDeleted(TenantBrand TenantBrand) : IDomainEvent, INotification;

/// <summary>
/// Tenant Brand.
/// </summary>
public abstract partial class TenantBrandBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

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
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TenantBrand tenantBrand)
	{
		InternalDomainEvents.Add(new TenantBrandCreated(tenantBrand));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TenantBrand tenantBrand)
	{
		InternalDomainEvents.Add(new TenantBrandUpdated(tenantBrand));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TenantBrand tenantBrand)
	{
		InternalDomainEvents.Add(new TenantBrandDeleted(tenantBrand));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

        /// <summary>
        /// TenantBrand localized entities.
        /// </summary>
        public virtual List<TenantBrandLocalized> LocalizedTenantBrands  { get; private set; } = new();
    
    
    	/// <summary>
    	/// Creates a new TenantBrandLocalized entity.
    	/// </summary>
        public virtual void CreateRefToLocalizedTenantBrands(TenantBrandLocalized relatedTenantBrandLocalized)
    	{
    		LocalizedTenantBrands.Add(relatedTenantBrandLocalized);
    	}
        
}