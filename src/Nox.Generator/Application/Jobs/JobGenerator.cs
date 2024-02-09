using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;

namespace Nox.Generator.Application.Jobs;

internal class JobGenerator : INoxCodeGenerator
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

        if (codeGenConventions.Solution.Application?.Jobs is null )
            return;

        foreach (var job in codeGenConventions.Solution.Application!.Jobs)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            new TemplateCodeBuilder(context, codeGenConventions)
                .WithClassName($"{job.Name}Job")
                .WithFileNamePrefix($"Application.Jobs")
                .WithObject("job", job)
                .GenerateSourceCodeFromResource("Application.Jobs.Job");
        }
    }
}
