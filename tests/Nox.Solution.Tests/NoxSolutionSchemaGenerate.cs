using System.Text.Json;
using Nox.Solution.Resolvers;

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

        //Solution
        GenerateFor<Solution>("solution.json");

        //Variables
        GenerateFor<Dictionary<string, string>?>("variables.json");

        //Environments
        GenerateFor<Environment>("environment.json");

        //Version Control
        GenerateFor<VersionControl>("versionControl.json");

        //Team
        GenerateFor<TeamMember>("team.json");

        //Domain
        GenerateFor<Domain>("domain.json");

        //Domain/Entity
        GenerateFor<Entity>("entity.json");

        //Application
        GenerateFor<Application>("application.json");

        //Application/DataTransferObjects
        GenerateFor<List<DataTransferObject>>("dataTransferObjects.json");

        //Application/dto
        GenerateFor<DataTransferObject>("dto.json");

        //Application/Integration
        GenerateFor<Integration>("integration.json");

        //Infrastructure
        GenerateFor<Infrastructure>("infrastructure.json");

        //Infrastructure/Persistence
        GenerateFor<Persistence>("persistence.json");

        //Infrastructure/Persistence/DatabaseServer
        GenerateFor<DatabaseServer>("databaseServer.json");

        //Infrastructure/Persistence/CacheServer
        GenerateFor<CacheServer>("cacheServer.json");

        //Infrastructure/Persistence/SearchServer
        GenerateFor<SearchServer>("searchServer.json");

        //Infrastructure/Persistence/EventSourceServer
        GenerateFor<Infrastructure>("eventSourceServer.json");

        //Infrastructure/Messaging
        GenerateFor<Messaging>("messaging.json");

        //Infrastructure/Endpoints
        GenerateFor<Endpoints>("endpoints.json");

        //Infrastructure/Endpoints/ApiServer
        GenerateFor<ApiServer>("apiServer.json");

        //Infrastructure/Endpoints/BffServer
        GenerateFor<BffServer>("bffServer.json");

        //Infrastructure/Dependencies
        GenerateFor<Dependencies>("dependencies.json");

        //Infrastructure/Dependencies/Notifications
        GenerateFor<Notifications>("notifications.json");

        //Infrastructure/Dependencies/Monitoring
        GenerateFor<Monitoring>("monitoring.json");

        //Infrastructure/Dependencies/Translations
        GenerateFor<Translations>("translations.json");

        //Infrastructure/Dependencies/Security
        GenerateFor<Security>("security.json");

        //Infrastructure/Dependencies/DataConnection
        GenerateFor<DataConnection>("dataConnection.json");
    }

    private void GenerateFor<TType>(string fileName)
    {
        var solutionSchema = SchemaGenerator.Generate<TType>();

        File.WriteAllText(Path.Combine(_path, fileName),
            JsonSerializer.Serialize(solutionSchema, _jsonConfig)
        );
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