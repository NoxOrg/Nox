using System;// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using Employee = Cryptocash.Domain.Employee;

namespace Cryptocash.Application.Factories;

public abstract class EmployeeFactoryBase: IEntityFactory<Employee,EmployeeCreateDto>
{
    protected IEntityFactory<EmployeePhoneNumber,EmployeePhoneNumberCreateDto> EmployeePhoneNumberFactory {get;}

    public EmployeeFactoryBase
    (
        IEntityFactory<EmployeePhoneNumber,EmployeePhoneNumberCreateDto> employeephonenumberfactory
        )
    {        
        EmployeePhoneNumberFactory = employeephonenumberfactory;
    }

    public virtual Employee CreateEntity(EmployeeCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.Employee ToEntity(EmployeeCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Employee();
        entity.FirstName = Cryptocash.Domain.Employee.CreateFirstName(createDto.FirstName);
        entity.LastName = Cryptocash.Domain.Employee.CreateLastName(createDto.LastName);
        entity.EmailAddress = Cryptocash.Domain.Employee.CreateEmailAddress(createDto.EmailAddress);
        entity.Address = Cryptocash.Domain.Employee.CreateAddress(createDto.Address);
        entity.FirstWorkingDay = Cryptocash.Domain.Employee.CreateFirstWorkingDay(createDto.FirstWorkingDay);
        if (createDto.LastWorkingDay is not null)entity.LastWorkingDay = Cryptocash.Domain.Employee.CreateLastWorkingDay(createDto.LastWorkingDay.NonNullValue<System.DateTime>());
        //entity.CashStockOrder = CashStockOrder.ToEntity();
        entity.EmployeePhoneNumbers = createDto.EmployeePhoneNumbers.Select(dto => EmployeePhoneNumberFactory.CreateEntity(dto)).ToList();
        return entity;
    }
}

public partial class EmployeeFactory : EmployeeFactoryBase
{
    public EmployeeFactory
    (
        IEntityFactory<EmployeePhoneNumber,EmployeePhoneNumberCreateDto> employeephonenumberfactory
    ): base(employeephonenumberfactory)                      
    {}
}