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

public class CurrencyFactory: EntityFactoryBase<OCurrency, Currency>
{
    public  CurrencyFactory(NoxSolution noxSolution): base(noxSolution) { }

    protected override void MapEntity(Currency entity, Entity entityDefinition, OCurrency dto)
    {
        // TODO Map entity
    }
}