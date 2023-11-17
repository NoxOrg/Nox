// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;

internal partial class Employee : EmployeeBase, IEntityHaveDomainEvents
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
internal record EmployeeCreated(Employee Employee) :  IDomainEvent, INotification;
/// <summary>
/// Record for Employee updated event.
/// </summary>
internal record EmployeeUpdated(Employee Employee) : IDomainEvent, INotification;
/// <summary>
/// Record for Employee deleted event.
/// </summary>
internal record EmployeeDeleted(Employee Employee) : IDomainEvent, INotification;

/// <summary>
/// Employee definition and related data.
/// </summary>
internal abstract partial class EmployeeBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Employee's unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Employee's first name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// Employee's last name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text LastName { get; set; } = null!;

    /// <summary>
    /// Employee's email address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Email EmailAddress { get; set; } = null!;

    /// <summary>
    /// Employee's street address    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Employee's first working day    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Date FirstWorkingDay { get; set; } = null!;

    /// <summary>
    /// Employee's last working day    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.Date? LastWorkingDay { get; set; } = null!;
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
    public virtual void CreateRefToEmployeePhoneNumbers(EmployeePhoneNumber relatedEmployeePhoneNumber)
    {
        EmployeePhoneNumbers.Add(relatedEmployeePhoneNumber);
    }
    
    /// <summary>
    /// Deletes owned EmployeePhoneNumber entity.
    /// </summary>
    public virtual void DeleteRefToEmployeePhoneNumbers(EmployeePhoneNumber relatedEmployeePhoneNumber)
    {
        EmployeePhoneNumbers.Remove(relatedEmployeePhoneNumber);
    }
    
    /// <summary>
    /// Deletes all owned EmployeePhoneNumber entities.
    /// </summary>
    public virtual void DeleteAllRefToEmployeePhoneNumbers()
    {
        EmployeePhoneNumbers.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}