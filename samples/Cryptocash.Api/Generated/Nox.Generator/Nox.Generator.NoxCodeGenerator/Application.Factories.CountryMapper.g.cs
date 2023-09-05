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
using Country = Cryptocash.Domain.Country;

namespace Cryptocash.Application;

public class CountryMapper : EntityMapperBase<Country>
{
    public CountryMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Country entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
            
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "Id", dto.Id);        
        if (noxTypeValue != null)
        {        
            entity.Id = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "OfficialName", dto.OfficialName);
        if (noxTypeValue != null)
        {        
            entity.OfficialName = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.CountryNumber>(entityDefinition, "CountryIsoNumeric", dto.CountryIsoNumeric);
        if (noxTypeValue != null)
        {        
            entity.CountryIsoNumeric = noxTypeValue;
        }

        // TODO map CountryIsoAlpha3 CountryCode3 remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition, "GeoCoords", dto.GeoCoords);
        if (noxTypeValue != null)
        {        
            entity.GeoCoords = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "FlagEmoji", dto.FlagEmoji);
        if (noxTypeValue != null)
        {        
            entity.FlagEmoji = noxTypeValue;
        }

        // TODO map FlagSvg Image remaining types and remove if else

        // TODO map FlagPng Image remaining types and remove if else

        // TODO map CoatOfArmsSvg Image remaining types and remove if else

        // TODO map CoatOfArmsPng Image remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Url>(entityDefinition, "GoogleMapsUrl", dto.GoogleMapsUrl);
        if (noxTypeValue != null)
        {        
            entity.GoogleMapsUrl = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Url>(entityDefinition, "OpenStreetMapsUrl", dto.OpenStreetMapsUrl);
        if (noxTypeValue != null)
        {        
            entity.OpenStreetMapsUrl = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.DayOfWeek>(entityDefinition, "StartOfWeek", dto.StartOfWeek);
        if (noxTypeValue != null)
        {        
            entity.StartOfWeek = noxTypeValue;
        }
    

        /// <summary>
        /// Country used by ExactlyOne Currencies
        /// </summary>
        noxTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "CountryUsedByCurrency", dto.CurrencyId);
        if (noxTypeValue != null)
        {        
            entity.CurrencyId = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Country entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties)
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
                    throw new EntityAttributeIsNotNullableException("Country", "Name");
                }
                else
                {
                    entity.Name = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("OfficialName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "OfficialName", value);
                if(noxTypeValue == null)
                {
                    entity.OfficialName = null;
                }
                else
                {
                    entity.OfficialName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryIsoNumeric", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryNumber>(entityDefinition, "CountryIsoNumeric", value);
                if(noxTypeValue == null)
                {
                    entity.CountryIsoNumeric = null;
                }
                else
                {
                    entity.CountryIsoNumeric = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CountryIsoAlpha3", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryCode3>(entityDefinition, "CountryIsoAlpha3", value);
                if(noxTypeValue == null)
                {
                    entity.CountryIsoAlpha3 = null;
                }
                else
                {
                    entity.CountryIsoAlpha3 = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GeoCoords", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition, "GeoCoords", value);
                if(noxTypeValue == null)
                {
                    entity.GeoCoords = null;
                }
                else
                {
                    entity.GeoCoords = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FlagEmoji", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "FlagEmoji", value);
                if(noxTypeValue == null)
                {
                    entity.FlagEmoji = null;
                }
                else
                {
                    entity.FlagEmoji = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FlagSvg", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Image>(entityDefinition, "FlagSvg", value);
                if(noxTypeValue == null)
                {
                    entity.FlagSvg = null;
                }
                else
                {
                    entity.FlagSvg = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("FlagPng", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Image>(entityDefinition, "FlagPng", value);
                if(noxTypeValue == null)
                {
                    entity.FlagPng = null;
                }
                else
                {
                    entity.FlagPng = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CoatOfArmsSvg", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Image>(entityDefinition, "CoatOfArmsSvg", value);
                if(noxTypeValue == null)
                {
                    entity.CoatOfArmsSvg = null;
                }
                else
                {
                    entity.CoatOfArmsSvg = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("CoatOfArmsPng", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Image>(entityDefinition, "CoatOfArmsPng", value);
                if(noxTypeValue == null)
                {
                    entity.CoatOfArmsPng = null;
                }
                else
                {
                    entity.CoatOfArmsPng = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GoogleMapsUrl", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Url>(entityDefinition, "GoogleMapsUrl", value);
                if(noxTypeValue == null)
                {
                    entity.GoogleMapsUrl = null;
                }
                else
                {
                    entity.GoogleMapsUrl = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("OpenStreetMapsUrl", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Url>(entityDefinition, "OpenStreetMapsUrl", value);
                if(noxTypeValue == null)
                {
                    entity.OpenStreetMapsUrl = null;
                }
                else
                {
                    entity.OpenStreetMapsUrl = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("StartOfWeek", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.DayOfWeek>(entityDefinition, "StartOfWeek", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "StartOfWeek");
                }
                else
                {
                    entity.StartOfWeek = noxTypeValue;
                }
            }
        }
    
    
        /// <summary>
        /// Country used by ExactlyOne Currencies
        /// </summary>
        if (updatedProperties.TryGetValue("CurrencyId", out value))
        {
            var noxRelationshipTypeValue = CreateNoxType<Nox.Types.CurrencyCode3>(entityDefinition, "CountryUsedByCurrency", value);
            if (noxRelationshipTypeValue != null)
            {        
                entity.CurrencyId = noxRelationshipTypeValue;
            }
        }
    }
}