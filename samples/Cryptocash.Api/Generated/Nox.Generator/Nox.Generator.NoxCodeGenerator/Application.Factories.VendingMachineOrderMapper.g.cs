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
using VendingMachineOrder = CryptocashApi.Domain.VendingMachineOrder;

namespace CryptocashApi.Application;

public class VendingMachineOrderMapper: EntityMapperBase<VendingMachineOrder>
{
    public  VendingMachineOrderMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(VendingMachineOrder entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",dto.Amount);
        if(noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"RequestedDeliveryDate",dto.RequestedDeliveryDate);
        if(noxTypeValue != null)
        {        
            entity.RequestedDeliveryDate = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"DeliveryDateTime",dto.DeliveryDateTime);
        if(noxTypeValue != null)
        {        
            entity.DeliveryDateTime = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(VendingMachineOrder entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("Amount", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",value);
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
            if (updatedProperties.TryGetValue("RequestedDeliveryDate", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Date>(entityDefinition,"RequestedDeliveryDate",value);
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
            if (updatedProperties.TryGetValue("DeliveryDateTime", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"DeliveryDateTime",value);
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
    }
}