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

public class AllNoxTypeFactory: EntityFactoryBase<AllNoxTypeDto, AllNoxType>
{
    public  AllNoxTypeFactory(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    protected override void MapEntity(AllNoxType entity, Entity entityDefinition, AllNoxTypeDto dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used            
    
            noxTypeValue =  CreateNoxType<Text>(entityDefinition,"TextField",dto.TextField);
            if(noxTypeValue != null)
            {        
                entity.TextField = noxTypeValue;
            }            
    // TODO map VatNumberField VatNumber remaining types and remove if else            
    // TODO map CountryCode2Field CountryCode2 remaining types and remove if else            
    // TODO map CountryCode3Field CountryCode3 remaining types and remove if else            
    // TODO map FormulaField Formula remaining types and remove if else
    }
}