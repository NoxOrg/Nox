using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Json;
using Nox.Solution;

namespace Nox.Integration.Extensions.Receive;

internal static class IntegrationContextFileReceiveExtensions
{
    internal static INoxIntegration WithFileReceiveAdapter(this INoxIntegration instance, IntegrationSourceFileOptions options, DataConnection dataConnectionDefinition)
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