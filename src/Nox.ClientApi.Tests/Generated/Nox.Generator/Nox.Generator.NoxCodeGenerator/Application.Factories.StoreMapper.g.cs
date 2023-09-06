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
using ClientApi.Application.Dto;
using ClientApi.Domain;
using Store = ClientApi.Domain.Store;

namespace ClientApi.Application;

public class StoreMapper : EntityMapperBase<Store>
{
    public StoreMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Store entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
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