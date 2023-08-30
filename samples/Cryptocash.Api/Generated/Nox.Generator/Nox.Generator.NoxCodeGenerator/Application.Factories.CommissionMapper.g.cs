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

namespace Cryptocash.Application;

public class CommissionMapper: EntityMapperBase<Commission>
{
    public  CommissionMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Commission entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Percentage>(entityDefinition,"Rate",dto.Rate);
        if(noxTypeValue != null)
        {        
            entity.Rate = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"EffectiveAt",dto.EffectiveAt);
        if(noxTypeValue != null)
        {        
            entity.EffectiveAt = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Commission entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("Rate", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Percentage>(entityDefinition,"Rate",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Commission", "Rate");
                }
                else
                {
                    entity.Rate = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("EffectiveAt", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"EffectiveAt",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Commission", "EffectiveAt");
                }
                else
                {
                    entity.EffectiveAt = noxTypeValue;
                }
            }
        }
    }
}