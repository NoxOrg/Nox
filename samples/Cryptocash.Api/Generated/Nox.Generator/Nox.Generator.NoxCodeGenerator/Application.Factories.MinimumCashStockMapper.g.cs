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

public class MinimumCashStockMapper : EntityMapperBase<MinimumCashStock>
{
    public MinimumCashStockMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(MinimumCashStock entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Amount", dto.Amount);
        if (noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
    

        /// <summary>
        /// MinimumCashStock Vending machine's minimum cash stock ExactlyOne VendingMachines
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "VendingMachine", dto.VendingMachineId);
        if (noxTypeValue != null)
        {        
            entity.VendingMachineId = noxTypeValue;
        }

        /// <summary>
        /// MinimumCashStock Cash stock's currency ExactlyOne Currencies
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "Currency", dto.CurrencyId);
        if (noxTypeValue != null)
        {        
            entity.CurrencyId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(MinimumCashStock entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("Amount", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Amount", value);
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
    
    
        /// <summary>
        /// MinimumCashStock Vending machine's minimum cash stock ExactlyOne VendingMachines
        /// </summary>
        if (updatedProperties.TryGetValue("VendingMachineId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "VendingMachine", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.VendingMachineId = noxRelationshipTypeValue;
            }
        }
        /// <summary>
        /// MinimumCashStock Cash stock's currency ExactlyOne Currencies
        /// </summary>
        if (updatedProperties.TryGetValue("CurrencyId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "Currency", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CurrencyId = noxRelationshipTypeValue;
            }
        }
    }
}