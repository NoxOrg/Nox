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

public class CountryLocalNamesFactory: EntityFactoryBase<OCountryLocalNames, CountryLocalNames>
{
    public  CountryLocalNamesFactory(NoxSolution noxSolution): base(noxSolution) { }

    protected override void MapEntity(CountryLocalNames entity, Entity entityDefinition, OCountryLocalNames dto)
    {
        // TODO Map entity
    }
}