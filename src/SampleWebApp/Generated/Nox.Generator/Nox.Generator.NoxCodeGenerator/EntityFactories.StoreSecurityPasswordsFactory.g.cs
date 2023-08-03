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

public class StoreSecurityPasswordsFactory: EntityFactoryBase<OStoreSecurityPasswords, StoreSecurityPasswords>
{
    public  StoreSecurityPasswordsFactory(NoxSolution noxSolution): base(noxSolution) { }

    protected override void MapEntity(StoreSecurityPasswords entity, Entity entityDefinition, OStoreSecurityPasswords dto)
    {
        // TODO Map entity
    }
}