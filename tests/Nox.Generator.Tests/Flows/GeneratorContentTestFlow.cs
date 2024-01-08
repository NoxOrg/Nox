using FluentAssertions;
using Microsoft.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Nox.Generator.Tests.Flows;

internal class GeneratorContentTestFlow : IGeneratorContentTestFlow
{
    private readonly GeneratorRunResult _generatorRunResult;
    private string _expectedFilesFolder;

    public GeneratorContentTestFlow(GeneratorRunResult generatorRunResult)
    {
        _generatorRunResult = generatorRunResult;
    }

    public IGeneratorContentTestFlow AssertFileExistsAndContent(
        string expectedFileName,
        string actualFileName)
    {
        var generatedSources = _generatorRunResult.GeneratedSources;
        var actualFileContent = generatedSources.FirstOrDefault(s => s.HintName.Replace("/", ".") == actualFileName).SourceText?.ToString();
        var filePath = Path.Combine(_expectedFilesFolder, expectedFileName);

        var expectedFileContent = File.ReadAllText(filePath);

        generatedSources
            .Should()
            .Contain(s => s.HintName.Replace("/", ".") == actualFileName, $"{actualFileName} not generated");

        actualFileContent
            .Should()
            .BeEquivalentTo(expectedFileContent);

        return this;
    }
    public IGeneratorContentTestFlow AssertFileWasGenerated(string expecteGeneratedFileName)
    {
        _generatorRunResult.GeneratedSources
            .Should()
            .Contain(s => s.HintName.Replace("/", ".") == expecteGeneratedFileName, $"{expecteGeneratedFileName} not generated");

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