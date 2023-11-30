using FluentAssertions;
using Nox.Yaml.Schema;

namespace Nox.Solution.Tests;

public class NoxSolutionSchemaGenerate
{
    private readonly string _path = FindOrCreateFolderInProjectRoot("schemas");

    [Fact]
    public void Can_create_a_json_schema_for_yaml()
    {
        DeleteAllPreviousSchemas();

        var action = () => NoxSchemaGenerator.GenerateJsonSchemas<NoxSolution>(_path);

        action.Should().NotThrow();
    }

    private void DeleteAllPreviousSchemas()
    {
        var jsonFiles = Directory.GetFiles(_path, "*.json");
        foreach (var jsonFile in jsonFiles)
        {
            File.Delete(jsonFile);
        }
    }

    private static string FindOrCreateFolderInProjectRoot(string folderName)
    {
        var path = new DirectoryInfo(Directory.GetCurrentDirectory());
        var targetFolder = string.Empty;

        while (path != null)
        {
            if (path.GetDirectories(".git").Any())
            {
                targetFolder = Path.Combine(path.FullName, folderName);
                if (!Path.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                break;
            }

            path = path.Parent;
        }

        return targetFolder;
    }
}