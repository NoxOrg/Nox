using Nox.Abstractions;
using Nox.Application;

namespace Nox.Messaging
{
    internal class DefaultCloudEventRecordFactory : ICloudEventRecordFactory
    {

        public DefaultCloudEventRecordFactory()
        {
        }

        public CloudEventRecord<T> CreateRecordForIntegrationEvent<T>(T integrationEvent) where T : IIntegrationEvent
        {
            return new CloudEventRecord<T>(integrationEvent);
        }
    }
}