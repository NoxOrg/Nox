using Nox.Docs.Models;
using Nox.Solution;

namespace Nox.Docs.Extensions;

public static class NoxSolutionReadmeGenerationExtensions
{
    public static void GenerateMarkdownReadme(this NoxSolution noxSolution, string rootPath, ErdDetail mermaidErdDetail = ErdDetail.Summary)
    {
        var readme = noxSolution.ToMarkdownReadme(mermaidErdDetail);

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

        // make sure all newlines are cr+lf - messes with git otherwise
        var sanitizedContent = fileContent.ReplaceLineEndings("\r\n");

        File.WriteAllText(filePath, sanitizedContent);
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