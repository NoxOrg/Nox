﻿// Generated

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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Factories;

internal abstract class CustomerFactoryBase : IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public CustomerFactoryBase
    (
        )
    {
    }

    public virtual CustomerEntity CreateEntity(CustomerCreateDto createDto)
    {
        try
        {
            return ToEntity(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual void UpdateEntity(CustomerEntity entity, CustomerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(CustomerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private Cryptocash.Domain.Customer ToEntity(CustomerCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Customer();
        entity.FirstName = Cryptocash.Domain.CustomerMetadata.CreateFirstName(createDto.FirstName);
        entity.LastName = Cryptocash.Domain.CustomerMetadata.CreateLastName(createDto.LastName);
        entity.EmailAddress = Cryptocash.Domain.CustomerMetadata.CreateEmailAddress(createDto.EmailAddress);
        entity.Address = Cryptocash.Domain.CustomerMetadata.CreateAddress(createDto.Address);
        entity.SetIfNotNull(createDto.MobileNumber, (entity) => entity.MobileNumber =Cryptocash.Domain.CustomerMetadata.CreateMobileNumber(createDto.MobileNumber.NonNullValue<System.String>()));
        return entity;
    }

    private void UpdateEntityInternal(CustomerEntity entity, CustomerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.FirstName = Cryptocash.Domain.CustomerMetadata.CreateFirstName(updateDto.FirstName.NonNullValue<System.String>());
        entity.LastName = Cryptocash.Domain.CustomerMetadata.CreateLastName(updateDto.LastName.NonNullValue<System.String>());
        entity.EmailAddress = Cryptocash.Domain.CustomerMetadata.CreateEmailAddress(updateDto.EmailAddress.NonNullValue<System.String>());
        entity.Address = Cryptocash.Domain.CustomerMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
        if(updateDto.MobileNumber is null)
        {
             entity.MobileNumber = null;
        }
        else
        {
            entity.MobileNumber = Cryptocash.Domain.CustomerMetadata.CreateMobileNumber(updateDto.MobileNumber.ToValueFromNonNull<System.String>());
        }
    }

    private void PartialUpdateEntityInternal(CustomerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {

        if (updatedProperties.TryGetValue("FirstName", out var FirstNameUpdateValue))
        {
            if (FirstNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'FirstName' can't be null");
            }
            {
                entity.FirstName = Cryptocash.Domain.CustomerMetadata.CreateFirstName(FirstNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("LastName", out var LastNameUpdateValue))
        {
            if (LastNameUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'LastName' can't be null");
            }
            {
                entity.LastName = Cryptocash.Domain.CustomerMetadata.CreateLastName(LastNameUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("EmailAddress", out var EmailAddressUpdateValue))
        {
            if (EmailAddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'EmailAddress' can't be null");
            }
            {
                entity.EmailAddress = Cryptocash.Domain.CustomerMetadata.CreateEmailAddress(EmailAddressUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            if (AddressUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'Address' can't be null");
            }
            {
                entity.Address = Cryptocash.Domain.CustomerMetadata.CreateAddress(AddressUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MobileNumber", out var MobileNumberUpdateValue))
        {
            if (MobileNumberUpdateValue == null) { entity.MobileNumber = null; }
            else
            {
                entity.MobileNumber = Cryptocash.Domain.CustomerMetadata.CreateMobileNumber(MobileNumberUpdateValue);
            }
        }
    }

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class CustomerFactory : CustomerFactoryBase
{
}