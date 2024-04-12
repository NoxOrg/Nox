using Nox.Integration.Adapters.Json;
using Nox.Solution;

namespace Nox.Integration.Adapters;

internal static class FileSourceHelpers
{
    internal static object? CreateFileSourceAdapter(Type sourceType, string integrationName, IntegrationSourceFileOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.JsonFile:
                return CreateJsonSourceAdapter(sourceType, options, dataConnectionDefinition);
        }

        throw new NotImplementedException($"{dataConnectionDefinition.Provider.ToString()} source adapter for integration {integrationName} is not implemented.");
    }
    
    private static object? CreateJsonSourceAdapter(Type sourceType, IntegrationSourceFileOptions options, DataConnection dataConnectionDefinition)
    {
        var adapterType = typeof(JsonFileSourceAdapter<>).MakeGenericType(sourceType);
        return Activator.CreateInstance(adapterType, options.Filename, dataConnectionDefinition.ServerUri);
    }
}