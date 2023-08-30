// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class Employee : AuditableEntityBase
{
    /// <summary>
    /// Employee's unique identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

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
    /// Employee Order employee ZeroOrMany VendingMachineOrders
    /// </summary>
    public virtual List<VendingMachineOrder> VendingMachineOrders { get; set; } = new();

    public List<VendingMachineOrder> VendingMachineOrder => VendingMachineOrders;

    /// <summary>
    /// Employee Employee's phone numbers ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumber> EmployeePhoneNumbers { get; set; } = new();

    public List<EmployeePhoneNumber> PhoneNumbers => EmployeePhoneNumbers;
}