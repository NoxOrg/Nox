using Nox.Solution;

namespace Nox.Generator.Tasks.Common;

internal interface INoxFileGenerator
{
    NoxGeneratorKind GeneratorKind { get; }

    /// <summary>
    /// Generate file.
    /// </summary>
    /// <param name="codeGeneratorState"></param>
    /// <param name="config"></param>
    /// <param name="log">Function pointer to log message in the generation phase. Will log to Generator.g.cs</param>
    /// <param name="projectRootPath"></param>
    void Generate(
        NoxCodeGenConventions codeGeneratorState,
        GeneratorConfig config,
        System.Action<string> log,
        string absoluteOutputPath);
}