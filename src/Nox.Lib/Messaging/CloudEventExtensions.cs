using CloudNative.CloudEvents;
using Nox.Application;

namespace Nox.Messaging
{
    internal static class CloudEventExtensions
    {
        public static void ToRecord<T>(this CloudEvent cloudEvent, CloudEventRecord<T> cloudEventRecord) where T : IIntegrationEvent
        {
            cloudEventRecord.specversion = cloudEvent.SpecVersion.VersionId;
            cloudEventRecord.id = cloudEvent.Id;
            cloudEventRecord.source = cloudEvent.Source;
            cloudEventRecord.type = cloudEvent.Type;
            cloudEventRecord.dataschema = cloudEvent.DataSchema;
            cloudEventRecord.time = cloudEvent.Time;
            cloudEventRecord.subject = cloudEvent.Subject;
            cloudEventRecord.xcorrelationid = Guid.NewGuid();
        }
    }

}
