namespace Nox.Integration.Abstractions.Adapters;

public interface INoxSendAdapterResponse
{
    bool Success { get; }
    string? ErrorMessage { get; }
    string? ResponsePayload { get; }
}