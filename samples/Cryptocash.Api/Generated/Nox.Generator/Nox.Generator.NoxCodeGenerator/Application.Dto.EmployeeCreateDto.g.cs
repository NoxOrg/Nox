// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Employee definition and related data.
/// </summary>
public partial class EmployeeCreateDto : EmployeeUpdateDto
{

    public Employee ToEntity()
    {
        var entity = new Employee();
        entity.FirstName = Employee.CreateFirstName(FirstName);
        entity.LastName = Employee.CreateLastName(LastName);
        entity.EmailAddress = Employee.CreateEmailAddress(EmailAddress);
        entity.Address = Employee.CreateAddress(Address);
        entity.FirstWorkingDay = Employee.CreateFirstWorkingDay(FirstWorkingDay);
        if (LastWorkingDay is not null)entity.LastWorkingDay = Employee.CreateLastWorkingDay(LastWorkingDay.NonNullValue<System.DateTime>());
        //entity.VendingMachineOrder = VendingMachineOrder.ToEntity();
        //entity.EmployeePhoneNumbers = EmployeePhoneNumbers.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}