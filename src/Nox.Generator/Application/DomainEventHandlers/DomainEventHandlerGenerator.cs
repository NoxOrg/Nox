using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Application;

internal class DomainEventHandlerGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Application;

    public void Generate(
      SourceProductionContext context,
      NoxCodeGenConventions codeGenConventions,
      GeneratorConfig config,
      System.Action<string> log,
      string? projectRootPath
      )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Infrastructure?.Messaging is null || codeGenConventions.Solution.Domain?.Entities is null)
        {
            if(config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
            {
                log("Skipping generator because no entity or no messaging infrastructure set");
            }
            return;
        }
            

        foreach (var (operation, raiseIntegrationEvent, entity) in GroupEntitiesWithDomainEventsByOperation(codeGenConventions.Solution.Domain.Entities))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (raiseIntegrationEvent)
            {
                new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"{entity.Name}{operation}RaiseIntegrationEventDomainEventHandler")
                    .WithFileNamePrefix($"Application.DomainEventHandlers")
                    .WithObject("operation", operation)
                    .WithObject("entity", entity)
                    .GenerateSourceCodeFromResource("Application.DomainEventHandlers.DomainEventHandler");
            }
        }
    }

    private IEnumerable<(string Operation, bool RaiseIntegrationEvent, Entity entity)> GroupEntitiesWithDomainEventsByOperation(IEnumerable<Entity> entities)
    {
        var entitiesWithDomainEvents = GetEntitiesThatHaveDomainEvents(entities);

        return entitiesWithDomainEvents.Where(e => e.Persistence?.Create?.RaiseDomainEvents == true).Select(e => ("Created", e.Persistence?.Create?.RaiseIntegrationEvents ?? false, e))
            .Concat(entitiesWithDomainEvents.Where(e => e.Persistence?.Update?.RaiseDomainEvents == true).Select(e => ("Updated", e.Persistence?.Update?.RaiseIntegrationEvents ?? false, e)))
            .Concat(entitiesWithDomainEvents.Where(e => e.Persistence?.Delete?.RaiseDomainEvents == true).Select(e => ("Deleted", e.Persistence?.Delete?.RaiseIntegrationEvents ?? false, e)));
    }

    private IEnumerable<Entity> GetEntitiesThatHaveDomainEvents(IEnumerable<Entity> entities)
        => entities.Where(e => e.HasDomainEvents);
}
