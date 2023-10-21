using Microsoft.CodeAnalysis;
using Nox.Solution;

namespace Nox.Generator.Common;

internal interface INoxCodeGenerator
{
    NoxGeneratorKind GeneratorKind { get; }

    /// <summary>
    /// Generate code for the given context.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="codeGeneratorState"></param>
    /// <param name="config"></param>
    /// <param name="log">Function pointer to log message in the generation phase. Will log to Generator.g.cs</param>
    /// <param name="projectRootPath"></param>
    void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions codeGeneratorState,
        GeneratorConfig config,
        System.Action<string> log,
        string? projectRootPath);
}