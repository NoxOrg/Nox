﻿using FluentAssertions;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Generator.Tests.Flows;

internal class GeneratorTestFlow : IGeneratorTestFlow
{
    private readonly GeneratorRunResult _generatorRunResult;

    public GeneratorTestFlow(GeneratorRunResult generatorRunResult)
    {
        _generatorRunResult = generatorRunResult;

        Sources = _generatorRunResult
            .GeneratedSources
            .Select(x => new { key = x.HintName, value = x.SourceText.ToString()})
            .ToDictionary(x => x.key, x => x.value);
    }

    public IDictionary<string,string> Sources { get; }

    public IGeneratorTestFlow AssertFileCount(int expectedFileCount, params string[] fileNames)
    {
        _generatorRunResult
            .GeneratedSources
            .Should()
            .HaveCount(expectedFileCount)
            .And
            .Contain(x => x.HintName == "Generator.g.cs", "Generator not generated");

        foreach (var fileName in fileNames)
        {
            _generatorRunResult
            .GeneratedSources
            .Should()
            .Contain(x => x.HintName.Replace("/", ".") == fileName, $"{fileName} not generated");
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