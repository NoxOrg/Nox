namespace Nox.Generator.Tests.Flows;

public interface IGeneratorContentTestFlow
{
    IGeneratorContentTestFlow WithExpectedFilesFolder(string expectedFilesFolder);

    IGeneratorContentTestFlow AssertFileExistsAndContent(string expectedFileName, string actualFileName);
    IGeneratorContentTestFlow AssertFileWasGenerated(string expectedFileName);

    void SourceContains(string sourceName, string content);
}