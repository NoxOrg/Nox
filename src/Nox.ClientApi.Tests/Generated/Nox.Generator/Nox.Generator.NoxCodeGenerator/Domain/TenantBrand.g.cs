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

internal partial class TenantBrand : TenantBrandBase, IEntityHaveDomainEvents
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
internal record TenantBrandCreated(TenantBrand TenantBrand) :  IDomainEvent, INotification;
/// <summary>
/// Record for TenantBrand updated event.
/// </summary>
internal record TenantBrandUpdated(TenantBrand TenantBrand) : IDomainEvent, INotification;
/// <summary>
/// Record for TenantBrand deleted event.
/// </summary>
internal record TenantBrandDeleted(TenantBrand TenantBrand) : IDomainEvent, INotification;

/// <summary>
/// Tenant Brand.
/// </summary>
internal abstract partial class TenantBrandBase : EntityBase, IOwnedEntity
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Teanant Brand Name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Teanant Brand Description    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Description { get; set; } = null!;
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

}