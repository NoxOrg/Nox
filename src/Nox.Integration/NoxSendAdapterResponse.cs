using Nox.Integration.Abstractions;

namespace Nox.Integration;

public class NoxSendAdapterResponse: INoxSendAdapterResponse
{
    public bool Success { get; internal set; }
    public string? ErrorMessage { get; internal set; }
    public string? ResponsePayload { get; set; }
}