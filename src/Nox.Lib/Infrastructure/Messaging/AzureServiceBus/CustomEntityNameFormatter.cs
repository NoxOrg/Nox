using MassTransit;

namespace Nox.Infrastructure.Messaging.AzureServiceBus
{
    internal class CustomEntityNameFormatter : IEntityNameFormatter
    {
        public string FormatEntityName<T>()
        {
            return "test-integration-event";
        }
    }
}