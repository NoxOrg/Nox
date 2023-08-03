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

public class StoreFactory: EntityFactoryBase<OStore, Store>
{
    public  StoreFactory(NoxSolution noxSolution): base(noxSolution) { }

    protected override void MapEntity(Store entity, Entity entityDefinition, OStore dto)
    {
        // TODO Map entity
    }
}