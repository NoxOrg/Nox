// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace Cryptocash.Domain;
public partial class EmployeePhoneNumber:EmployeePhoneNumberBase
{

}
/// <summary>
/// Employee phone number and related data.
/// </summary>
public abstract class EmployeePhoneNumberBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Employee's phone number identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Employee's phone number type (Required).
    /// </summary>
    public Nox.Types.Text PhoneNumberType { get; set; } = null!;

    /// <summary>
    /// Employee's phone number (Required).
    /// </summary>
    public Nox.Types.PhoneNumber PhoneNumber { get; set; } = null!;

}