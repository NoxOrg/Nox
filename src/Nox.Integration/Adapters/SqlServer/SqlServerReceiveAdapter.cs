using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Adapters;

public class SqlServerReceiveAdapter: INoxDatabaseReceiveAdapter
{
    public IntegrationAdapterType AdapterType => IntegrationAdapterType.Database;
    
    public string Query { get; }
    public int MinimumExpectedRecords { get; }
    
    public SqlServerReceiveAdapter(string query, int minimumExpectedRecords)
    {
        Query = query;
        MinimumExpectedRecords = minimumExpectedRecords;
    }

    
}