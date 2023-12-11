namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxDatabaseReceiveAdapter: INoxReceiveAdapter
{
    string Query { get; }
    int MinimumExpectedRecords { get; }
}