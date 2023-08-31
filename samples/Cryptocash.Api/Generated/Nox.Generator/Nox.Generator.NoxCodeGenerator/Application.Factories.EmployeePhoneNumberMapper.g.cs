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

public class EmployeePhoneNumberMapper : EntityMapperBase<EmployeePhoneNumber>
{
    public EmployeePhoneNumberMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(EmployeePhoneNumber entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PhoneNumberType", dto.PhoneNumberType);
        if (noxTypeValue != null)
        {        
            entity.PhoneNumberType = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition, "PhoneNumber", dto.PhoneNumber);
        if (noxTypeValue != null)
        {        
            entity.PhoneNumber = noxTypeValue;
        }
    
    }

    public override void PartialMapToEntity(EmployeePhoneNumber entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("PhoneNumberType", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "PhoneNumberType", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("EmployeePhoneNumber", "PhoneNumberType");
                }
                else
                {
                    entity.PhoneNumberType = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PhoneNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.PhoneNumber>(entityDefinition, "PhoneNumber", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("EmployeePhoneNumber", "PhoneNumber");
                }
                else
                {
                    entity.PhoneNumber = noxTypeValue;
                }
            }
        }
    
    
    }
}