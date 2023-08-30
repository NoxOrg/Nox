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

public class CountryTimeZonesMapper: EntityMapperBase<CountryTimeZones>
{
    public  CountryTimeZonesMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CountryTimeZones entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition,"TimeZoneCode",dto.TimeZoneCode);
        if(noxTypeValue != null)
        {        
            entity.TimeZoneCode = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CountryTimeZones entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
        {
            if (updatedProperties.TryGetValue("TimeZoneCode", out dynamic? value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition,"TimeZoneCode",value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CountryTimeZones", "TimeZoneCode");
                }
                else
                {
                    entity.TimeZoneCode = noxTypeValue;
                }
            }
        }
    }
}