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
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class CountryFactory: EntityFactoryBase<CountryDto, Country>
{
    public  CountryFactory(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    protected override void MapEntity(Country entity, Entity entityDefinition, CountryDto dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"Name",dto.Name);
            if(noxTypeValue != null)
            {        
                entity.Name = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"FormalName",dto.FormalName);
            if(noxTypeValue != null)
            {        
                entity.FormalName = noxTypeValue;
            }            
    // TODO map AlphaCode3 CountryCode3 remaining types and remove if else            
    // TODO map AlphaCode2 CountryCode2 remaining types and remove if else            
    
            noxTypeValue =  CreateNoxType<Number>(entityDefinition,"NumericCode",dto.NumericCode);
            if(noxTypeValue != null)
            {        
                entity.NumericCode = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"DialingCodes",dto.DialingCodes);
            if(noxTypeValue != null)
            {        
                entity.DialingCodes = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"Capital",dto.Capital);
            if(noxTypeValue != null)
            {        
                entity.Capital = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"Demonym",dto.Demonym);
            if(noxTypeValue != null)
            {        
                entity.Demonym = noxTypeValue;
            }            
    // TODO map AreaInSquareKilometres Area remaining types and remove if else            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"GeoRegion",dto.GeoRegion);
            if(noxTypeValue != null)
            {        
                entity.GeoRegion = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"GeoSubRegion",dto.GeoSubRegion);
            if(noxTypeValue != null)
            {        
                entity.GeoSubRegion = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"GeoWorldRegion",dto.GeoWorldRegion);
            if(noxTypeValue != null)
            {        
                entity.GeoWorldRegion = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Number>(entityDefinition,"Population",dto.Population);
            if(noxTypeValue != null)
            {        
                entity.Population = noxTypeValue;
            }            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"TopLevelDomains",dto.TopLevelDomains);
            if(noxTypeValue != null)
            {        
                entity.TopLevelDomains = noxTypeValue;
            }
    }
}