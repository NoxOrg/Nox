using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Abstractions.Models;

public class NoxTargetAdapterResponse: INoxTargetAdapterResponse
{
    public bool Success { get; internal set; }
    public string? ErrorMessage { get; internal set; }
    public string? ResponsePayload { get; set; }
}