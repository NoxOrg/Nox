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

internal partial class Tenant : TenantBase, IEntityHaveDomainEvents
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
internal record TenantCreated(Tenant Tenant) :  IDomainEvent, INotification;
/// <summary>
/// Record for Tenant updated event.
/// </summary>
internal record TenantUpdated(Tenant Tenant) : IDomainEvent, INotification;
/// <summary>
/// Record for Tenant deleted event.
/// </summary>
internal record TenantDeleted(Tenant Tenant) : IDomainEvent, INotification;

/// <summary>
/// Tenant.
/// </summary>
internal abstract partial class TenantBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Guid Id {get; set;} = null!;
         /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid guid)
    	{
    		if(System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid);
    		}
    	}

    /// <summary>
    /// Teanant Name
    /// <remarks>Required.</remarks>   
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;
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
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}