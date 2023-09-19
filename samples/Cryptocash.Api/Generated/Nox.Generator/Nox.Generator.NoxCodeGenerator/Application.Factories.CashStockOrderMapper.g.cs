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
using CashStockOrder = Cryptocash.Domain.CashStockOrder;

namespace Cryptocash.Application;

public partial class CashStockOrderMapper : EntityMapperBase<CashStockOrder>
{
    public CashStockOrderMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CashStockOrder entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used        
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Amount", dto.Amount);
        if (noxTypeValue == null)
        {
            throw new NullReferenceException("Amount is required can not be set to null");
        }     
        entity.Amount = noxTypeValue;        
        noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "RequestedDeliveryDate", dto.RequestedDeliveryDate);
        if (noxTypeValue == null)
        {
            throw new NullReferenceException("RequestedDeliveryDate is required can not be set to null");
        }     
        entity.RequestedDeliveryDate = noxTypeValue;        
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "DeliveryDateTime", dto.DeliveryDateTime);     
        entity.DeliveryDateTime = noxTypeValue;
    

        /// <summary>
        /// CashStockOrder for ExactlyOne VendingMachines
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition, "CashStockOrderForVendingMachine", dto.CashStockOrderForVendingMachineId);
        if (noxTypeValue != null)
        {        
            entity.CashStockOrderForVendingMachineId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CashStockOrder entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("CashStockOrder", "Amount");
                }
                else
                {
                    entity.Amount = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("RequestedDeliveryDate", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "RequestedDeliveryDate", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CashStockOrder", "RequestedDeliveryDate");
                }
                else
                {
                    entity.RequestedDeliveryDate = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DeliveryDateTime", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "DeliveryDateTime", value);
                if(noxTypeValue == null)
                {
                    entity.DeliveryDateTime = null;
                }
                else
                {
                    entity.DeliveryDateTime = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// CashStockOrder for ExactlyOne VendingMachines
        /// </summary>
        if (updatedProperties.TryGetValue("VendingMachineId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.Guid>(entityDefinition, "CashStockOrderForVendingMachine", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CashStockOrderForVendingMachineId = noxRelationshipTypeValue;
            }
        }
    }
}