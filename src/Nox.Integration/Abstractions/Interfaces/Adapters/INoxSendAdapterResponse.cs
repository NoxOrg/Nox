namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxSendAdapterResponse
{
    bool Success { get; }
    string? ErrorMessage { get; }
    string? ResponsePayload { get; }
}