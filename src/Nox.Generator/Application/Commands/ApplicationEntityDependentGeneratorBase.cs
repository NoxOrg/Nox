﻿using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Commands;

internal abstract class ApplicationEntityDependentGeneratorBase : INoxCodeGenerator
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

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        DoGenerate(context, codeGeneratorState, codeGeneratorState.Solution.Domain.Entities);
    }

    protected abstract void DoGenerate(SourceProductionContext context, NoxCodeGenConventions codeGeneratorState, IEnumerable<Entity> entities);
}