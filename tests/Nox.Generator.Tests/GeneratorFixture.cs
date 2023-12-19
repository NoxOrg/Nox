using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator.Tests.Flows;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nox.Generator.Tests;

public class GeneratorFixture
{
    public static IGeneratorTestFlow GenerateSourceCodeFor(IEnumerable<string> sourcePaths)
    {
        var (compilation, generator) = CreateCompilationCompiler();

        var additionalSources = new List<AdditionalSourceText>();
        foreach (var sourcePath in sourcePaths)
        {
            additionalSources.Add(new AdditionalSourceText(File.ReadAllText(sourcePath), sourcePath));
        }

        // trackIncrementalGeneratorSteps allows to report info about each step of the generator
        var driver = CSharpGeneratorDriver.Create(
            generators: new[] { generator },
            additionalTexts: additionalSources,
            driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true));

        // Run the generator
        var result = driver
            .RunGenerators(compilation)
            .GetRunResult()
            .Results
            .Single();

        return new GeneratorTestFlow(result);
    }

    private static (Compilation compilation, ISourceGenerator generator) CreateCompilationCompiler()
    {
        using var workspace = new AdhocWorkspace();
        var project = workspace.CurrentSolution.AddProject($"MyProject", "MyProject.dll", LanguageNames.CSharp);

        project = project.AddDocument("Program.cs", File.ReadAllText("./files/Program.cs")).Project;

        var compilationOptions = project.CompilationOptions as CSharpCompilationOptions;
        compilationOptions = compilationOptions!
            .WithOutputKind(OutputKind.DynamicallyLinkedLibrary)
            .WithMetadataImportOptions(MetadataImportOptions.All)
            .WithConcurrentBuild(true);

        project = project.WithCompilationOptions(compilationOptions);

        var testCompilation = project.GetCompilationAsync().Result;

        var testGenerator = new NoxCodeGenerator()
            .AsSourceGenerator();

        return (testCompilation, testGenerator);
    }
}