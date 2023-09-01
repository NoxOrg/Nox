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
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;
using StoreSecurityPasswords = SampleWebApp.Domain.StoreSecurityPasswords;

namespace SampleWebApp.Application;

public class StoreSecurityPasswordsMapper : EntityMapperBase<StoreSecurityPasswords>
{
    public StoreSecurityPasswordsMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(StoreSecurityPasswords entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Id", dto.Id);        
        if (noxTypeValue != null)
        {        
            entity.Id = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "SecurityCamerasPassword", dto.SecurityCamerasPassword);
        if (noxTypeValue != null)
        {        
            entity.SecurityCamerasPassword = noxTypeValue;
        }
    

        /// <summary>
        /// StoreSecurityPasswords Store with this set of passwords ExactlyOne Stores
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "StoreRel", dto.StoreId);
        if (noxTypeValue != null)
        {        
            entity.StoreId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(StoreSecurityPasswords entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("Name", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("StoreSecurityPasswords", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("SecurityCamerasPassword", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "SecurityCamerasPassword", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("StoreSecurityPasswords", "SecurityCamerasPassword");
                }
                else
                {
                    entity.SecurityCamerasPassword = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// StoreSecurityPasswords Store with this set of passwords ExactlyOne Stores
        /// </summary>
        if (updatedProperties.TryGetValue("StoreId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "StoreRel", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.StoreId = noxRelationshipTypeValue;
            }
        }
    }
}