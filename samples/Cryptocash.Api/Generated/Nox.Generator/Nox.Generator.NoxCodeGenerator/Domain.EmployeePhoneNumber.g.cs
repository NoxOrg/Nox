// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
internal partial class EmployeePhoneNumber:EmployeePhoneNumberBase
{

}
/// <summary>
/// Record for EmployeePhoneNumber created event.
/// </summary>
public record EmployeePhoneNumberCreated(EmployeePhoneNumberBase EmployeePhoneNumber) : IDomainEvent;
/// <summary>
/// Record for EmployeePhoneNumber updated event.
/// </summary>
public record EmployeePhoneNumberUpdated(EmployeePhoneNumberBase EmployeePhoneNumber) : IDomainEvent;
/// <summary>
/// Record for EmployeePhoneNumber deleted event.
/// </summary>
public record EmployeePhoneNumberDeleted(EmployeePhoneNumberBase EmployeePhoneNumber) : IDomainEvent;

/// <summary>
/// Employee phone number and related data.
/// </summary>
public abstract class EmployeePhoneNumberBase : EntityBase, IOwnedEntity, IEntityHaveDomainEvents
{
    /// <summary>
    /// Employee's phone number identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    public Nox.Types.Text PhoneNumberType { get; set; } = null!;

    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    public Nox.Types.PhoneNumber PhoneNumber { get; set; } = null!;

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new EmployeePhoneNumberCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new EmployeePhoneNumberUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new EmployeePhoneNumberDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

}