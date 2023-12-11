namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxEtlEvent<TPayload>
{
    string? IntegrationName { get; internal set; }
    
    TPayload? Payload { get; }

    void SetPayload(TPayload payload);
}