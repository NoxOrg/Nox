using ETLBox;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Adapters;

public class SqlServerSendAdapter: INoxDatabaseSendAdapter
{
    public IntegrationAdapterType AdapterType => IntegrationAdapterType.Database;
    public string StoredProcedure { get; }
    public IConnectionManager ConnectionManager { get; }

    public SqlServerSendAdapter(string storedProcedure, string connectionString)
    {
        StoredProcedure = storedProcedure;
        ConnectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
    }
    
}