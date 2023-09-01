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
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;
using CurrencyCashBalance = SampleWebApp.Domain.CurrencyCashBalance;

namespace SampleWebApp.Application;

public class CurrencyCashBalanceMapper : EntityMapperBase<CurrencyCashBalance>
{
    public CurrencyCashBalanceMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CurrencyCashBalance entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "StoreId", dto.StoreId);        
        if (noxTypeValue != null)
        {        
            entity.StoreId = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.Nuid>(entityDefinition, "CurrencyId", dto.CurrencyId);        
        if (noxTypeValue != null)
        {        
            entity.CurrencyId = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "Amount", dto.Amount);
        if (noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "OperationLimit", dto.OperationLimit);
        if (noxTypeValue != null)
        {        
            entity.OperationLimit = noxTypeValue;
        }
    
    }

    public override void PartialMapToEntity(CurrencyCashBalance entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("CurrencyCashBalance", "Amount");
                }
                else
                {
                    entity.Amount = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("OperationLimit", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "OperationLimit", value);
                if(noxTypeValue == null)
                {
                    entity.OperationLimit = null;
                }
                else
                {
                    entity.OperationLimit = noxTypeValue;
                }
            }
        }
    
    
    }
}