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
using StoreOwner = ClientApi.Domain.StoreOwner;

namespace ClientApi.Application;

public class StoreOwnerMapper : EntityMapperBase<StoreOwner>
{
    public StoreOwnerMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(StoreOwner entity, Entity entityDefinition, dynamic dto)
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
        noxTypeValue = CreateNoxType<Nox.Types.VatNumber>(entityDefinition, "VatNumber", dto.VatNumber);
        if (noxTypeValue != null)
        {        
            entity.VatNumber = noxTypeValue;
        }
    
    }

    public override void PartialMapToEntity(StoreOwner entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("StoreOwner", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("VatNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.VatNumber>(entityDefinition, "VatNumber", value);
                if(noxTypeValue == null)
                {
                    entity.VatNumber = null;
                }
                else
                {
                    entity.VatNumber = noxTypeValue;
                }
            }
        }
    
    
    }
}