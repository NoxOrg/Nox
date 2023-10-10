using MassTransit;

namespace Nox.Messaging.AzureServiceBus
{
    internal class CustomEntityNameFormatter : IEntityNameFormatter
    {
        public string FormatEntityName<T>()
        {
            return "test-integration-event";
        }
    }
}