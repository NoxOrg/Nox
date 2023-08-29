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

public class CurrencyMapper : EntityMapperBase<Currency>
{
    public CurrencyMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Currency entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "Id", dto.Id);        
        if (noxTypeValue != null)
        {        
            entity.Id = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition, "CurrencyIsoNumeric", dto.CurrencyIsoNumeric);
        if (noxTypeValue != null)
        {        
            entity.CurrencyIsoNumeric = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Symbol", dto.Symbol);
        if (noxTypeValue != null)
        {        
            entity.Symbol = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "ThousandsSeperator", dto.ThousandsSeperator);
        if (noxTypeValue != null)
        {        
            entity.ThousandsSeperator = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "DecimalSeparator", dto.DecimalSeparator);
        if (noxTypeValue != null)
        {        
            entity.DecimalSeparator = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "SpaceBetweenAmountAndSymbol", dto.SpaceBetweenAmountAndSymbol);
        if (noxTypeValue != null)
        {        
            entity.SpaceBetweenAmountAndSymbol = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "DecimalDigits", dto.DecimalDigits);
        if (noxTypeValue != null)
        {        
            entity.DecimalDigits = noxTypeValue;
        }
    

        /// <summary>
        /// Currency The currency's related units major and minor ExactlyOne CurrencyUnits
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "Unit", dto.CurrencyUnitsId);
        if (noxTypeValue != null)
        {        
            entity.CurrencyUnitsId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Currency entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("Name", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", value);
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
            if (updatedProperties.TryGetValue("CurrencyIsoNumeric", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition, "CurrencyIsoNumeric", value);
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
            if (updatedProperties.TryGetValue("Symbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Symbol", value);
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
            if (updatedProperties.TryGetValue("ThousandsSeperator", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "ThousandsSeperator", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "ThousandsSeperator");
                }
                else
                {
                    entity.ThousandsSeperator = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DecimalSeparator", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "DecimalSeparator", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "DecimalSeparator");
                }
                else
                {
                    entity.DecimalSeparator = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("SpaceBetweenAmountAndSymbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "SpaceBetweenAmountAndSymbol", value);
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
            if (updatedProperties.TryGetValue("DecimalDigits", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "DecimalDigits", value);
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
    
    
        /// <summary>
        /// Currency The currency's related units major and minor ExactlyOne CurrencyUnits
        /// </summary>
        if (updatedProperties.TryGetValue("CurrencyUnitsId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.DatabaseNumber>(entityDefinition, "Unit", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CurrencyUnitsId = noxRelationshipTypeValue;
            }
        }
    }
}