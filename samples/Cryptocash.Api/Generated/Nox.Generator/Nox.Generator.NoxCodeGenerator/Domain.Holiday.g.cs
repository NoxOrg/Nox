// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class Holiday:HolidayBase
{

}
/// <summary>
/// Record for Holiday created event.
/// </summary>
public record HolidayCreated(HolidayBase Holiday) : IDomainEvent;
/// <summary>
/// Record for Holiday updated event.
/// </summary>
public record HolidayUpdated(HolidayBase Holiday) : IDomainEvent;
/// <summary>
/// Record for Holiday deleted event.
/// </summary>
public record HolidayDeleted(HolidayBase Holiday) : IDomainEvent;

/// <summary>
/// Holiday related to country.
/// </summary>
public abstract class HolidayBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{
    /// <summary>
    /// Country's holiday unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    public Nox.Types.Text Type { get; set; } = null!;

    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    public Nox.Types.Date Date { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new HolidayCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new HolidayUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new HolidayDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}