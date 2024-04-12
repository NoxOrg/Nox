namespace Nox.Integration.Abstractions.Models;

public class TargetAdapterMetrics
{
    public int Inserts { get; set; } = 0;
    public int Updates { get; set; } = 0;
    public int Unchanged { get; set; } = 0;
}