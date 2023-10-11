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
    /// Workplace unique identifier (Required).
    /// </summary>
    public Nuid Id {get; set;} = null!;
    
    	public virtual void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("Workplace-" + string.Join("-", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("Workplace-" + string.Join("-", Name.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public Nox.Types.Text? Description { get; set; } = null!;

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public string? Greeting
    { 
        get { return $"Hello, {Name.Value}!"; }
        private set { }
    }
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
    public virtual Country? BelongsToCountry { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Country
    /// </summary>
    public Nox.Types.AutoNumber? BelongsToCountryId { get; set; } = null!;

    public virtual void CreateRefToBelongsToCountry(Country relatedCountry)
    {
        BelongsToCountry = relatedCountry;
    }

    public virtual void DeleteRefToBelongsToCountry(Country relatedCountry)
    {
        BelongsToCountry = null;
    }

    public virtual void DeleteAllRefToBelongsToCountry()
    {
        BelongsToCountryId = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}