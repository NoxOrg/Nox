// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;

/// <summary>
/// Record for Employee created event.
/// </summary>
public record EmployeeCreated(Employee Employee) : IDomainEvent;

/// <summary>
/// Record for Employee updated event.
/// </summary>
public record EmployeeUpdated(Employee Employee) : IDomainEvent;

/// <summary>
/// Record for Employee deleted event.
/// </summary>
public record EmployeeDeleted(Employee Employee) : IDomainEvent;

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class Employee : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// Employee's unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

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
    /// Employee reviewing ExactlyOne CashStockOrders
    /// </summary>
    public virtual CashStockOrder EmployeeReviewingCashStockOrder { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity CashStockOrder
    /// </summary>
    public Nox.Types.AutoNumber EmployeeReviewingCashStockOrderId { get; set; } = null!;

    /// <summary>
    /// Employee contacted by ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumber> EmployeePhoneNumbers { get; set; } = new();

    public List<EmployeePhoneNumber> EmployeeContactPhoneNumbers => EmployeePhoneNumbers;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}