using ETLBox;

namespace Nox.Integration.Abstractions.Adapters;

public interface INoxDatabaseReceiveAdapter: INoxReceiveAdapter
{
    string Query { get; }
    int MinimumExpectedRecords { get; }
}