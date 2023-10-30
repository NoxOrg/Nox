using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Adapters;

public class SqlServerSendAdapter: INoxDatabaseSendAdapter
{
    public IntegrationAdapterType AdapterType => IntegrationAdapterType.Database;
    public string StoredProcedure { get; }

    public SqlServerSendAdapter(string storedProcedure)
    {
        StoredProcedure = storedProcedure;
    }
    
}