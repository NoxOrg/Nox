namespace Nox.Generator.Tests.Flows;

public interface IGeneratorContentTestFlow
{
    IGeneratorContentTestFlow WithExpectedFilesFolder(string expectedFilesFolder);

    IGeneratorContentTestFlow AssertFileExistsAndContent(string expectedFileName, string actualFileName);

    /// <summary>
    /// Assserts that the file was generated in the expected file folder.
    /// </summary>
    /// <param name="expectedFileName"></param>
    /// <returns></returns>
    IGeneratorContentTestFlow AssertFileWasGenerated(string expectedFileName);

    void SourceContains(string sourceName, string content);
}