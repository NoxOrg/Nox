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
using Currency = Cryptocash.Domain.Currency;

namespace Cryptocash.Application;

public partial class CurrencyMapper : EntityMapperBase<Currency>
{
    public CurrencyMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Currency entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used

            
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue == null)
        {
            throw new Exception("Name is required can not be set to null");
        }     
            entity.Name = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.CurrencyNumber>(entityDefinition, "CurrencyIsoNumeric", dto.CurrencyIsoNumeric);
        if (noxTypeValue == null)
        {
            throw new Exception("CurrencyIsoNumeric is required can not be set to null");
        }     
            entity.CurrencyIsoNumeric = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Symbol", dto.Symbol);
        if (noxTypeValue == null)
        {
            throw new Exception("Symbol is required can not be set to null");
        }     
            entity.Symbol = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "ThousandsSeparator", dto.ThousandsSeparator);     
            entity.ThousandsSeparator = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "DecimalSeparator", dto.DecimalSeparator);     
            entity.DecimalSeparator = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Boolean>(entityDefinition, "SpaceBetweenAmountAndSymbol", dto.SpaceBetweenAmountAndSymbol);
        if (noxTypeValue == null)
        {
            throw new Exception("SpaceBetweenAmountAndSymbol is required can not be set to null");
        }     
            entity.SpaceBetweenAmountAndSymbol = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "DecimalDigits", dto.DecimalDigits);
        if (noxTypeValue == null)
        {
            throw new Exception("DecimalDigits is required can not be set to null");
        }     
            entity.DecimalDigits = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MajorName", dto.MajorName);
        if (noxTypeValue == null)
        {
            throw new Exception("MajorName is required can not be set to null");
        }     
            entity.MajorName = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MajorSymbol", dto.MajorSymbol);
        if (noxTypeValue == null)
        {
            throw new Exception("MajorSymbol is required can not be set to null");
        }     
            entity.MajorSymbol = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MinorName", dto.MinorName);
        if (noxTypeValue == null)
        {
            throw new Exception("MinorName is required can not be set to null");
        }     
            entity.MinorName = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MinorSymbol", dto.MinorSymbol);
        if (noxTypeValue == null)
        {
            throw new Exception("MinorSymbol is required can not be set to null");
        }     
            entity.MinorSymbol = noxTypeValue;        
            noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "MinorToMajorValue", dto.MinorToMajorValue);
        if (noxTypeValue == null)
        {
            throw new Exception("MinorToMajorValue is required can not be set to null");
        }     
            entity.MinorToMajorValue = noxTypeValue;
    
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
            if (updatedProperties.TryGetValue("ThousandsSeparator", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "ThousandsSeparator", value);
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
            if (updatedProperties.TryGetValue("DecimalSeparator", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "DecimalSeparator", value);
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
        {
            if (updatedProperties.TryGetValue("MajorName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MajorName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MajorName");
                }
                else
                {
                    entity.MajorName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MajorSymbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MajorSymbol", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MajorSymbol");
                }
                else
                {
                    entity.MajorSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MinorName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MinorName");
                }
                else
                {
                    entity.MinorName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorSymbol", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "MinorSymbol", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MinorSymbol");
                }
                else
                {
                    entity.MinorSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorToMajorValue", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition, "MinorToMajorValue", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Currency", "MinorToMajorValue");
                }
                else
                {
                    entity.MinorToMajorValue = noxTypeValue;
                }
            }
        }
    
    
    }
}