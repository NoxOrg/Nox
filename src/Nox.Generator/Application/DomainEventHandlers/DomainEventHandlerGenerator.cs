using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application;

internal class DomainEventHandlerGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain?.Entities is null)
            return;

        foreach (var (crudOperation, raiseIntegrationEvent, entity) in GroupEntitiesWithDomainEventsByCrudOperation(codeGeneratorState.Solution.Domain.Entities))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}{crudOperation}DomainEventHandler")
                .WithFileNamePrefix($"Application.DomainEventHandlers")
                .WithObject("crudOperation", crudOperation)
                .WithObject("raiseIntegrationEvent", raiseIntegrationEvent)
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource("Application.DomainEventHandlers.DomainEventHandler");
        }
    }

    private IEnumerable<(string CrudOperation, bool RaiseIntegrationEvent, Entity entity)> GroupEntitiesWithDomainEventsByCrudOperation(IEnumerable<Entity> entities)
    {
        var entitiesWithDomainEvents = GetEntitiesThatHaveDomainEvents(entities);

        return entitiesWithDomainEvents.Where(e => e.Persistence?.Create?.RaiseDomainEvents == true).Select(e => ("Created", e.Persistence?.Create?.RaiseIntegrationEvents ?? false, e))
            .Concat(entitiesWithDomainEvents.Where(e => e.Persistence?.Update?.RaiseDomainEvents == true).Select(e => ("Updated", e.Persistence?.Update?.RaiseIntegrationEvents ?? false, e)))
            .Concat(entitiesWithDomainEvents.Where(e => e.Persistence?.Delete?.RaiseDomainEvents == true).Select(e => ("Deleted", e.Persistence?.Delete?.RaiseIntegrationEvents ?? false, e)));
    }

    private IEnumerable<Entity> GetEntitiesThatHaveDomainEvents(IEnumerable<Entity> entities)
        => entities.Where(e => e.HasDomainEvents);
}
