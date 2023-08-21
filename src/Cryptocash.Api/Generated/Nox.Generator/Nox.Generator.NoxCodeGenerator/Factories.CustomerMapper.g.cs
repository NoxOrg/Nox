// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using CryptocashApi.Application.Dto;
using CryptocashApi.Domain;


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
        noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"Email",dto.Email);
        if(noxTypeValue != null)
        {        
            entity.Email = noxTypeValue;
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

    public override void PartialMapToEntity(Customer entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, HashSet<string> deletedPropertyNames)
    {    
        if(deletedPropertyNames.Contains("FirstName"))
        {
            throw new EntityAttributeIsNotNullableException("Customer", "FirstName");
        }
        else if (updatedProperties.TryGetValue("FirstName", out dynamic? value))
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
        if(deletedPropertyNames.Contains("LastName"))
        {
            throw new EntityAttributeIsNotNullableException("Customer", "LastName");
        }
        else if (updatedProperties.TryGetValue("LastName", out dynamic? value))
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
        if(deletedPropertyNames.Contains("Email"))
        {
            throw new EntityAttributeIsNotNullableException("Customer", "Email");
        }
        else if (updatedProperties.TryGetValue("Email", out dynamic? value))
        {
            var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"Email",value);
            if(noxTypeValue == null)
            {
                throw new EntityAttributeIsNotNullableException("Customer", "Email");
            }
            else
            {
                entity.Email = noxTypeValue;
            }
        }    
        if(deletedPropertyNames.Contains("Address"))
        {
            throw new EntityAttributeIsNotNullableException("Customer", "Address");
        }
        else if (updatedProperties.TryGetValue("Address", out dynamic? value))
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
        if(deletedPropertyNames.Contains("MobileNumber"))
        {
            entity.MobileNumber = null;
        }
        else if (updatedProperties.TryGetValue("MobileNumber", out dynamic? value))
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