// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace CryptocashApi.Domain;

/// <summary>
/// Employee phone numbers and related data.
/// </summary>
public partial class EmployeePhoneNumber:IOwnedEntity
{
    /// <summary>
    /// The employee's phone number identifier (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The employee's phone number type (Required).
    /// </summary>
    public Nox.Types.Text PhoneNumberType { get; set; } = null!;

    /// <summary>
    /// The employee's phone number (Required).
    /// </summary>
    public Nox.Types.PhoneNumber PhoneNumber { get; set; } = null!;

    /// <summary>
    /// EmployeePhoneNumber The related employee ZeroOrMany Employees
    /// </summary>
    public virtual List<Employee> Employees { get; set; } = new();

    public List<Employee> Employee => Employees;
}