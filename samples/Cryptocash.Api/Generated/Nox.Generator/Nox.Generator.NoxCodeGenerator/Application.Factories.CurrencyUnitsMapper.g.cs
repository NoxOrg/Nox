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
using CurrencyUnits = CryptocashApi.Domain.CurrencyUnits;

namespace CryptocashApi.Application;

public class CurrencyUnitsMapper: EntityMapperBase<CurrencyUnits>
{
    public  CurrencyUnitsMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CurrencyUnits entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MajorName",dto.MajorName);
        if(noxTypeValue != null)
        {        
            entity.MajorName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MajorSymbol",dto.MajorSymbol);
        if(noxTypeValue != null)
        {        
            entity.MajorSymbol = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MinorName",dto.MinorName);
        if(noxTypeValue != null)
        {        
            entity.MinorName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MinorSymbol",dto.MinorSymbol);
        if(noxTypeValue != null)
        {        
            entity.MinorSymbol = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"MinorToMajorValue",dto.MinorToMajorValue);
        if(noxTypeValue != null)
        {        
            entity.MinorToMajorValue = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CurrencyUnits entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("MajorName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MajorName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CurrencyUnits", "MajorName");
                }
                else
                {
                    entity.MajorName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MajorSymbol", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MajorSymbol",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CurrencyUnits", "MajorSymbol");
                }
                else
                {
                    entity.MajorSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorName", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MinorName",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CurrencyUnits", "MinorName");
                }
                else
                {
                    entity.MinorName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorSymbol", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"MinorSymbol",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CurrencyUnits", "MinorSymbol");
                }
                else
                {
                    entity.MinorSymbol = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("MinorToMajorValue", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Money>(entityDefinition,"MinorToMajorValue",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CurrencyUnits", "MinorToMajorValue");
                }
                else
                {
                    entity.MinorToMajorValue = noxTypeValue;
                }
            }
        }
    }
}