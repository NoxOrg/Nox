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

public class CurrencyMapper: EntityMapperBase<Currency>
{
    public  CurrencyMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Currency entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "Id", dto.Id);        
        if(noxTypeValue != null)
        {        
            entity.Id = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",dto.Name);
        if(noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition,"CurrencyIsoNumeric",dto.CurrencyIsoNumeric);
        if(noxTypeValue != null)
        {        
            entity.CurrencyIsoNumeric = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Symbol",dto.Symbol);
        if(noxTypeValue != null)
        {        
            entity.Symbol = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"ThousandsSeparator",dto.ThousandsSeparator);
        if(noxTypeValue != null)
        {        
            entity.ThousandsSeparator = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"DecimalSeparator",dto.DecimalSeparator);
        if(noxTypeValue != null)
        {        
            entity.DecimalSeparator = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"SpaceBetweenAmountAndSymbol",dto.SpaceBetweenAmountAndSymbol);
        if(noxTypeValue != null)
        {        
            entity.SpaceBetweenAmountAndSymbol = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"DecimalDigits",dto.DecimalDigits);
        if(noxTypeValue != null)
        {        
            entity.DecimalDigits = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Currency entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("Name", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CurrencyIsoNumeric", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition,"CurrencyIsoNumeric",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "CurrencyIsoNumeric");
                }
                else
                {
                    entity.CurrencyIsoNumeric = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Symbol", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Symbol",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "Symbol");
                }
                else
                {
                    entity.Symbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("ThousandsSeparator", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"ThousandsSeparator",value);
                if(noxTypeValue == null)
                {
                    entity.ThousandsSeparator = null;
                }
                else
                {
                    entity.ThousandsSeparator = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DecimalSeparator", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"DecimalSeparator",value);
                if(noxTypeValue == null)
                {
                    entity.DecimalSeparator = null;
                }
                else
                {
                    entity.DecimalSeparator = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("SpaceBetweenAmountAndSymbol", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition,"SpaceBetweenAmountAndSymbol",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "SpaceBetweenAmountAndSymbol");
                }
                else
                {
                    entity.SpaceBetweenAmountAndSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DecimalDigits", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"DecimalDigits",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "DecimalDigits");
                }
                else
                {
                    entity.DecimalDigits = noxTypeValue;
                }
            }
        }
    }
}