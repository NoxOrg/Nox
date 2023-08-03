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

public class AllNoxTypeFactory: EntityFactoryBase<OAllNoxType, AllNoxType>
{
    public  AllNoxTypeFactory(NoxSolution noxSolution): base(noxSolution) { }

    protected override void MapEntity(AllNoxType entity, Entity entityDefinition, OAllNoxType dto)
    {
        // TODO Map entity
    }
}