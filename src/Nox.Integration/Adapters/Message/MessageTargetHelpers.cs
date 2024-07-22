using ETLBox;
using Nox.Integration.Adapters.Message.RabbitMq;
using Nox.Solution;
using Nox.Solution.Builders;

namespace Nox.Integration.Adapters.Message;

internal static class MessageTargetHelpers
{
    internal static object? CreateMessageBrokerTargetAdapter(Type targetType, string integrationName, IntegrationTargetMessageBrokerOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.RabbitMq:
                return CreateRabbitMqAdapter(targetType, integrationName, options, dataConnectionDefinition);
            default:
                throw new NotImplementedException($"{dataConnectionDefinition.Provider.ToString()} target adapter for integration {integrationName} has not been implemented");
        }
    }

    private static object? CreateRabbitMqAdapter(Type targetType, string integrationName, IntegrationTargetMessageBrokerOptions options, DataConnection dataConnectionDefinition)
    {
        var uriBuilder = new NoxUriBuilder(dataConnectionDefinition, "rabbitMq", integrationName)
        {
            Path = options.TargetName
        };
        var adapterType = typeof(RabbitMqTargetAdapter<>).MakeGenericType(targetType);
        return Activator.CreateInstance(adapterType, uriBuilder.Uri);
    }
}