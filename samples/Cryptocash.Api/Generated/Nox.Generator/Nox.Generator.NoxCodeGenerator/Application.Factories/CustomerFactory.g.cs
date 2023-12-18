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
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Factories;

internal partial class CustomerFactory : CustomerFactoryBase
{
    public CustomerFactory
    (
        IRepository repository
    ) : base( repository)
    {}
}

internal abstract class CustomerFactoryBase : IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");
    private readonly IRepository _repository;

    public CustomerFactoryBase(
        IRepository repository
        )
    {
        _repository = repository;
    }

    public virtual async Task<CustomerEntity> CreateEntityAsync(CustomerCreateDto createDto)
    {
        try
        {
            return await ToEntityAsync(createDto);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
    }

    public virtual async Task UpdateEntityAsync(CustomerEntity entity, CustomerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    public virtual void PartialUpdateEntity(CustomerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
    }

    private async Task<Cryptocash.Domain.Customer> ToEntityAsync(CustomerCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Customer();
        entity.SetIfNotNull(createDto.FirstName, (entity) => entity.FirstName = 
            Cryptocash.Domain.CustomerMetadata.CreateFirstName(createDto.FirstName.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.LastName, (entity) => entity.LastName = 
            Cryptocash.Domain.CustomerMetadata.CreateLastName(createDto.LastName.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.EmailAddress, (entity) => entity.EmailAddress = 
            Cryptocash.Domain.CustomerMetadata.CreateEmailAddress(createDto.EmailAddress.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.Address, (entity) => entity.Address = 
            Cryptocash.Domain.CustomerMetadata.CreateAddress(createDto.Address.NonNullValue<StreetAddressDto>()));
        entity.SetIfNotNull(createDto.MobileNumber, (entity) => entity.MobileNumber = 
            Cryptocash.Domain.CustomerMetadata.CreateMobileNumber(createDto.MobileNumber.NonNullValue<System.String>()));
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CustomerEntity entity, CustomerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
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
        await Task.CompletedTask;
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
                var entityToUpdate = entity.Address is null ? new StreetAddressDto() : entity.Address.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, AddressUpdateValue);
                entity.Address = Cryptocash.Domain.CustomerMetadata.CreateAddress(entityToUpdate);
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