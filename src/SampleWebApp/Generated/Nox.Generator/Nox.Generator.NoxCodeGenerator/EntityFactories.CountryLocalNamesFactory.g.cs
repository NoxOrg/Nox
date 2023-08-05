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

public class CountryLocalNamesFactory: EntityFactoryBase<CountryLocalNamesCreateDto, CountryLocalNames>
{
    public  CountryLocalNamesFactory(NoxSolution noxSolution, IServiceProvider serviceProvider): base(noxSolution, serviceProvider) { }

    protected override void MapEntity(CountryLocalNames entity, Entity entityDefinition, CountryLocalNamesCreateDto dto)
    {
    #pragma warning disable CS0168 // Variable is declared but never used        
        dynamic? noxTypeValue;
    #pragma warning restore CS0168 // Variable is declared but never used
    
    }
}