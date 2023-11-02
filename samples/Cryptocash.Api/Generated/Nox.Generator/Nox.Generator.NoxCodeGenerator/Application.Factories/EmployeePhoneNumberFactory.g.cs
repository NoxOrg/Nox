// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using EmployeePhoneNumberEntity = Cryptocash.Domain.EmployeePhoneNumber;

namespace Cryptocash.Application.Factories;

internal abstract class EmployeePhoneNumberFactoryBase : IEntityFactory<EmployeePhoneNumberEntity, EmployeePhoneNumberCreateDto, EmployeePhoneNumberUpdateDto>
{

    public EmployeePhoneNumberFactoryBase
    (
        )
    {
    }

    public virtual EmployeePhoneNumberEntity CreateEntity(EmployeePhoneNumberCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(EmployeePhoneNumberEntity entity, EmployeePhoneNumberUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(EmployeePhoneNumberEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private Cryptocash.Domain.EmployeePhoneNumber ToEntity(EmployeePhoneNumberCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.EmployeePhoneNumber();
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(createDto.PhoneNumberType);
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(createDto.PhoneNumber);
        return entity;
    }

    private void UpdateEntityInternal(EmployeePhoneNumberEntity entity, EmployeePhoneNumberUpdateDto updateDto)
    {
        entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(updateDto.PhoneNumberType.NonNullValue<System.String>());
        entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(updateDto.PhoneNumber.NonNullValue<System.String>());
    }

    private void PartialUpdateEntityInternal(EmployeePhoneNumberEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("PhoneNumberType", out var PhoneNumberTypeUpdateValue))
        {
            if (PhoneNumberTypeUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PhoneNumberType' can't be null");
            }
            {
                entity.PhoneNumberType = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumberType(PhoneNumberTypeUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PhoneNumber", out var PhoneNumberUpdateValue))
        {
            if (PhoneNumberUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'PhoneNumber' can't be null");
            }
            {
                entity.PhoneNumber = Cryptocash.Domain.EmployeePhoneNumberMetadata.CreatePhoneNumber(PhoneNumberUpdateValue);
            }
        }
    }
}

internal partial class EmployeePhoneNumberFactory : EmployeePhoneNumberFactoryBase
{
}