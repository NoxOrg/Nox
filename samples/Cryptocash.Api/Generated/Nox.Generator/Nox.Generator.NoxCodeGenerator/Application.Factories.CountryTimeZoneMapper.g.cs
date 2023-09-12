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
using CountryTimeZone = Cryptocash.Domain.CountryTimeZone;

namespace Cryptocash.Application;

public partial class CountryTimeZoneMapper : EntityMapperBase<CountryTimeZone>
{
    public CountryTimeZoneMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CountryTimeZone entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used        
        noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition, "TimeZoneCode", dto.TimeZoneCode);
        if (noxTypeValue == null)
        {
            throw new NullReferenceException("TimeZoneCode is required can not be set to null");
        }     
        entity.TimeZoneCode = noxTypeValue;
    
    }

    public override void PartialMapToEntity(CountryTimeZone entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("TimeZoneCode", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition, "TimeZoneCode", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("CountryTimeZone", "TimeZoneCode");
                }
                else
                {
                    entity.TimeZoneCode = noxTypeValue;
                }
            }
        }
    
    
    }
}