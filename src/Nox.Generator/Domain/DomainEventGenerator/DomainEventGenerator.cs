using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;

namespace Nox.Generator.Domain.DomainEventGenerator;

internal class DomainEventGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions codeGenConventions,
        GeneratorConfig config,
        System.Action<string> log,
        string? projectRootPath
    )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null) return;

        foreach (var entity in codeGenConventions.Solution.Domain.Entities.Where(e=> e.Events.Any()))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName(entity.Name+"DomainEvents")
                .WithFileNamePrefix($"Domain.Events")
                .WithObject("entity", entity)
                .GenerateSourceCodeFromResource("Domain.DomainEventGenerator.DomainEvent");
        }
    }
}