using Nox.Solution;
using Nox.Docs.Extensions;
using FluentAssertions;
using Nox.Docs.Models;

namespace Cryptocash.Api.Tests;

public class CryptocashGenDocsTests
{
    [Fact]
    public void Solution_Creates_Valid_Documentation()
    {
        var noxSolution = new NoxSolutionBuilder()
            .UseYamlFile("../../../../.nox/design/cryptocash.solution.nox.yaml")
            .Build();

        var readme = noxSolution.ToMarkdownReadme();

        readme.Should().NotBeNull();
        Write(readme);
    }

    private static void Write(MarkdownReadme readme)
    {
        var folderPath = "../../../../";

        WriteFile($"{folderPath}{readme.Name}", readme.Content);
        
        foreach (var markdown in readme.ReferencedMarkdowns)
        {
            WriteFile($"{folderPath}{markdown.Name}", markdown.Content);
        }
    }

    private static void WriteFile(string filePath, string fileContent)
    {
        CreateFolderIfDoesNotExist(filePath);

        File.WriteAllText(filePath, fileContent);
    }

    private static void CreateFolderIfDoesNotExist(string filePath)
    {
        var folderPath = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(folderPath) && !Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
}