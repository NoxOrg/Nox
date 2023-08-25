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

public class MinimumCashStockMapper: EntityMapperBase<MinimumCashStock>
{
    public  MinimumCashStockMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(MinimumCashStock entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",dto.Amount);
        if(noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(MinimumCashStock entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("Amount", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("MinimumCashStock", "Amount");
                }
                else
                {
                    entity.Amount = noxTypeValue;
                }
            }
        }
    }
}