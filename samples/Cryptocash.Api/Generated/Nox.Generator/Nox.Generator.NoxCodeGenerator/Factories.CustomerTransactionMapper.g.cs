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

public class CustomerTransactionMapper: EntityMapperBase<CustomerTransaction>
{
    public  CustomerTransactionMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CustomerTransaction entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"TransactionType",dto.TransactionType);
        if(noxTypeValue != null)
        {        
            entity.TransactionType = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"ProcessedOnDateTime",dto.ProcessedOnDateTime);
        if(noxTypeValue != null)
        {        
            entity.ProcessedOnDateTime = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",dto.Amount);
        if(noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Reference",dto.Reference);
        if(noxTypeValue != null)
        {        
            entity.Reference = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CustomerTransaction entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("TransactionType", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"TransactionType",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "TransactionType");
                }
                else
                {
                    entity.TransactionType = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("ProcessedOnDateTime", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DateTime>(entityDefinition,"ProcessedOnDateTime",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "ProcessedOnDateTime");
                }
                else
                {
                    entity.ProcessedOnDateTime = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Amount", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "Amount");
                }
                else
                {
                    entity.Amount = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Reference", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Reference",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CustomerTransaction", "Reference");
                }
                else
                {
                    entity.Reference = noxTypeValue;
                }
            }
        }
    }
}