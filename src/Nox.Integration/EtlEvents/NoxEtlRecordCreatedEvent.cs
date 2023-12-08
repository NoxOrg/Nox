using Nox.Integration.Abstractions;

namespace Nox.Integration.EtlEvents;

public class NoxEtlRecordCreatedEvent<TPayload>: INoxEtlEvent<TPayload> where TPayload: INoxEtlEventPayload
{
    private TPayload? _payload;
    
    public string? IntegrationName { get; set; }
    
    public void SetPayload(TPayload payload)
    {
        _payload = payload;
    }

    public TPayload? Payload => _payload;
}