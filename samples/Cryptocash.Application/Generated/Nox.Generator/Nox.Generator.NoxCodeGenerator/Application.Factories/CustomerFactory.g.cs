
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
using Dto = Cryptocash.Application.Dto;
using Cryptocash.Domain;
using CustomerEntity = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Factories;

internal partial class CustomerFactory : CustomerFactoryBase
{
    public CustomerFactory
    (
    ) : base()
    {}
}

internal abstract class CustomerFactoryBase : IEntityFactory<CustomerEntity, CustomerCreateDto, CustomerUpdateDto>
{

    public CustomerFactoryBase(
        )
    {
    }

    public virtual async Task<CustomerEntity> CreateEntityAsync(CustomerCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CustomerEntity));
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
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CustomerEntity));
        }   
    }

    public virtual async Task PartialUpdateEntityAsync(CustomerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        try
        {
            PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
            await Task.CompletedTask;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new CreateUpdateEntityInvalidDataException(ex, nameof(CustomerEntity));
        }   
    }

    private async Task<Cryptocash.Domain.Customer> ToEntityAsync(CustomerCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new Cryptocash.Domain.Customer();
        exceptionCollector.Collect("FirstName", () => entity.SetIfNotNull(createDto.FirstName, (entity) => entity.FirstName = 
            Dto.CustomerMetadata.CreateFirstName(createDto.FirstName.NonNullValue<System.String>())));
        exceptionCollector.Collect("LastName", () => entity.SetIfNotNull(createDto.LastName, (entity) => entity.LastName = 
            Dto.CustomerMetadata.CreateLastName(createDto.LastName.NonNullValue<System.String>())));
        exceptionCollector.Collect("EmailAddress", () => entity.SetIfNotNull(createDto.EmailAddress, (entity) => entity.EmailAddress = 
            Dto.CustomerMetadata.CreateEmailAddress(createDto.EmailAddress.NonNullValue<System.String>())));
        exceptionCollector.Collect("Address", () => entity.SetIfNotNull(createDto.Address, (entity) => entity.Address = 
            Dto.CustomerMetadata.CreateAddress(createDto.Address.NonNullValue<StreetAddressDto>())));
        exceptionCollector.Collect("MobileNumber", () => entity.SetIfNotNull(createDto.MobileNumber, (entity) => entity.MobileNumber = 
            Dto.CustomerMetadata.CreateMobileNumber(createDto.MobileNumber.NonNullValue<System.String>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        entity.EnsureId(createDto.Id);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(CustomerEntity entity, CustomerUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("FirstName",() => entity.FirstName = Dto.CustomerMetadata.CreateFirstName(updateDto.FirstName.NonNullValue<System.String>()));
        exceptionCollector.Collect("LastName",() => entity.LastName = Dto.CustomerMetadata.CreateLastName(updateDto.LastName.NonNullValue<System.String>()));
        exceptionCollector.Collect("EmailAddress",() => entity.EmailAddress = Dto.CustomerMetadata.CreateEmailAddress(updateDto.EmailAddress.NonNullValue<System.String>()));
        exceptionCollector.Collect("Address",() => entity.Address = Dto.CustomerMetadata.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>()));
        if(updateDto.MobileNumber is null)
        {
             entity.MobileNumber = null;
        }
        else
        {
            exceptionCollector.Collect("MobileNumber",() =>entity.MobileNumber = Dto.CustomerMetadata.CreateMobileNumber(updateDto.MobileNumber.ToValueFromNonNull<System.String>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(CustomerEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("FirstName", out var FirstNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(FirstNameUpdateValue, "Attribute 'FirstName' can't be null.");
            {
                exceptionCollector.Collect("FirstName",() =>entity.FirstName = Dto.CustomerMetadata.CreateFirstName(FirstNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("LastName", out var LastNameUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(LastNameUpdateValue, "Attribute 'LastName' can't be null.");
            {
                exceptionCollector.Collect("LastName",() =>entity.LastName = Dto.CustomerMetadata.CreateLastName(LastNameUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EmailAddress", out var EmailAddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(EmailAddressUpdateValue, "Attribute 'EmailAddress' can't be null.");
            {
                exceptionCollector.Collect("EmailAddress",() =>entity.EmailAddress = Dto.CustomerMetadata.CreateEmailAddress(EmailAddressUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("Address", out var AddressUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(AddressUpdateValue, "Attribute 'Address' can't be null.");
            {
                var entityToUpdate = entity.Address is null ? new StreetAddressDto() : entity.Address.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, AddressUpdateValue);
                exceptionCollector.Collect("Address",() =>entity.Address = Dto.CustomerMetadata.CreateAddress(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("MobileNumber", out var MobileNumberUpdateValue))
        {
            if (MobileNumberUpdateValue == null) { entity.MobileNumber = null; }
            else
            {
                exceptionCollector.Collect("MobileNumber",() =>entity.MobileNumber = Dto.CustomerMetadata.CreateMobileNumber(MobileNumberUpdateValue));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}