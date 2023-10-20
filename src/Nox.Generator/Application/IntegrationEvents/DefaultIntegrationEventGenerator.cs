using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application;

internal class DefaultIntegrationEventGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain?.Entities is null)
            return;

        foreach (var (operation, entity) in GroupEntitiesWithIntegrationEventsByCrudOperation(codeGeneratorState.Solution.Domain.Entities))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGeneratorState)
                .WithClassName($"{entity.Name}{operation}")
                .WithFileNamePrefix($"Application.IntegrationEvents")
                .WithObject("operation", operation)
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource("Application.IntegrationEvents.DefaultIntegrationEvent");
        }
    }

    private IEnumerable<(string CrudOperation, Entity entity)> GroupEntitiesWithIntegrationEventsByCrudOperation(IEnumerable<Entity> entities)
    {
        var entitiesWithIntegrationEvents = GetEntitiesThatHaveIntegrationEvents(entities);

        return entitiesWithIntegrationEvents.Where(e => e.Persistence?.Create?.RaiseIntegrationEvents == true).Select(e => ("Created", e))
            .Concat(entitiesWithIntegrationEvents.Where(e => e.Persistence?.Update?.RaiseIntegrationEvents == true).Select(e => ("Updated", e)))
            .Concat(entitiesWithIntegrationEvents.Where(e => e.Persistence?.Delete?.RaiseIntegrationEvents == true).Select(e => ("Deleted", e)));
    }

    private IEnumerable<Entity> GetEntitiesThatHaveIntegrationEvents(IEnumerable<Entity> entities)
        => entities.Where(e => e.HasIntegrationEvents);
}
