using Nox.Application;

namespace Nox.Messaging
{
    /// <summary>
    /// Factory for creating CloudEventRecords for integration events
    /// </summary>
    public interface ICloudEventRecordFactory
    {
        CloudEventRecord<T> CreateRecordForIntegrationEvent<T>(T integrationEvent) where T : IIntegrationEvent;
    }
}