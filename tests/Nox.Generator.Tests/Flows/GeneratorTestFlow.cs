using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.CodeAnalysis;

namespace Nox.Generator.Tests.Flows;

internal class GeneratorTestFlow : IGeneratorTestFlow
{
    private readonly GeneratorRunResult _generatorRunResult;

    public GeneratorTestFlow(GeneratorRunResult generatorRunResult)
    {
        _generatorRunResult = generatorRunResult;
        Sources = _generatorRunResult
            .GeneratedSources
            .Select(x => x.SourceText.ToString())
            .ToArray();
    }

    public IEnumerable<string> Sources { get; }

    public IGeneratorTestFlow AssertFileExistence(int expectedFileCount, params string[] fileNames)
    {
        _generatorRunResult
            .GeneratedSources
            .Should()
            .HaveCount(expectedFileCount)
            .And
            .Contain(x => x.HintName == "Application.ServiceCollectionExtensions.g.cs", "NoxWebApplicationExtensions.g.cs not generated")
            .And
            .Contain(x => x.HintName == "0.Generator.g.cs", "Generator not generated");

        foreach (var fileName in fileNames)
        {
            _generatorRunResult
            .GeneratedSources
            .Should()
            .Contain(x => x.HintName == fileName, $"{fileName} not generated");
        }

        return this;
    }

    public IGeneratorContentTestFlow AssertContent()
    {
        return new GeneratorContentTestFlow(_generatorRunResult);
    }

    public IGeneratorTestFlow AssertOutputResult()
    {
        _generatorRunResult
            .TrackedOutputSteps
            .SelectMany(outputStep => outputStep.Value)
            .SelectMany(output => output.Outputs)
            .Should()
            .NotBeEmpty()
            .And
            .ContainSingle();

        return this;
    }
}