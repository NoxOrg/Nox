// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class Employee:EmployeeBase
{

}
/// <summary>
/// Record for Employee created event.
/// </summary>
public record EmployeeCreated(EmployeeBase Employee) : IDomainEvent;
/// <summary>
/// Record for Employee updated event.
/// </summary>
public record EmployeeUpdated(EmployeeBase Employee) : IDomainEvent;
/// <summary>
/// Record for Employee deleted event.
/// </summary>
public record EmployeeDeleted(EmployeeBase Employee) : IDomainEvent;

/// <summary>
/// Employee definition and related data.
/// </summary>
public abstract class EmployeeBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
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

	///<inheritdoc/>
	public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

	private readonly List<IDomainEvent> _domainEvents = new();
	
	///<inheritdoc/>
	public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new EmployeeCreated(this));     
	}
	
	///<inheritdoc/>
	public virtual void RaiseUpdateEvent()
	{
		_domainEvents.Add(new EmployeeUpdated(this));  
	}
	
	///<inheritdoc/>
	public virtual void RaiseDeleteEvent()
	{
		_domainEvents.Add(new EmployeeDeleted(this)); 
	}
	
	///<inheritdoc />
    public virtual void ClearDomainEvents()
	{
		_domainEvents.Clear();
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