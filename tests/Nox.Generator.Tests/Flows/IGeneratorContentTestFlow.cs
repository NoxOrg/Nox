namespace Nox.Generator.Tests.Flows;

public interface IGeneratorContentTestFlow
{
    IGeneratorContentTestFlow WithExpectedFilesFolder(string expectedFilesFolder);

    IGeneratorContentTestFlow AssertFileExistsAndContent(string expectedFileName, string actualFileName);

    /// <summary>
    /// Asserts that the file was generated in the expected file folder.
    /// </summary>    
    IGeneratorContentTestFlow AssertFileWasGenerated(string expectedFileName);
    /// <summary>
    /// Asserts that the file was NOT generated in the expected file folder.
    /// </summary>    
    IGeneratorContentTestFlow AssertFileWasNotGenerated(string expectedFileName);

    void SourceContains(string sourceName, string content);
}