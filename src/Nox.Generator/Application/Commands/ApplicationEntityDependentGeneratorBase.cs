using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Commands;

internal abstract class ApplicationEntityDependentGeneratorBase : INoxCodeGenerator
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

        if (codeGenConventions.Solution.Domain is null)
        {
            return;
        }

        DoGenerate(context, codeGenConventions, codeGenConventions.Solution.Domain.Entities);
    }

    protected abstract void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGenConventions, IEnumerable<Entity> entities);
}