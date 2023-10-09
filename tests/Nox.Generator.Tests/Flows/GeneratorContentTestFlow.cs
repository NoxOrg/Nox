using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.CodeAnalysis;

namespace Nox.Generator.Tests.Flows;

internal class GeneratorContentTestFlow : IGeneratorContentTestFlow
{
    private GeneratorRunResult _generatorRunResult;
    private string _expectedFilesFolder;

    public GeneratorContentTestFlow(GeneratorRunResult generatorRunResult)
    {
        _generatorRunResult = generatorRunResult;
    }

    public IGeneratorContentTestFlow Check(
        string expectedFileName,
        string actualFileName)
    {
        var generatedSources = _generatorRunResult.GeneratedSources;
        var actualFileContent = generatedSources.FirstOrDefault(s => s.HintName == actualFileName).SourceText?.ToString();
        var filePath = Path.Combine(_expectedFilesFolder, expectedFileName);

        var expectedFileContent = File.ReadAllText(filePath);

        generatedSources
            .Should()
            .Contain(s => s.HintName == actualFileName, $"{actualFileName} not generated");

        actualFileContent
            .Should()
            .BeEquivalentTo(expectedFileContent);

        return this;
    }

    public void SourceContains(string sourceName, string content)
    {
        _generatorRunResult
            .GeneratedSources
            .First(x => x.HintName == sourceName)
            .SourceText
            .ToString()
            .Should()
            .Contain(content);
    }

    public IGeneratorContentTestFlow WithExpectedFilesFolder(string expectedFilesFolder)
    {
        _expectedFilesFolder = expectedFilesFolder;
        return this;
    }
}