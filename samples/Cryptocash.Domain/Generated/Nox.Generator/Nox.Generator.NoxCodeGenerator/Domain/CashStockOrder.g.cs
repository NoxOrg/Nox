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

public partial class CashStockOrder : CashStockOrderBase, IEntityHaveDomainEvents
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
/// Record for CashStockOrder created event.
/// </summary>
public record CashStockOrderCreated(CashStockOrder CashStockOrder) :  IDomainEvent, INotification;
/// <summary>
/// Record for CashStockOrder updated event.
/// </summary>
public record CashStockOrderUpdated(CashStockOrder CashStockOrder) : IDomainEvent, INotification;
/// <summary>
/// Record for CashStockOrder deleted event.
/// </summary>
public record CashStockOrderDeleted(CashStockOrder CashStockOrder) : IDomainEvent, INotification;

/// <summary>
/// Vending machine cash stock order and related data.
/// </summary>
public abstract partial class CashStockOrderBase : AuditableEntityBase, IEtag
{
    /// <summary>
    /// Vending machine's order unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.AutoNumber Id { get; private set; } = null!;

    /// <summary>
    /// Order amount    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Money Amount { get;  set; } = null!;

    /// <summary>
    /// Order requested delivery date    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Date RequestedDeliveryDate { get;  set; } = null!;

    /// <summary>
    /// Order delivery date    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.DateTime? DeliveryDateTime { get;  set; } = null!;

    /// <summary>
    /// Order status    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public string? Status
        { 
            get { return DeliveryDateTime != null ? "delivered" : "ordered"; }
            private set { }
        }
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(CashStockOrder cashStockOrder)
	{
		InternalDomainEvents.Add(new CashStockOrderCreated(cashStockOrder));
    }
	
	protected virtual void InternalRaiseUpdateEvent(CashStockOrder cashStockOrder)
	{
		InternalDomainEvents.Add(new CashStockOrderUpdated(cashStockOrder));
    }
	
	protected virtual void InternalRaiseDeleteEvent(CashStockOrder cashStockOrder)
	{
		InternalDomainEvents.Add(new CashStockOrderDeleted(cashStockOrder));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// CashStockOrder for ExactlyOne VendingMachines
    /// </summary>
    public virtual VendingMachine VendingMachine { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity VendingMachine
    /// </summary>
    public Nox.Types.Guid VendingMachineId { get; set; } = null!;

    public virtual void CreateRefToVendingMachine(VendingMachine relatedVendingMachine)
    {
        VendingMachine = relatedVendingMachine;
    }

    public virtual void DeleteRefToVendingMachine(VendingMachine relatedVendingMachine)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToVendingMachine()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// CashStockOrder reviewed by ExactlyOne Employees
    /// </summary>
    public virtual Employee Employee { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Employee
    /// </summary>
    public Nox.Types.Guid EmployeeId { get; set; } = null!;

    public virtual void CreateRefToEmployee(Employee relatedEmployee)
    {
        Employee = relatedEmployee;
    }

    public virtual void DeleteRefToEmployee(Employee relatedEmployee)
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToEmployee()
    {
        throw new RelationshipDeletionException($"The relationship cannot be deleted.");
    }

    
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}