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
using Customer = Cryptocash.Domain.Customer;

namespace Cryptocash.Application.Factories;

public abstract class CustomerFactoryBase : IEntityFactory<Customer, CustomerCreateDto, CustomerUpdateDto>
{

    public CustomerFactoryBase
    (
        )
    {
    }

    public virtual Customer CreateEntity(CustomerCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(Customer entity, CustomerUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    private Cryptocash.Domain.Customer ToEntity(CustomerCreateDto createDto)
    {
        var entity = new Cryptocash.Domain.Customer();
        entity.FirstName = Cryptocash.Domain.Customer.CreateFirstName(createDto.FirstName);
        entity.LastName = Cryptocash.Domain.Customer.CreateLastName(createDto.LastName);
        entity.EmailAddress = Cryptocash.Domain.Customer.CreateEmailAddress(createDto.EmailAddress);
        entity.Address = Cryptocash.Domain.Customer.CreateAddress(createDto.Address);
        if (createDto.MobileNumber is not null)entity.MobileNumber = Cryptocash.Domain.Customer.CreateMobileNumber(createDto.MobileNumber.NonNullValue<System.String>());
        return entity;
    }

    private void UpdateEntityInternal(Customer entity, CustomerUpdateDto updateDto)
    {
        entity.FirstName = Cryptocash.Domain.Customer.CreateFirstName(updateDto.FirstName.NonNullValue<System.String>());
        entity.LastName = Cryptocash.Domain.Customer.CreateLastName(updateDto.LastName.NonNullValue<System.String>());
        entity.EmailAddress = Cryptocash.Domain.Customer.CreateEmailAddress(updateDto.EmailAddress.NonNullValue<System.String>());
        entity.Address = Cryptocash.Domain.Customer.CreateAddress(updateDto.Address.NonNullValue<StreetAddressDto>());
        if (updateDto.MobileNumber == null) { entity.MobileNumber = null; } else {
            entity.MobileNumber = Cryptocash.Domain.Customer.CreateMobileNumber(updateDto.MobileNumber.ToValueFromNonNull<System.String>());
        }
    }
}

public partial class CustomerFactory : CustomerFactoryBase
{
}