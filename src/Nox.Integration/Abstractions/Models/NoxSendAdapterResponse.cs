using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Abstractions.Models;

public class NoxSendAdapterResponse: INoxSendAdapterResponse
{
    public bool Success { get; internal set; }
    public string? ErrorMessage { get; internal set; }
    public string? ResponsePayload { get; set; }
}