using Microsoft.CodeAnalysis;
using Nox.Solution;

namespace Nox.Generator.Common;

internal interface INoxFileGenerator
{
    NoxGeneratorKind GeneratorKind { get; }

    void Generate(NoxSolutionCodeGeneratorState codeGeneratorState, string? projectRootPath);
}