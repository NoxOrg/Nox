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
using SampleWebApp.Application.Dto;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class CountryFactory: EntityFactoryBase<CountryCreateDto, Country>
{
    public  CountryFactory(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    protected override void MapEntity(Country entity, Entity entityDefinition, CountryCreateDto dto)
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
}