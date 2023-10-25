namespace Nox.Integration.Abstractions;

public interface INoxSendAdapterResponse
{
    bool Success { get; }
    string? ErrorMessage { get; }
    string? ResponsePayload { get; }
}