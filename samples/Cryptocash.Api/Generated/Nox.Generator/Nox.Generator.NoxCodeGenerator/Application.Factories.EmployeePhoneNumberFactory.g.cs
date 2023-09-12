// Generated

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
using EmployeePhoneNumber = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Factories;

public abstract class EmployeePhoneNumberFactoryBase: IEntityFactory<EmployeePhoneNumber,EmployeePhoneNumberCreateDto>
{

    public EmployeePhoneNumberFactoryBase
    (
        )
    {
    }

    public virtual EmployeePhoneNumber CreateEntity(EmployeePhoneNumberCreateDto createDto)
    {
        return ToEntity(createDto);
    }
    private Cryptocash.Domain.EmployeePhoneNumber ToEntity(EmployeePhoneNumberCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.EmployeePhoneNumber();
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumberType(createDto.PhoneNumberType);
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumber(createDto.PhoneNumber);
        return entity;
    }
}

public partial class EmployeePhoneNumberFactory : EmployeePhoneNumberFactoryBase
{
}