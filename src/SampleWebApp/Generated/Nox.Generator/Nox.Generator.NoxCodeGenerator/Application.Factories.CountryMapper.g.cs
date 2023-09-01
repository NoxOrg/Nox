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
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;
using Country = SampleWebApp.Domain.Country;

namespace SampleWebApp.Application;

public class CountryMapper : EntityMapperBase<Country>
{
    public CountryMapper(NoxSolution noxSolution, IServiceProvider serviceProvider) : base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Country entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Name", dto.Name);
        if (noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "FormalName", dto.FormalName);
        if (noxTypeValue != null)
        {        
            entity.FormalName = noxTypeValue;
        }

        // TODO map AlphaCode3 CountryCode3 remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "AlphaCode2", dto.AlphaCode2);
        if (noxTypeValue != null)
        {        
            entity.AlphaCode2 = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "NumericCode", dto.NumericCode);
        if (noxTypeValue != null)
        {        
            entity.NumericCode = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "DialingCodes", dto.DialingCodes);
        if (noxTypeValue != null)
        {        
            entity.DialingCodes = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Capital", dto.Capital);
        if (noxTypeValue != null)
        {        
            entity.Capital = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Demonym", dto.Demonym);
        if (noxTypeValue != null)
        {        
            entity.Demonym = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition, "AreaInSquareKilometres", dto.AreaInSquareKilometres);
        if (noxTypeValue != null)
        {        
            entity.AreaInSquareKilometres = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition, "GeoCoord", dto.GeoCoord);
        if (noxTypeValue != null)
        {        
            entity.GeoCoord = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "GeoRegion", dto.GeoRegion);
        if (noxTypeValue != null)
        {        
            entity.GeoRegion = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "GeoSubRegion", dto.GeoSubRegion);
        if (noxTypeValue != null)
        {        
            entity.GeoSubRegion = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "GeoWorldRegion", dto.GeoWorldRegion);
        if (noxTypeValue != null)
        {        
            entity.GeoWorldRegion = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "Population", dto.Population);
        if (noxTypeValue != null)
        {        
            entity.Population = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "TopLevelDomains", dto.TopLevelDomains);
        if (noxTypeValue != null)
        {        
            entity.TopLevelDomains = noxTypeValue;
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
            if (updatedProperties.TryGetValue("FormalName", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "FormalName", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "FormalName");
                }
                else
                {
                    entity.FormalName = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("AlphaCode3", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryCode3>(entityDefinition, "AlphaCode3", value);
                if(noxTypeValue == null)
                {
                    entity.AlphaCode3 = null;
                }
                else
                {
                    entity.AlphaCode3 = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("AlphaCode2", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.CountryCode2>(entityDefinition, "AlphaCode2", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "AlphaCode2");
                }
                else
                {
                    entity.AlphaCode2 = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("NumericCode", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "NumericCode", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "NumericCode");
                }
                else
                {
                    entity.NumericCode = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("DialingCodes", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "DialingCodes", value);
                if(noxTypeValue == null)
                {
                    entity.DialingCodes = null;
                }
                else
                {
                    entity.DialingCodes = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Capital", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Capital", value);
                if(noxTypeValue == null)
                {
                    entity.Capital = null;
                }
                else
                {
                    entity.Capital = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Demonym", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "Demonym", value);
                if(noxTypeValue == null)
                {
                    entity.Demonym = null;
                }
                else
                {
                    entity.Demonym = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("AreaInSquareKilometres", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition, "AreaInSquareKilometres", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "AreaInSquareKilometres");
                }
                else
                {
                    entity.AreaInSquareKilometres = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GeoCoord", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition, "GeoCoord", value);
                if(noxTypeValue == null)
                {
                    entity.GeoCoord = null;
                }
                else
                {
                    entity.GeoCoord = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GeoRegion", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "GeoRegion", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "GeoRegion");
                }
                else
                {
                    entity.GeoRegion = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GeoSubRegion", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "GeoSubRegion", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "GeoSubRegion");
                }
                else
                {
                    entity.GeoSubRegion = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("GeoWorldRegion", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "GeoWorldRegion", value);
                if(noxTypeValue == null)
                {
                    throw new EntityAttributeIsNotNullableException("Country", "GeoWorldRegion");
                }
                else
                {
                    entity.GeoWorldRegion = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("Population", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition, "Population", value);
                if(noxTypeValue == null)
                {
                    entity.Population = null;
                }
                else
                {
                    entity.Population = noxTypeValue;
                }
            }
        }
        {
            if (updatedProperties.TryGetValue("TopLevelDomains", out value))
            {
                var noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition, "TopLevelDomains", value);
                if(noxTypeValue == null)
                {
                    entity.TopLevelDomains = null;
                }
                else
                {
                    entity.TopLevelDomains = noxTypeValue;
                }
            }
        }
    
    
    }
}