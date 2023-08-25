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

namespace CryptocashApi.Application;

public class EmployeeMapper: EntityMapperBase<Employee>
{
    public  EmployeeMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Employee entity, Entity entityDefinition, dynamic dto)
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
        noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"FirstWorkingDay",dto.FirstWorkingDay);
        if(noxTypeValue != null)
        {        
            entity.FirstWorkingDay = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"LastWorkingDay",dto.LastWorkingDay);
        if(noxTypeValue != null)
        {        
            entity.LastWorkingDay = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Employee entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("FirstName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FirstName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "FirstName");
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
                    throw new EntityAttributeIsNotNullableException("Employee", "LastName");
                }
                else
                {
                    entity.LastName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Email", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Email>(entityDefinition,"Email",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "Email");
                }
                else
                {
                    entity.Email = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Address", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition,"Address",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "Address");
                }
                else
                {
                    entity.Address = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FirstWorkingDay", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"FirstWorkingDay",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Employee", "FirstWorkingDay");
                }
                else
                {
                    entity.FirstWorkingDay = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("LastWorkingDay", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"LastWorkingDay",value);
                if(noxTypeValue == null)
                {
                    entity.LastWorkingDay = null;
                }
                else
                {
                    entity.LastWorkingDay = noxTypeValue;
                }
            }
        }
    }
}