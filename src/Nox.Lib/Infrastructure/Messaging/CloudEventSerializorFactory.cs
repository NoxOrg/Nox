using MassTransit;
using System.Net.Mime;

namespace Nox.Infrastructure.Messaging;

internal sealed class CloudEventSerializorFactory : ISerializerFactory
{
    private string _platformId;
    private string _solutionName;
    private string _solutionVersion;

    public CloudEventSerializorFactory(string platformId, string solutionName, string solutionVersion)
    {
        _platformId = platformId;
        _solutionName = solutionName;
        _solutionVersion = solutionVersion;
    }

    public ContentType ContentType => new("application/cloudevents+json");

    public IMessageDeserializer CreateDeserializer()
    {
        throw new NotImplementedException();
    }

    public IMessageSerializer CreateSerializer()
    {
        return new CloudEventMessageSerializer(_platformId, _solutionName, _solutionVersion);
    }
}
