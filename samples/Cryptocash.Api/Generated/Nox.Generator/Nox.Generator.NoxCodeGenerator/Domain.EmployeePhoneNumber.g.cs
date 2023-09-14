// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class EmployeePhoneNumber:EmployeePhoneNumberBase
{

}
/// <summary>
/// Record for EmployeePhoneNumber created event.
/// </summary>
public record EmployeePhoneNumberCreated(EmployeePhoneNumber EmployeePhoneNumber) : IDomainEvent;

/// <summary>
/// Record for EmployeePhoneNumber updated event.
/// </summary>
public record EmployeePhoneNumberUpdated(EmployeePhoneNumber EmployeePhoneNumber) : IDomainEvent;

/// <summary>
/// Record for EmployeePhoneNumber deleted event.
/// </summary>
public record EmployeePhoneNumberDeleted(EmployeePhoneNumber EmployeePhoneNumber) : IDomainEvent;

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