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
using Cryptocash.Application.Dto;
using Cryptocash.Domain;
using LandLord = Cryptocash.Domain.LandLord;

namespace Cryptocash.Application;

public class LandLordMapper : EntityMapperBase<LandLord>
{
    public LandLordMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(LandLord entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "Address", dto.Address);
        if (noxTypeValue != null)
        {        
            entity.Address = noxTypeValue;
        }
    
    }

    public override void PartialMapToEntity(LandLord entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("LandLord", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Address", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.StreetAddress>(entityDefinition, "Address", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("LandLord", "Address");
                }
                else
                {
                    entity.Address = noxTypeValue;
                }
            }
        }
    
    
    }
}