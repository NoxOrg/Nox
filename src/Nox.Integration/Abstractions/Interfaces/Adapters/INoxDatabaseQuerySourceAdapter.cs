namespace Nox.Integration.Abstractions.Interfaces;

public interface INoxDatabaseQuerySourceAdapter: INoxSourceAdapter
{
    string Query { get; }
    int MinimumExpectedRecords { get; }
}

public interface INoxDatabaseQuerySourceAdapter<TSource>: INoxSourceAdapter<TSource>
{
    string Query { get; }
    int MinimumExpectedRecords { get; }
}
