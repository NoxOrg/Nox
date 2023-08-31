// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using CryptocashApi.Application.Dto;
using CryptocashApi.Domain;
using Customer = CryptocashApi.Domain.Customer;

namespace CryptocashApi.Application;

public class CustomerMapper: EntityMapperBase<Customer>
{
    public  CustomerMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Customer entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FirstName",dto.FirstName);
        if(noxTypeValue != null)
        {        
            entity.FirstName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"LastName",dto.LastName);
        if(noxTypeValue != null)
        {        
            entity.LastName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"EmailAddress",dto.EmailAddress);
        if(noxTypeValue != null)
        {        
            entity.EmailAddress = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"Address",dto.Address);
        if(noxTypeValue != null)
        {        
            entity.Address = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition,"MobileNumber",dto.MobileNumber);
        if(noxTypeValue != null)
        {        
            entity.MobileNumber = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Customer entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("FirstName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FirstName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "FirstName");
                }
                else
                {
                    entity.FirstName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LastName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"LastName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "LastName");
                }
                else
                {
                    entity.LastName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("EmailAddress", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"EmailAddress",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "EmailAddress");
                }
                else
                {
                    entity.EmailAddress = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Address", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"Address",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Customer", "Address");
                }
                else
                {
                    entity.Address = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MobileNumber", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition,"MobileNumber",value);
                if(noxTypeValue == null)
                {
                    entity.MobileNumber = null;
                }
                else
                {
                    entity.MobileNumber = noxTypeValue;
                }
            }
        }
    }
}