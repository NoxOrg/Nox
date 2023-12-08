using Nox.Integration.Abstractions;

namespace Nox.Integration.EtlEvents;

public record NoxEtlExecuteCompletedPayload: INoxEtlEventPayload
{
    public int Inserts { get; set; }
    public int Updates { get; set; }
    public int Unchanged { get; set; }
}