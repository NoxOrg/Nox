namespace Nox.Integration.Abstractions.Models;

public record NoxEtlExecuteCompletedPayload: INoxEtlEventPayload
{
    public int Inserts { get; set; }
    public int Updates { get; set; }
    public int Unchanged { get; set; }
}