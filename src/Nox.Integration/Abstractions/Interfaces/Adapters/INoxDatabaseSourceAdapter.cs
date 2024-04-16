namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxDatabaseSourceAdapter: INoxSourceAdapter
{
    string Query { get; }
    int MinimumExpectedRecords { get; }
}

public interface INoxDatabaseSourceAdapter<TSource>: INoxSourceAdapter<TSource>
{
    string Query { get; }
    int MinimumExpectedRecords { get; }
}
