using Nox.Integration.Abstractions;

namespace Nox.Integration.EtlEvents;

public class NoxEtlExecuteCompletedEvent: INoxEtlEvent<NoxEtlExecuteCompletedPayload>
{
    private NoxEtlExecuteCompletedPayload? _payload;
    
    public string? IntegrationName { get; set; }

    public NoxEtlExecuteCompletedPayload? Payload => _payload;
    
    public void SetPayload(NoxEtlExecuteCompletedPayload payload)
    {
        _payload = payload;
    }
}