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

public class VendingMachineOrderMapper : EntityMapperBase<VendingMachineOrder>
{
    public VendingMachineOrderMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(VendingMachineOrder entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Amount", dto.Amount);
        if (noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition, "RequestedDeliveryDate", dto.RequestedDeliveryDate);
        if (noxTypeValue != null)
        {        
            entity.RequestedDeliveryDate = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition, "DeliveryDateTime", dto.DeliveryDateTime);
        if (noxTypeValue != null)
        {        
            entity.DeliveryDateTime = noxTypeValue;
        }
    

        /// <summary>
        /// VendingMachineOrder The order's related vending machine ExactlyOne VendingMachines
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "VendingMachine", dto.VendingMachineId);
        if (noxTypeValue != null)
        {        
            entity.VendingMachineId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(VendingMachineOrder entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("VendingMachineOrder", "Amount");
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
                    entity.RequestedDeliveryDate = null;
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
        /// VendingMachineOrder The order's related vending machine ExactlyOne VendingMachines
        /// </summary>
        if (updatedProperties.TryGetValue("VendingMachineId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseGuid>(entityDefinition, "VendingMachine", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.VendingMachineId = noxRelationshipTypeValue;
            }
        }
    }
}