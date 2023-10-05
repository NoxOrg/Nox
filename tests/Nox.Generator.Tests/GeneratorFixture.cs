﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nox.Generator.Tests.Flows;

namespace Nox.Generator.Tests;

public class GeneratorFixture
{
    public IGeneratorTestFlow GenerateSourceCodeFor(IEnumerable<string> sourcePaths)
    {
        var assets = CreateCompilationCompiler();

        var additionalSources = sourcePaths
            .Select(path => new AdditionalSourceText(File.ReadAllText(path), path));

        // trackIncrementalGeneratorSteps allows to report info about each step of the generator
        var driver = CSharpGeneratorDriver.Create(
            generators: new[] { assets.generator },
            additionalTexts: additionalSources,
            driverOptions: new GeneratorDriverOptions(default, trackIncrementalGeneratorSteps: true));

        // Run the generator
        var result = driver
            .RunGenerators(assets.compilation)
            .GetRunResult()
            .Results
            .Single();

        return new GeneratorTestFlow(result);
    }

    private static (Compilation compilation, ISourceGenerator generator) CreateCompilationCompiler()
    {
        var workspace = new AdhocWorkspace();
        var project = workspace.CurrentSolution.AddProject("MyProject", "MyProject.dll", LanguageNames.CSharp);

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