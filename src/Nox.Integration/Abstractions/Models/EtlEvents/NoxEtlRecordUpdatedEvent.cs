using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Abstractions.Models;

public class NoxEtlRecordUpdatedEvent<TPayload>: INoxEtlEvent<TPayload> where TPayload: INoxEtlEventPayload
{
    private TPayload? _payload;
    
    public string? IntegrationName { get; set; }
    
    public TPayload? Payload => _payload;
    
    public void SetPayload(TPayload payload)
    {
        _payload = payload;
    }
}