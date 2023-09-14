using Nox.Docs.Models;
using Nox.Solution;

namespace Nox.Docs.Extensions;

public static class NoxSolutionReadmeGenerationExtensions
{
    public static void GenerateMarkdownReadme(this NoxSolution noxSolution, string rootPath)
    {
        var readme = noxSolution.ToMarkdownReadme();

        Write(rootPath, readme);
    }

    private static void Write(string rootPath, MarkdownFile file)
    {
        WriteFile($"{rootPath}/{file.Name}", file.Content);

        foreach (var referencedFile in file.ReferencedFiles)
        {
            Write(rootPath, referencedFile);
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