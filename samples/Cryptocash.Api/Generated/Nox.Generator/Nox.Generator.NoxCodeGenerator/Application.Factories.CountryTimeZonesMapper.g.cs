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
using CountryTimeZones = Cryptocash.Domain.CountryTimeZones;

namespace Cryptocash.Application;

public class CountryTimeZonesMapper : EntityMapperBase<CountryTimeZones>
{
    public CountryTimeZonesMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(CountryTimeZones entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.TimeZoneCode>(entityDefinition, "TimeZoneCode", dto.TimeZoneCode);
        if (noxTypeValue != null)
        {        
            entity.TimeZoneCode = noxTypeValue;
        }
    

        /// <summary>
        /// CountryTimeZones Country's time zones ExactlyOne Countries
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "Country", dto.CountryId);
        if (noxTypeValue != null)
        {        
            entity.CountryId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(CountryTimeZones entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("CountryTimeZones", "TimeZoneCode");
                }
                else
                {
                    entity.TimeZoneCode = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// CountryTimeZones Country's time zones ExactlyOne Countries
        /// </summary>
        if (updatedProperties.TryGetValue("CountryId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "Country", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CountryId = noxRelationshipTypeValue;
            }
        }
    }
}