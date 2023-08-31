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

public class HolidaysMapper : EntityMapperBase<Holidays>
{
    public HolidaysMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Holidays entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Year>(entityDefinition, "Year", dto.Year);
        if (noxTypeValue != null)
        {        
            entity.Year = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DayOfWeek>(entityDefinition, "DayOff", dto.DayOff);
        if (noxTypeValue != null)
        {        
            entity.DayOff = noxTypeValue;
        }
    

        /// <summary>
        /// Holidays The related country ExactlyOne Countries
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "Country", dto.CountryId);
        if (noxTypeValue != null)
        {        
            entity.CountryId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Holidays entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
    {
#pragma warning disable CS0168 // Variable is assigned but its value is never used
        dynamic? value;
#pragma warning restore CS0168 // Variable is assigned but its value is never used
        {
            if (updatedProperties.TryGetValue("Year", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Year>(entityDefinition, "Year", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Holidays", "Year");
                }
                else
                {
                    entity.Year = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DayOff", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DayOfWeek>(entityDefinition, "DayOff", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Holidays", "DayOff");
                }
                else
                {
                    entity.DayOff = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Holidays The related country ExactlyOne Countries
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