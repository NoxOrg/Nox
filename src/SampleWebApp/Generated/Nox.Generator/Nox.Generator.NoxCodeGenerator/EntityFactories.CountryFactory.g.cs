// Generated

#nullable enable

using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Domain;
using Nox.Application;
using SampleWebApp.Presentation.Api.OData;
using SampleWebApp.Domain;


namespace SampleWebApp.Application;

public class CountryFactory: EntityFactoryBase<OCountry, Country>
{
    public  CountryFactory(NoxSolution noxSolution): base(noxSolution) { }

    protected override void MapEntity(Country entity, Entity entityDefinition, OCountry dto)
    {
        // TODO Map entity
    }
}