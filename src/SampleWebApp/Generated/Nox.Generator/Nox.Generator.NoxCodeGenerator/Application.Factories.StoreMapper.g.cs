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
using Store = SampleWebApp.Domain.Store;

namespace SampleWebApp.Application;

public class StoreMapper : EntityMapperBase<Store>
{
    public StoreMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Store entity, Entity entityDefinition, dynamic dto)
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
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "PhysicalMoney", dto.PhysicalMoney);
        if (noxTypeValue != null)
        {        
            entity.PhysicalMoney = noxTypeValue;
        }
    

        /// <summary>
        /// Store Store owner relationship ZeroOrOne StoreOwners
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "OwnerRel", dto.OwnerRelId);
        if (noxTypeValue != null)
        {        
            entity.OwnerRelId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Store entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("Store", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("PhysicalMoney", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "PhysicalMoney", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Store", "PhysicalMoney");
                }
                else
                {
                    entity.PhysicalMoney = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Store Store owner relationship ZeroOrOne StoreOwners
        /// </summary>
        if (updatedProperties.TryGetValue("StoreOwnerId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "OwnerRel", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.OwnerRelId = noxRelationshipTypeValue;
            }
        }
    }
}