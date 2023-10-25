namespace Nox.Integration.Abstractions;

public class NoxReceiveAdapterDatabaseOptions
{
    public string Query { get; set; } = string.Empty;
    public int MinimumExpectedRecords { get; set; } = 0;
}