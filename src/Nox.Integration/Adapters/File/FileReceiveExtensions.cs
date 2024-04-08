using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.File.Json;
using Nox.Integration.Adapters.Json;
using Nox.Solution;

namespace Nox.Integration.Adapters;

internal static class FileReceiveExtensions
{
    internal static INoxIntegration WithFileReceiveAdapter(this INoxIntegration instance, string integrationName, IntegrationSourceFileOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.JsonFile:
                instance.ReceiveAdapter = CreateJsonReceiveAdapter(options, dataConnectionDefinition);
                break;
        }

        return instance;
    }
    
    private static JsonFileReceiveAdapter CreateJsonReceiveAdapter(IntegrationSourceFileOptions options, DataConnection dataConnectionDefinition)
    {
        var adapter = new JsonFileReceiveAdapter(options.Filename, dataConnectionDefinition.ServerUri);
        return adapter;
    }
}