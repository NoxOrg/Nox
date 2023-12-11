using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Extensions;

public static class EtlEventExtensions
{
    public static INoxEtlEventPayload ResolvePayload(this IDictionary<string, object?> record, INoxEtlEvent<INoxEtlEventPayload> @event)
    {
        var payloadType = @event.Payload!.GetType();
        var payload = Activator.CreateInstance(payloadType);
        foreach (var prop in payloadType.GetProperties())
        {
            var sourceVal = record[prop.Name];
            if (sourceVal == null) continue;
            prop.SetValue(payload, sourceVal);
        }
        return (INoxEtlEventPayload)payload!;
    }
}