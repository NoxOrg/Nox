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
using ClientApi.Application.Dto;
using ClientApi.Domain;
using CountryBarCode = ClientApi.Domain.CountryBarCode;

namespace ClientApi.Application;

public partial class CountryBarCodeMapper : EntityMapperBase<CountryBarCode>
{
    public CountryBarCodeMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CountryBarCode entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used        
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "BarCodeName", dto.BarCodeName);
        if (noxTypeValue == null)
        {
            throw new NullReferenceException("BarCodeName is required can not be set to null");
        }     
        entity.BarCodeName = noxTypeValue;        
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "BarCodeNumber", dto.BarCodeNumber);     
        entity.BarCodeNumber = noxTypeValue;
    
    }

    public override void PartialMapToEntity(CountryBarCode entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("BarCodeName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "BarCodeName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CountryBarCode", "BarCodeName");
                }
                else
                {
                    entity.BarCodeName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("BarCodeNumber", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "BarCodeNumber", value);
                if(noxTypeValue == null)
                {
                    entity.BarCodeNumber = null;
                }
                else
                {
                    entity.BarCodeNumber = noxTypeValue;
                }
            }
        }
    
    
    }
}