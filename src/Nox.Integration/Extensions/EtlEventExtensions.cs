using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Extensions;

public static class EtlEventExtensions
{
    public static IEtlEventDto ResolvePayload(this IDictionary<string, object?> record, IEtlEvent<IEtlEventDto> @event)
    {
        var payloadType = @event.Dto!.GetType();
        var payload = Activator.CreateInstance(payloadType);
        foreach (var prop in payloadType.GetProperties())
        {
            var sourceVal = record[prop.Name];
            if (sourceVal == null) continue;
            prop.SetValue(payload, sourceVal);
        }
        return (IEtlEventDto)payload!;
    }
}