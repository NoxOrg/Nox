using ETLBox;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Adapters;

public class SqlServerReceiveAdapter: INoxDatabaseReceiveAdapter
{
    public IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.DatabaseQuery;
    
    public string Query { get; }
    public int MinimumExpectedRecords { get; }
    public IConnectionManager ConnectionManager { get; }

    public SqlServerReceiveAdapter(string query, int minimumExpectedRecords, string connectionString)
    {
        Query = query;
        MinimumExpectedRecords = minimumExpectedRecords;
        ConnectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
    }
    
}