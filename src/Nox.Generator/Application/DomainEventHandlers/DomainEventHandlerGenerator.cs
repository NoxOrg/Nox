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

        foreach (var (crudOperation, entity) in GroupEntitiesWithDomainEventsByCrudOperation(codeGeneratorState.Solution.Domain.Entities))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}{crudOperation}DomainEventHandler")
                .WithFileNamePrefix($"Application.DomainEventHandlers")
                .WithObject("crudOperation", crudOperation)
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource("Application.DomainEventHandlers.DomainEventHandler");
        }
    }

    private IEnumerable<(string CrudOperation, Entity entity)> GroupEntitiesWithDomainEventsByCrudOperation(IEnumerable<Entity> entities)
    {
        var entitiesWithDomainEvents = GetEntitiesThatHaveDomainEvents(entities);

        return entitiesWithDomainEvents.Where(e => e.Persistence?.Create?.RaiseDomainEvents == true).Select(e => ("Created", e))
            .Concat(entitiesWithDomainEvents.Where(e => e.Persistence?.Update?.RaiseDomainEvents == true).Select(e => ("Updated", e)))
            .Concat(entitiesWithDomainEvents.Where(e => e.Persistence?.Delete?.RaiseDomainEvents == true).Select(e => ("Deleted", e)));
    }

    private IEnumerable<Entity> GetEntitiesThatHaveDomainEvents(IEnumerable<Entity> entities)
        => entities.Where(e => e.HasDomainEvents);
}
