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

namespace Cryptocash.Domain;

public partial class Employee : EmployeeBase, IEntityHaveDomainEvents
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
/// Record for Employee created event.
/// </summary>
public record EmployeeCreated(Employee Employee) :  IDomainEvent, INotification;
/// <summary>
/// Record for Employee updated event.
/// </summary>
public record EmployeeUpdated(Employee Employee) : IDomainEvent, INotification;
/// <summary>
/// Record for Employee deleted event.
/// </summary>
public record EmployeeDeleted(Employee Employee) : IDomainEvent, INotification;

/// <summary>
/// Employee definition and related data.
/// </summary>
public abstract partial class EmployeeBase : AuditableEntityBase, IEtag
{
    /// <summary>
    /// Employee's unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Guid Id {get; private set;} = null!;
        /// <summary>
        /// Ensures that a Guid Id is set or will be generate a new one
        /// </summary>
    	public virtual void EnsureId(System.Guid? guid)
    	{
    		if(guid is null || System.Guid.Empty.Equals(guid))
    		{
    			Id = Nox.Types.Guid.From(System.Guid.NewGuid());
    		}
    		else
    		{
    			Id = Nox.Types.Guid.From(guid!.Value);
    		}
    	}

    /// <summary>
    /// Employee's first name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text FirstName { get;  set; } = null!;

    /// <summary>
    /// Employee's last name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text LastName { get;  set; } = null!;

    /// <summary>
    /// Employee's email address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Email EmailAddress { get;  set; } = null!;

    /// <summary>
    /// Employee's street address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.StreetAddress Address { get;  set; } = null!;

    /// <summary>
    /// Employee's first working day    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Date FirstWorkingDay { get;  set; } = null!;

    /// <summary>
    /// Employee's last working day    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Date? LastWorkingDay { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Employee employee)
	{
		InternalDomainEvents.Add(new EmployeeCreated(employee));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Employee employee)
	{
		InternalDomainEvents.Add(new EmployeeUpdated(employee));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Employee employee)
	{
		InternalDomainEvents.Add(new EmployeeDeleted(employee));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Employee reviewing ZeroOrOne CashStockOrders
    /// </summary>
    public virtual CashStockOrder? CashStockOrder { get; private set; } = null!;

    public virtual void CreateRefToCashStockOrder(CashStockOrder relatedCashStockOrder)
    {
        CashStockOrder = relatedCashStockOrder;
    }

    public virtual void DeleteRefToCashStockOrder(CashStockOrder relatedCashStockOrder)
    {
        CashStockOrder = null;
    }

    public virtual void DeleteAllRefToCashStockOrder()
    {
        CashStockOrder = null;
    }﻿

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumber> EmployeePhoneNumbers { get; private set; } = new();
    
    /// <summary>
    /// Creates a new EmployeePhoneNumber entity.
    /// </summary>
    public virtual void CreateEmployeePhoneNumbers(EmployeePhoneNumber relatedEmployeePhoneNumber)
    {
        EmployeePhoneNumbers.Add(relatedEmployeePhoneNumber);
    }
    
    /// <summary>
    /// Updates all owned EmployeePhoneNumber entities.
    /// </summary>
    public virtual void UpdateEmployeePhoneNumbers(List<EmployeePhoneNumber> relatedEmployeePhoneNumber)
    {
        EmployeePhoneNumbers.Clear();
        EmployeePhoneNumbers.AddRange(relatedEmployeePhoneNumber);
    }
    
    /// <summary>
    /// Deletes owned EmployeePhoneNumber entity.
    /// </summary>
    public virtual void DeleteEmployeePhoneNumbers(EmployeePhoneNumber relatedEmployeePhoneNumber)
    {
        EmployeePhoneNumbers.Remove(relatedEmployeePhoneNumber);
    }
    
    /// <summary>
    /// Deletes all owned EmployeePhoneNumber entities.
    /// </summary>
    public virtual void DeleteAllEmployeePhoneNumbers()
    {
        EmployeePhoneNumbers.Clear();
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}