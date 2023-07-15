using System.Text.Json;
using Nox.Solution.Schema;

namespace Nox.Solution.Tests;

public class NoxSolutionSchemaGenerate
{
    private readonly JsonSerializerOptions _jsonConfig = new()
    {
        WriteIndented = true,
    };

    private readonly string _path = FindOrCreateFolderInProjectRoot("schemas");

    [Fact]
    public void Can_create_a_json_schema_for_yaml()
    {
        /*
         * TODO: $ref support for arrays/lists
         *
         * TODO: make enum type strings too
         *
         */

        NoxSchemaGenerator.GenerateJsonSchemas(typeof(Solution),_path);

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