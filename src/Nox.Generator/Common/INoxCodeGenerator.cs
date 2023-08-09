using Microsoft.CodeAnalysis;
using Nox.Solution;

namespace Nox.Generator.Common;

internal interface INoxCodeGenerator
{
    NoxGeneratorKind GeneratorKind { get; }

    void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config);
}