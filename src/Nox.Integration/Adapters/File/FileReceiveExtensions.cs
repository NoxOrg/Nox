using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.Json;
using Nox.Solution;

namespace Nox.Integration.Adapters;

internal static class FileSourceExtensions
{
    internal static INoxIntegration WithFileSourceAdapter(this INoxIntegration instance, string integrationName, IntegrationSourceFileOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.JsonFile:
                instance.SourceAdapter = CreateJsonSourceAdapter(options, dataConnectionDefinition);
                break;
        }

        return instance;
    }
    
    private static JsonFileSourceAdapter CreateJsonSourceAdapter(IntegrationSourceFileOptions options, DataConnection dataConnectionDefinition)
    {
        var adapter = new JsonFileSourceAdapter(options.Filename, dataConnectionDefinition.ServerUri);
        return adapter;
    }
}