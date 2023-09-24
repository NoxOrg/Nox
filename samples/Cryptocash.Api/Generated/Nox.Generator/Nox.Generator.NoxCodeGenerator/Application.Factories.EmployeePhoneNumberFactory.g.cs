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

public abstract class EmployeePhoneNumberFactoryBase : IEntityFactory<EmployeePhoneNumber, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto>
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

    public virtual void UpdateEntity(EmployeePhoneNumber entity, EmployeePhoneNumberUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(EmployeePhoneNumber entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.EmployeePhoneNumber ToEntity(EmployeePhoneNumberCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.EmployeePhoneNumber();
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumberType(createDto.PhoneNumberType);
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumber(createDto.PhoneNumber);
        return entity;
    }

    private void UpdateEntityInternal(EmployeePhoneNumber entity, EmployeePhoneNumberUpdateDto updateDto)
    {
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumberType(updateDto.PhoneNumberType.NonNullValue<System.String>());
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumber(updateDto.PhoneNumber.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(EmployeePhoneNumber entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("PhoneNumberType", out var PhoneNumberTypeUpdateValue))
        {
            if (PhoneNumberTypeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PhoneNumberType' can't be null");
            }
            {
                entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumberType(PhoneNumberTypeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PhoneNumber", out var PhoneNumberUpdateValue))
        {
            if (PhoneNumberUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PhoneNumber' can't be null");
            }
            {
                entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumber.CreatePhoneNumber(PhoneNumberUpdateValue);
            }
        }
    }
}

public partial class EmployeePhoneNumberFactory : EmployeePhoneNumberFactoryBase
{
}