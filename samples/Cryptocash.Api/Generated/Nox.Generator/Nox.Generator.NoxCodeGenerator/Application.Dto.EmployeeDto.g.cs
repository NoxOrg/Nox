// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record EmployeeKeyDto(System.Int64 keyId);

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeDto
{

    /// <summary>
    /// Employee's unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Employee's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// Employee's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// Employee's email address (Required).
    /// </summary>
    public System.String EmailAddress { get; set; } = default!;

    /// <summary>
    /// Employee's street address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// Employee's first working day (Required).
    /// </summary>
    public System.DateTime FirstWorkingDay { get; set; } = default!;

    /// <summary>
    /// Employee's last working day (Optional).
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; }

    /// <summary>
    /// Employee Reviewed by employee ExactlyOne VendingMachineOrders
    /// </summary>
    public virtual VendingMachineOrderDto VendingMachineOrder { get; set; } = null!;

    /// <summary>
    /// Employee Employee's phone numbers ZeroOrMany EmployeePhoneNumbers
    /// </summary>
    public virtual List<EmployeePhoneNumberDto> EmployeePhoneNumbers { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    public Employee ToEntity()
    {
        var entity = new Employee();
        entity.Id = Employee.CreateId(Id);
        entity.FirstName = Employee.CreateFirstName(FirstName);
        entity.LastName = Employee.CreateLastName(LastName);
        entity.EmailAddress = Employee.CreateEmailAddress(EmailAddress);
        entity.Address = Employee.CreateAddress(Address);
        entity.FirstWorkingDay = Employee.CreateFirstWorkingDay(FirstWorkingDay);
        if (LastWorkingDay is not null)entity.LastWorkingDay = Employee.CreateLastWorkingDay(LastWorkingDay.NonNullValue<System.DateTime>());
        entity.VendingMachineOrder = VendingMachineOrder.ToEntity();
        entity.EmployeePhoneNumbers = EmployeePhoneNumbers.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }

}