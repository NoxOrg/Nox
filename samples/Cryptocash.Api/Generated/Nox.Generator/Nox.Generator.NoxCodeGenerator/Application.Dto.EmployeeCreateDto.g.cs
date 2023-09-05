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

    public Cryptocash.Domain.Employee ToEntity()
    {
        var entity = new Cryptocash.Domain.Employee();
        entity.FirstName = Cryptocash.Domain.Employee.CreateFirstName(FirstName);
        entity.LastName = Cryptocash.Domain.Employee.CreateLastName(LastName);
        entity.EmailAddress = Cryptocash.Domain.Employee.CreateEmailAddress(EmailAddress);
        entity.Address = Cryptocash.Domain.Employee.CreateAddress(Address);
        entity.FirstWorkingDay = Cryptocash.Domain.Employee.CreateFirstWorkingDay(FirstWorkingDay);
        if (LastWorkingDay is not null)entity.LastWorkingDay = Cryptocash.Domain.Employee.CreateLastWorkingDay(LastWorkingDay.NonNullValue<System.DateTime>());
        //entity.CashStockOrder = CashStockOrder.ToEntity();
        //entity.EmployeePhoneNumbers = EmployeePhoneNumbers.Select(dto => dto.ToEntity()).ToList();
        return entity;
    }
}