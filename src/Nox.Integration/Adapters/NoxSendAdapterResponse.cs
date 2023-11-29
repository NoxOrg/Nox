using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Adapters;

public class NoxSendAdapterResponse: INoxSendAdapterResponse
{
    public bool Success { get; internal set; }
    public string? ErrorMessage { get; internal set; }
    public string? ResponsePayload { get; set; }
}