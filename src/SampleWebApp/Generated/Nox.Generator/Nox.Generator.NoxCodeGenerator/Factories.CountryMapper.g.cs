// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class CountryMapper: EntityMapperBase<Country>
{
    public  CountryMapper(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    public override void MapToEntity(Country entity, Entity entityDefinition, dynamic dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Name",dto.Name);
        if(noxTypeValue != null)
        {        
            entity.Name = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"FormalName",dto.FormalName);
        if(noxTypeValue != null)
        {        
            entity.FormalName = noxTypeValue;
        }

        // TODO map AlphaCode3 CountryCode3 remaining types and remove if else

        // TODO map AlphaCode2 CountryCode2 remaining types and remove if else
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"NumericCode",dto.NumericCode);
        if(noxTypeValue != null)
        {        
            entity.NumericCode = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"DialingCodes",dto.DialingCodes);
        if(noxTypeValue != null)
        {        
            entity.DialingCodes = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Capital",dto.Capital);
        if(noxTypeValue != null)
        {        
            entity.Capital = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"Demonym",dto.Demonym);
        if(noxTypeValue != null)
        {        
            entity.Demonym = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Area>(entityDefinition,"AreaInSquareKilometres",dto.AreaInSquareKilometres);
        if(noxTypeValue != null)
        {        
            entity.AreaInSquareKilometres = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.LatLong>(entityDefinition,"GeoCoord",dto.GeoCoord);
        if(noxTypeValue != null)
        {        
            entity.GeoCoord = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"GeoRegion",dto.GeoRegion);
        if(noxTypeValue != null)
        {        
            entity.GeoRegion = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"GeoSubRegion",dto.GeoSubRegion);
        if(noxTypeValue != null)
        {        
            entity.GeoSubRegion = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"GeoWorldRegion",dto.GeoWorldRegion);
        if(noxTypeValue != null)
        {        
            entity.GeoWorldRegion = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Number>(entityDefinition,"Population",dto.Population);
        if(noxTypeValue != null)
        {        
            entity.Population = noxTypeValue;
        }
        noxTypeValue = CreateNoxType<Nox.Types.Text>(entityDefinition,"TopLevelDomains",dto.TopLevelDomains);
        if(noxTypeValue != null)
        {        
            entity.TopLevelDomains = noxTypeValue;
        }
    }

    public override void PartialMapToEntity(Country entity, Entity entityDefinition, Dictionary<string, dynamic> updatedProperties, HashSet<string> deletedPropertyNames)
    {
      
        if(deletedPropertyNames.Contains("Name"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "Name");
        }  
        if(deletedPropertyNames.Contains("FormalName"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "FormalName");
        }  
        if(deletedPropertyNames.Contains("AlphaCode3"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "AlphaCode3");
        }  
        if(deletedPropertyNames.Contains("AlphaCode2"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "AlphaCode2");
        }  
        if(deletedPropertyNames.Contains("NumericCode"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "NumericCode");
        }  
        if(deletedPropertyNames.Contains("DialingCodes"))
        {
            entity.DialingCodes = null;
        }  
        if(deletedPropertyNames.Contains("Capital"))
        {
            entity.Capital = null;
        }  
        if(deletedPropertyNames.Contains("Demonym"))
        {
            entity.Demonym = null;
        }  
        if(deletedPropertyNames.Contains("AreaInSquareKilometres"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "AreaInSquareKilometres");
        }  
        if(deletedPropertyNames.Contains("GeoCoord"))
        {
            entity.GeoCoord = null;
        }  
        if(deletedPropertyNames.Contains("GeoRegion"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "GeoRegion");
        }  
        if(deletedPropertyNames.Contains("GeoSubRegion"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "GeoSubRegion");
        }  
        if(deletedPropertyNames.Contains("GeoWorldRegion"))
        {
            throw new EntityAttributeIsNotNullableException("Country", "GeoWorldRegion");
        }  
        if(deletedPropertyNames.Contains("Population"))
        {
            entity.Population = null;
        }  
        if(deletedPropertyNames.Contains("TopLevelDomains"))
        {
            entity.TopLevelDomains = null;
        }    
    }
}