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
    
            if(dto.Name != null)
            {        
                entity.Name = CreateNoxType<Text>(entityDefinition,"Name",dto.Name);
            }            
    
            if(dto.FormalName != null)
            {        
                entity.FormalName = CreateNoxType<Text>(entityDefinition,"FormalName",dto.FormalName);
            }            
    // TODO map AlphaCode3 CountryCode3 remaining types and remove if else            
    // TODO map AlphaCode2 CountryCode2 remaining types and remove if else            
    // TODO map NumericCode Number remaining types and remove if else            
    
            if(dto.DialingCodes != null)
            {        
                entity.DialingCodes = CreateNoxType<Text>(entityDefinition,"DialingCodes",dto.DialingCodes);
            }            
    
            if(dto.Capital != null)
            {        
                entity.Capital = CreateNoxType<Text>(entityDefinition,"Capital",dto.Capital);
            }            
    
            if(dto.Demonym != null)
            {        
                entity.Demonym = CreateNoxType<Text>(entityDefinition,"Demonym",dto.Demonym);
            }            
    // TODO map AreaInSquareKilometres Area remaining types and remove if else            
    
            if(dto.GeoRegion != null)
            {        
                entity.GeoRegion = CreateNoxType<Text>(entityDefinition,"GeoRegion",dto.GeoRegion);
            }            
    
            if(dto.GeoSubRegion != null)
            {        
                entity.GeoSubRegion = CreateNoxType<Text>(entityDefinition,"GeoSubRegion",dto.GeoSubRegion);
            }            
    
            if(dto.GeoWorldRegion != null)
            {        
                entity.GeoWorldRegion = CreateNoxType<Text>(entityDefinition,"GeoWorldRegion",dto.GeoWorldRegion);
            }            
    // TODO map Population Number remaining types and remove if else            
    
            if(dto.TopLevelDomains != null)
            {        
                entity.TopLevelDomains = CreateNoxType<Text>(entityDefinition,"TopLevelDomains",dto.TopLevelDomains);
            }
    }
}