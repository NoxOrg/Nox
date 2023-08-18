// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class CurrencyCashBalanceMapper: EntityMapperBase<CurrencyCashBalance>
{
    public  CurrencyCashBalanceMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CurrencyCashBalance entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "StoreId", dto.StoreId);        
        if(noxTypeValue != null)
        {        
            entity.StoreId = noxTypeValue;
        }        
        noxTypeValue = CreateNoxType<Nox.Types.Nuid>(entityDefinition, "CurrencyId", dto.CurrencyId);        
        if(noxTypeValue != null)
        {        
            entity.CurrencyId = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",dto.Amount);
        if(noxTypeValue != null)
        {        
            entity.Amount = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"OperationLimit",dto.OperationLimit);
        if(noxTypeValue != null)
        {        
            entity.OperationLimit = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CurrencyCashBalance entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, HashSet<string> deletedPropertyNames)
    {    
        if(deletedPropertyNames.Contains("Amount"))
        {
            throw new EntityAttributeIsNotNullableException("CurrencyCashBalance", "Amount");
        }
        else if (updatedProperties.TryGetValue("Amount", out dynamic? value))
        {
            var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"Amount",value);
            if(noxTypeValue == null)
            {
                throw new EntityAttributeIsNotNullableException("CurrencyCashBalance", "Amount");
            }
            else
            {
                entity.Amount = noxTypeValue;
            }
        }    
        if(deletedPropertyNames.Contains("OperationLimit"))
        {
            entity.OperationLimit = null;
        }
        else if (updatedProperties.TryGetValue("OperationLimit", out dynamic? value))
        {
            var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"OperationLimit",value);
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