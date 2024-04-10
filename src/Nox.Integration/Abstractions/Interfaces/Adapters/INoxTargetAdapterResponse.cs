namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxTargetAdapterResponse
{
    bool Success { get; }
    string? ErrorMessage { get; }
    string? ResponsePayload { get; }
}