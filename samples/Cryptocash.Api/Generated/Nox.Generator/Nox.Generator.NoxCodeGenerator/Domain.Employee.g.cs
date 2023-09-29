// Generated

#nullable enable

using System;
using System.Collections.Generic;

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
internal record EmployeeCreated(Employee Employee) : IDomainEvent;
/// <summary>
/// Record for Employee updated event.
/// </summary>
internal record EmployeeUpdated(Employee Employee) : IDomainEvent;
/// <summary>
/// Record for Employee deleted event.
/// </summary>
internal record EmployeeDeleted(Employee Employee) : IDomainEvent;

/// <summary>
/// Employee definition and related data.
/// </summary>
internal abstract partial class EmployeeBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Employee's unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Employee's first name (Required).
    /// </summary>
    public Nox.Types.Text FirstName { get; set; } = null!;

    /// <summary>
    /// Employee's last name (Required).
    /// </summary>
    public Nox.Types.Text LastName { get; set; } = null!;

    /// <summary>
    /// Employee's email address (Required).
    /// </summary>
    public Nox.Types.Email EmailAddress { get; set; } = null!;

    /// <summary>
    /// Employee's street address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Employee's first working day (Required).
    /// </summary>
    public Nox.Types.Date FirstWorkingDay { get; set; } = null!;

    /// <summary>
    /// Employee's last working day (Optional).
    /// </summary>
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
    /// Employee reviewing ExactlyOne CashStockOrders
    /// </summary>
    public virtual CashStockOrder EmployeeReviewingCashStockOrder { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity CashStockOrder
    /// </summary>
    public Nox.Types.AutoNumber EmployeeReviewingCashStockOrderId { get; set; } = null!;

    public virtual void CreateRefToEmployeeReviewingCashStockOrder(CashStockOrder relatedCashStockOrder)
    {
        EmployeeReviewingCashStockOrder = relatedCashStockOrder;
    }

    public virtual void DeleteRefToEmployeeReviewingCashStockOrder(CashStockOrder relatedCashStockOrder)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToEmployeeReviewingCashStockOrder()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumber> EmployeeContactPhoneNumbers { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}